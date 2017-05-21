using System;

namespace notefrequency {
	public class EqualTemperedConverter : IConverter {
		public Note Anchor { get; set;}
		public EqualTemperedConverter () {
			Anchor = new Note { Letter = NoteLetter.A, Octave = 4, Offset = 440.0 };
		}

		public Note FreqToNote (double frequencyInHz) {
			double deltaSemitones = (double)Note.TotalSemitonesInOctave * Math.Log (frequencyInHz / Anchor.Offset, 2.0);
			int roundedDeltaSemitones = (int)Math.Round (deltaSemitones, 0);
			var result = Anchor.Transpose (roundedDeltaSemitones);
			var pureFreq = NoteToFreq (result);
			result.Offset = frequencyInHz - pureFreq;
			return result;
		}

		public double NoteToFreq (Note note) {
			return Anchor.Offset*Math.Pow(2.0,Anchor.CalculateSemitonesTo(note)/(double)Note.TotalSemitonesInOctave);
		}
	}
}

