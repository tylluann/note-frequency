using System;

namespace notefrequency {
	public enum NoteLetter { C=0, Db=1, D=2, Eb, E, F, Gb, G, Ab, A, Bb, B};

	/// <summary>
	/// Note.
	/// Describes single note with its relative offset to some frequency.
	/// Offset also could be used in anchor note to describe its frequency 
	/// </summary>
	public class Note {
		public NoteLetter Letter { get; set;}
		public int Octave { get; set;}
		public double Offset { get; set;} //in Hz

		public static readonly int TotalSemitonesInOctave = Enum.GetNames(typeof (NoteLetter)).Length;

		/// <summary>
		/// Calculates number of semitones from current note to otherNote.
		/// </summary>
		/// <returns>Number of semitones between current note and otherNote</returns>
		/// <param name="otherNote">Other note.</param>
		public int CalculateSemitonesTo (Note otherNote) {
			return (otherNote.Octave - Octave) * TotalSemitonesInOctave + (int)(otherNote.Letter) - (int)(Letter);
		}

		/// <summary>
		/// Transpose note by specified numOfSemitones. Semitones may be <0.
		/// </summary>
		/// <param name="numOfSemitones">Number of semitones.</param>
		public Note Transpose (int numOfSemitones) {
			var result = new Note ();
			int semitones = numOfSemitones%TotalSemitonesInOctave;
			int octavesDiff = numOfSemitones/TotalSemitonesInOctave;
			if ((semitones + (int) Letter)>=TotalSemitonesInOctave)
			{
				result.Letter = (NoteLetter) (semitones + (int) Letter - TotalSemitonesInOctave);
				octavesDiff++;
			}
			else if ((semitones + (int) Letter) < 0)
			{
				result.Letter = (NoteLetter) (semitones + (int) Letter + TotalSemitonesInOctave);
				octavesDiff--;
			}
			else result.Letter = (NoteLetter) (semitones + (int) Letter);
			result.Octave = Octave + octavesDiff;
			return result;
		}

	}
}

