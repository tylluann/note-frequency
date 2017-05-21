using System;
using Gtk;
using notefrequency;

public partial class MainWindow: Gtk.Window {
	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();
		_conv = new EqualTemperedConverter ();
		foreach (var letter in Enum.GetValues(typeof(NoteLetter))) {
			cmbNote.AppendText (letter.ToString ());
			cmbAnchorNote.AppendText (letter.ToString ());
		}
		for (int i = 0; i < 9; ++i) {
			cmbOctave.AppendText (i.ToString ());
			cmbAnchorOctave.AppendText (i.ToString ());
		}
		SetCurrentFrequency (440.0);
		SetCurrentNote (CalculateNote (440.0));
		cmbAnchorNote.Active = (int) NoteLetter.A;
		cmbAnchorOctave.Active = 4;
		entAnchorFrequency.Text = "440";
		_conv.Anchor = ReadAnchorNote ();
		_anchorJustChanged = false;

		hscFrequency.ChangeValue += OnHscFrequencyValueChanged;
		entFrequency.Changed += OnEntFrequencyChanged;
		cmbOctave.Changed += OnNoteChanged;
		cmbNote.Changed += OnNoteChanged;
		cmbAnchorNote.Changed += OnAnchorNoteChanged;
		cmbAnchorOctave.Changed += OnAnchorNoteChanged;
		entAnchorFrequency.Changed += OnAnchorNoteChanged;
		MotionNotifyEvent += delegate {
			_anchorJustChanged = false;
		};
	}	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}

	protected void SetCurrentFrequency (double frequency) {
		hscFrequency.Value = frequency;
		entFrequency.Text = frequency.ToString ();
	}

	protected void SetCurrentNote (Note note) {
		cmbNote.Active = (int)note.Letter;
		cmbOctave.Active = note.Octave;
		entOffset.Text = note.Offset.ToString ();
	}

	//Could throw exception due to convertion from text to double
	protected Note ReadAnchorNote() {
		return new Note { Letter = (NoteLetter)cmbAnchorNote.Active, Octave = cmbAnchorOctave.Active, Offset = Convert.ToDouble(entAnchorFrequency.Text)};
	}

	protected Note ReadCurrentNote() {
		return new Note { Letter = (NoteLetter)cmbNote.Active, Octave = cmbOctave.Active };
	}

	protected Note CalculateNote (double frequency) {
		return _conv.FreqToNote (frequency);
	}

	protected double CalculateFrequency (Note note) {
		return _conv.NoteToFreq (note);
	}


	protected void OnEntFrequencyChanged (object sender, EventArgs e) {
		if (entFrequency.HasFocus) {
			try {
				var freq = Convert.ToDouble (entFrequency.Text);
				if (freq >= hscFrequency.Adjustment.Lower && freq <= hscFrequency.Adjustment.Upper) {
					hscFrequency.Value = freq;
					SetCurrentNote (CalculateNote (freq));
				}
			} catch (Exception ex) {
				//Convertion exception. No need to handle it
			}
		}
	}

	protected void OnHscFrequencyValueChanged (object sender, EventArgs e) {
		if (hscFrequency.HasFocus) {
			entFrequency.Text = hscFrequency.Value.ToString ();
			SetCurrentNote (CalculateNote (hscFrequency.Value));
		}
	}

	protected void OnNoteChanged (object sender, EventArgs e) {
		///TODO: suspect that using 'HasFocus' on other two widgets is not the most elegant solution
		if (!entFrequency.HasFocus && !hscFrequency.HasFocus && !_anchorJustChanged) {
			SetCurrentFrequency (CalculateFrequency (ReadCurrentNote ()));
		}
	}

	protected void OnAnchorNoteChanged (object sender, EventArgs e) {
		try {
			_conv.Anchor = ReadAnchorNote();
			_anchorJustChanged = true;
			SetCurrentNote (CalculateNote (hscFrequency.Value));
		} catch (Exception ex) {
			//Convertion exception. No need to handle it
		}
	}


	private IConverter _conv;
	//TODO: that's a weird hack to prevent changing frequency when anchor note is changed. It should be rewritten.
	private bool _anchorJustChanged;
}
