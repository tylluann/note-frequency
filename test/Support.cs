using System;
using notefrequency;
using System.Collections.Generic;

namespace test {
	public static class Support {
		public static List<Note> CreateNotesCheckListForA440 () {
			var result = new List<Note> ();
			result.Add (new Note{ Letter = NoteLetter.C, Octave = 2, Offset = 65.406 });
			result.Add (new Note{ Letter = NoteLetter.D, Octave = 2, Offset = 73.416 });
			result.Add (new Note{ Letter = NoteLetter.E, Octave = 2, Offset = 82.407 });
			result.Add (new Note{ Letter = NoteLetter.F, Octave = 2, Offset = 87.307 });
			result.Add (new Note{ Letter = NoteLetter.G, Octave = 2, Offset = 97.999 });
			result.Add (new Note{ Letter = NoteLetter.A, Octave = 2, Offset = 110.0 });
			result.Add (new Note{ Letter = NoteLetter.B, Octave = 2, Offset = 123.471 });

			result.Add (new Note{ Letter = NoteLetter.C, Octave = 4, Offset = 261.626 });
			result.Add (new Note{ Letter = NoteLetter.D, Octave = 4, Offset = 293.665 });
			result.Add (new Note{ Letter = NoteLetter.E, Octave = 4, Offset = 329.628 });
			result.Add (new Note{ Letter = NoteLetter.F, Octave = 4, Offset = 349.228 });
			result.Add (new Note{ Letter = NoteLetter.G, Octave = 4, Offset = 391.995 });
			result.Add (new Note{ Letter = NoteLetter.A, Octave = 4, Offset = 440.0 });
			result.Add (new Note{ Letter = NoteLetter.B, Octave = 4, Offset = 493.883 });

			result.Add (new Note{ Letter = NoteLetter.C, Octave = 5, Offset = 523.251 });
			result.Add (new Note{ Letter = NoteLetter.D, Octave = 5, Offset = 587.33 });
			result.Add (new Note{ Letter = NoteLetter.E, Octave = 5, Offset = 659.255 });
			result.Add (new Note{ Letter = NoteLetter.F, Octave = 5, Offset = 698.456 });
			result.Add (new Note{ Letter = NoteLetter.G, Octave = 5, Offset = 783.991 });
			result.Add (new Note{ Letter = NoteLetter.A, Octave = 5, Offset = 880.0 });
			result.Add (new Note{ Letter = NoteLetter.B, Octave = 5, Offset = 987.767 });
			return result;
		}
	}
}

