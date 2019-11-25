using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Midi_Scale_Enforcer {

    public class MainForm : Form {

        private class NoteCircle {
            public bool isVisible = false;
            public bool isPressed = false;
            public List<Rectangle> coords = new List<Rectangle>();

            public void AddPoint(Point c) {
                this.coords.Add(new Rectangle(c.X, c.Y, 25, 25));
            }
        }

        Image NotePressed;
        Image NoteVisible;
        Image FretBoard;

        Font font;

        Dictionary<string, NoteCircle> notes = new Dictionary<string, NoteCircle>();

        public ComboBox RootNotes = new ComboBox();
        public ComboBox ScaleList = new ComboBox();



        protected override void OnPaint(PaintEventArgs e) {
            var grafx = e.Graphics;
            foreach(var name in notes.Keys) {
                if(notes[name].isVisible) {
                    var toUse = NoteVisible;
                    if(notes[name].isPressed)
                        toUse = NotePressed;
                    foreach(var c in notes[name].coords) {
                        grafx.DrawImage(toUse, c);
                        grafx.DrawString(name, font, Brushes.White, c.X + 2, c.Y + 5);
                    }
                }
            }

        }

        public void InitString(string start, string end, int y) {
            var x = 21;
            if(!notes.ContainsKey(start))
                notes.Add(start, new NoteCircle());
            notes[start].AddPoint(new Point(x, y));
            x += 25;
            start = Midi_Scale_Enforcer.Scale.GetNextNoteInScale(start);
            for(var note = start; note != end; note = Midi_Scale_Enforcer.Scale.GetNextNoteInScale(note)) {
                if(!notes.ContainsKey(note))
                    notes.Add(note, new NoteCircle());
                notes[note].AddPoint(new Point(x, y));
                x += 50;
            }
        }

        public void OnNotePressed(string note) {
            if(notes.ContainsKey(note)) {
                notes[note].isPressed = true;
            }
            this.Invalidate();
        }

        public void OnNoteReleased(string note) {
            if(notes.ContainsKey(note)) {
                notes[note].isPressed = false;
            }
            this.Invalidate();
        }

        public void InitializeScale(string[] notesInScale) {
            foreach(var note in notes.Values) {
                note.isVisible = false;
            }
            foreach(string note in notesInScale) {
                for(int i = 3; i < 8; i++) {
                    if(notes.ContainsKey(note + i)) {
                        notes[note + i].isVisible = true;
                    }
                }
            }
        }

        private void ScaleChanged(object sender, System.EventArgs e) {
            string newScale = (string)ScaleList.SelectedItem;
            string newRootNote = (string)RootNotes.SelectedItem;
            if(newScale == null || newRootNote == null)
                return;
            Midi_Scale_Enforcer.Program.SetScale(newScale, newRootNote);
            this.Invalidate();
        }

        public MainForm() {
            FretBoard = Image.FromFile("resources/fretboard.jpg");
            NotePressed = Image.FromFile("resources/NotePress.png");
            NoteVisible = Image.FromFile("resources/NoteOK.png");

            // Font init stuff
            font = new Font("Arial", 8, FontStyle.Bold);

            // Form init stuff
            this.DoubleBuffered = true;
            this.ClientSize = new Size(FretBoard.Width, FretBoard.Height);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackgroundImage = FretBoard;

            // Note init stuff
            InitString("E5", "E7", 65); // High E String
            InitString("B4", "B6", 95); // B String
            InitString("G4", "G6", 125); // G string
            InitString("D4", "D6", 155); // D string
            InitString("A3", "A5", 185); // A string
            InitString("E3", "E5", 215); // Low E String

            // Init RootNote Box
            RootNotes.DropDownStyle = ComboBoxStyle.DropDownList;
            RootNotes.Items.AddRange(Midi_Scale_Enforcer.Scale.NoteSeries.ToArray());
            RootNotes.Parent = this;
            RootNotes.Location = new Point(1000, 260);

            // Init Scales Box
            ScaleList.DropDownStyle = ComboBoxStyle.DropDownList;
#region ScaleDropdown
            ScaleList.Items.Add("Major");
            ScaleList.Items.Add("Ionian");
            ScaleList.Items.Add("Phrygian");
            ScaleList.Items.Add("Lydian");
            ScaleList.Items.Add("Mixolydian");
            ScaleList.Items.Add("Minor");
            ScaleList.Items.Add("Aeolian");
            ScaleList.Items.Add("Locrian");
            ScaleList.Items.Add("HexMajor6");
            ScaleList.Items.Add("HexDorian");
            ScaleList.Items.Add("HexPhrygian");
            ScaleList.Items.Add("HexMajor7");
            ScaleList.Items.Add("HexSus");
            ScaleList.Items.Add("HexAeolian");
            ScaleList.Items.Add("MinorPentatonic");
            ScaleList.Items.Add("Yu");
            ScaleList.Items.Add("MajorPentatonic");
            ScaleList.Items.Add("Gong");
            ScaleList.Items.Add("Egyptian");
            ScaleList.Items.Add("Shang");
            ScaleList.Items.Add("Jiao");
            ScaleList.Items.Add("Pentatonic");
            ScaleList.Items.Add("Zhi");
            ScaleList.Items.Add("Ritusen");
            ScaleList.Items.Add("WholeTone");
            ScaleList.Items.Add("Whole");
            ScaleList.Items.Add("Messiaen1");
            ScaleList.Items.Add("Messiaen2");
            ScaleList.Items.Add("Messiaen3");
            ScaleList.Items.Add("Messiaen4");
            ScaleList.Items.Add("Messiaen5");
            ScaleList.Items.Add("Messiaen6");
            ScaleList.Items.Add("Messiaen7");
            ScaleList.Items.Add("HarmonicMinor");
            ScaleList.Items.Add("MelodicMinorAscending");
            ScaleList.Items.Add("HungarianMinor");
            ScaleList.Items.Add("Octatonic");
            ScaleList.Items.Add("SuperLocrian");
            ScaleList.Items.Add("Hirajoshi");
            ScaleList.Items.Add("Kumoi");
            ScaleList.Items.Add("NeapolitanMajor");
            ScaleList.Items.Add("Bartok");
            ScaleList.Items.Add("Bhairav");
            ScaleList.Items.Add("LocrianMajor");
            ScaleList.Items.Add("AhirBhairav");
            ScaleList.Items.Add("Enigmatic");
            ScaleList.Items.Add("NeapolitanMinor");
            ScaleList.Items.Add("Pelog");
            ScaleList.Items.Add("Augmented2");
            ScaleList.Items.Add("Scriabin");
            ScaleList.Items.Add("HarmonicMajor");
            ScaleList.Items.Add("MelodicMinorDescending");
            ScaleList.Items.Add("RomanianMinor");
            ScaleList.Items.Add("Hindu");
            ScaleList.Items.Add("Iwato");
            ScaleList.Items.Add("MelodicMinor");
            ScaleList.Items.Add("Diminished2");
            ScaleList.Items.Add("Marva");
            ScaleList.Items.Add("MelodicMajor");
            ScaleList.Items.Add("Indian");
            ScaleList.Items.Add("Spanish");
            ScaleList.Items.Add("Prometheus");
            ScaleList.Items.Add("Diminished");
            ScaleList.Items.Add("Todi");
            ScaleList.Items.Add("LeadingWhole");
            ScaleList.Items.Add("Augmented");
            ScaleList.Items.Add("Purvi");
            ScaleList.Items.Add("Chinese");
            ScaleList.Items.Add("LydianMinor");
            ScaleList.Items.Add("Chromatic");
#endregion ScaleDropdown
            ScaleList.Parent = this;
            ScaleList.Location = new Point(850, 260);

            ScaleList.SelectedValueChanged += new System.EventHandler(ScaleChanged);
            RootNotes.SelectedValueChanged += new System.EventHandler(ScaleChanged);

        }
    }
}