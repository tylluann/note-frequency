using NUnit.Framework;
using System;
using notefrequency;
using System.Collections.Generic;

namespace test {
	[TestFixture]
	public class EqualTemperedConverter_Test {
		EqualTemperedConverter conv;
		List<Note> notesToCheck;

		[SetUp]
		public void Init () {
			conv = new EqualTemperedConverter();
			notesToCheck = Support.CreateNotesCheckListForA440 ();
		}

		[Test]
		public void CheckDefaultAnchor () {
			Assert.AreEqual (NoteLetter.A, conv.Anchor.Letter);
			Assert.AreEqual (4, conv.Anchor.Octave);
			Assert.AreEqual (440.0, conv.Anchor.Offset);
		}

		[Test]
		public void CheckNoteList () {
			foreach( var note in notesToCheck) {
				var convNote = conv.FreqToNote (note.Offset);
				Assert.AreEqual (note.Letter, convNote.Letter);
				Assert.AreEqual (note.Octave, convNote.Octave);
				var freq = conv.NoteToFreq (convNote);
				Assert.AreEqual (note.Offset, Math.Round(freq,3));
			}
		}

		[Test]
		public void CheckOffset () {
			var convNote = conv.FreqToNote (450.0);
			Assert.AreEqual (NoteLetter.A, convNote.Letter);
			Assert.AreEqual (4, convNote.Octave);
			Assert.AreEqual (10.0, convNote.Offset);

			convNote = conv.FreqToNote (430.0);
			Assert.AreEqual (NoteLetter.A, convNote.Letter);
			Assert.AreEqual (4, convNote.Octave);
			Assert.AreEqual (-10.0, convNote.Offset);
		}
	}
}

