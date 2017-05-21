using NUnit.Framework;
using System;
using notefrequency;

namespace test {
	[TestFixture]
	public class Note_Test {
		[Test]
		public void CheckNumberOfSemitones () {
			Note A4 = new Note{ Letter = NoteLetter.A, Octave = 4 };
			Assert.AreEqual (0, A4.CalculateSemitonesTo (A4));

			Note A3 = new Note{ Letter = NoteLetter.A, Octave = 3 };
			Assert.AreEqual (12, A3.CalculateSemitonesTo (A4));
			Assert.AreEqual (-12, A4.CalculateSemitonesTo (A3));

			Note C4 = new Note{ Letter = NoteLetter.C, Octave = 4 };
			Assert.AreEqual (9, C4.CalculateSemitonesTo (A4));
			Assert.AreEqual (-9, A4.CalculateSemitonesTo (C4));

			Note C0 = new Note{ Letter = NoteLetter.C, Octave = 0 };
			Assert.AreEqual (57, C0.CalculateSemitonesTo (A4));
			Assert.AreEqual (-57, A4.CalculateSemitonesTo (C0));

		}

		[Test]
		public void CheckTranspose () {
			Note A4 = new Note{ Letter = NoteLetter.A, Octave = 4 };
			var transposed = A4.Transpose (0);
			Assert.AreEqual (A4.Letter, transposed.Letter);
			Assert.AreEqual (A4.Octave, transposed.Octave);

			transposed = A4.Transpose (-12);
			Assert.AreEqual (A4.Letter, transposed.Letter);
			Assert.AreEqual (3, transposed.Octave);

			transposed = A4.Transpose (24);
			Assert.AreEqual (A4.Letter, transposed.Letter);
			Assert.AreEqual (6, transposed.Octave);

			transposed = A4.Transpose (-9);
			Assert.AreEqual (NoteLetter.C, transposed.Letter);
			Assert.AreEqual (4, transposed.Octave);

			transposed = A4.Transpose (3);
			Assert.AreEqual (NoteLetter.C, transposed.Letter);
			Assert.AreEqual (5, transposed.Octave);

			transposed = A4.Transpose (27);
			Assert.AreEqual (NoteLetter.C, transposed.Letter);
			Assert.AreEqual (7, transposed.Octave);
		}
	}
}

