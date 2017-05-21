using System;

namespace notefrequency {
	public interface IConverter {
		/// <summary>
		/// Gets or sets the anchor note.
		/// </summary>
		/// <value>The 'offset' property of the anchor note means the frequency of the anchor.
		/// For example, to set A4 = 440 Hz use
		/// Anchor = new Note {Letter = NoteLetter.A, Octave = 4, Offset = 440}
		/// </value>
		Note Anchor{ get; set;}
		/// <summary>
		/// Calculates the nearest note to given frequency and an offset for it.
		/// </summary>
		/// <returns>Note with offset in Hz.</returns>
		/// <param name="frequencyInHz">Frequency in Hz.</param>
		Note FreqToNote (double frequencyInHz);
		/// <summary>
		/// Calculates frequency for given note 
		/// </summary>
		/// <returns>Frequency in Hz</returns>
		/// <param name="note">Note (ignoring Offset property).</param>
		double NoteToFreq (Note note);
	}
}

