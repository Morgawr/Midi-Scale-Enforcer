using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using NAudio.Midi;

namespace Midi_Scale_Enforcer {

    public static class Scale {

#region scales
        // Taken from Overtone scale list :) Thanks overtone!
        // https://github.com/overtone/overtone/blob/master/src/overtone/music/pitch.clj#L234
        public static int[] Major = {2, 2, 1, 2, 2, 2, 1};
        public static int[] Chromatic = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        public static int[] Dorian = {2, 1, 2, 2, 2, 1, 2};
        public static int[] Phrygian = {1, 2, 2, 2, 1, 2, 2,};
        public static int[] Lydian = {2, 2, 2, 1, 2, 2, 1};
        public static int[] Mixolydian = {2, 2, 1, 2, 2, 1, 2};
        public static int[] Minor = {2, 1, 2, 2, 1, 2, 2};
        public static int[] Locrian = {1, 2, 2, 1, 2, 2, 2};
        public static int[] HexMajor6 = {2, 2, 1, 2, 2, 3};
        public static int[] HexDorian = {2, 1, 2, 2, 3, 2};
        public static int[] HexPhrygian = {1, 2, 2, 3, 2, 2};
        public static int[] HexMajor7 = {2, 2, 3, 2, 2, 1};
        public static int[] HexSus = {2, 3, 2, 2, 1, 2};
        public static int[] HexAeolian = {3, 2, 2, 1, 2, 2};
        public static int[] MinorPentatonic = {3, 2, 2, 3, 2};
        public static int[] MajorPentatonic = {2, 2, 3, 2, 3}; 
        public static int[] Egyptian = {2, 3, 2, 3, 2}; 
        public static int[] Jiao = {3, 2, 3, 2, 2}; 
        public static int[] Pentatonic = {2, 3, 2, 2, 3};
        public static int[] WholeTone = {2, 2, 2, 2, 2, 2};
        public static int[] HarmonicMinor = {2, 1, 2, 2, 1, 3, 1};
        public static int[] MelodicMinorAscending = {2, 1, 2, 2, 2, 2, 1};
        public static int[] HungarianMinor = {2, 1, 3, 1, 1, 3, 1};
        public static int[] Octatonic = {2, 1, 2, 1, 2, 1, 2, 1};
        public static int[] Messiaen2 = {1, 2, 1, 2, 1, 2, 1, 2};
        public static int[] Messiaen3 = {2, 1, 1, 2, 1, 1, 2, 1, 1};
        public static int[] Messiaen4 = {1, 1, 3, 1, 1, 1, 3, 1};
        public static int[] Messiaen5 = {1, 4, 1, 1, 4, 1};
        public static int[] Messiaen6 = {2, 2, 1, 1, 2, 2, 1, 1};
        public static int[] Messiaen7 = {1, 1, 1, 2, 1, 1, 1, 1, 2, 1};
        public static int[] SuperLocrian = {1, 2, 1, 2, 2, 2, 2};
        public static int[] Hirajoshi = {2, 1, 4, 1, 4};
        public static int[] Kumoi = {2, 1, 4, 2, 3};
        public static int[] NeapolitanMajor = {1, 2, 2, 2, 2, 2, 1};
        public static int[] Bartok = {2, 2, 1, 2, 1, 2, 2};
        public static int[] Bhairav = {1, 3, 1, 2, 1, 3, 1};
        public static int[] LocrianMajor = {2, 2, 1, 1, 2, 2, 2};
        public static int[] AhirBhairav = {1, 3, 1, 2, 2, 1, 2};
        public static int[] Enigmatic = {1, 3, 2, 2, 2, 1, 1};
        public static int[] NeapolitanMinor = {1, 2, 2, 2, 1, 3, 1};
        public static int[] Pelog = {1, 2, 4, 1, 4};
        public static int[] Augmented2 = {1, 3, 1, 3, 1, 3};
        public static int[] Scriabin = {1, 3, 3, 2, 3};
        public static int[] HarmonicMajor = {2, 2, 1, 2, 1, 3, 1};
        public static int[] MelodicMinorDescending = {2, 1, 2, 2, 1, 2, 2};
        public static int[] RomanianMinor = {2, 1, 3, 1, 2, 1, 2};
        public static int[] Hindu = {2, 2, 1, 2, 1, 2, 2};
        public static int[] Iwato = {1, 4, 1, 4, 2};
        public static int[] MelodicMinor = {2, 1, 2, 2, 2, 2, 1};
        public static int[] Diminished2 = {2, 1, 2, 1, 2, 1, 2, 1};
        public static int[] Marva = {1, 3, 2, 1, 2, 2, 1};
        public static int[] MelodicMajor = {2, 2, 1, 2, 1, 2, 2};
        public static int[] Indian = {4, 1, 2, 3, 2};
        public static int[] Spanish = {1, 3, 1, 2, 1, 2, 2};
        public static int[] Prometheus = {2, 2, 2, 5, 1};
        public static int[] Diminished = {1, 2, 1, 2, 1, 2, 1, 2};
        public static int[] Todi = {1, 2, 3, 1, 1, 3, 1};
        public static int[] LeadingWhole = {2, 2, 2, 2, 2, 1, 1};
        public static int[] Augmented = {3, 1, 3, 1, 3, 1};
        public static int[] Purvi = {1, 3, 2, 1, 1, 3, 1};
        public static int[] Chinese = {4, 2, 1, 4, 1};
        public static int[] LydianMinor = {2, 2, 2, 1, 2, 2};
#endregion scales

        private static List<string> NoteSeries = new List<string>{"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};

        public static int NoteNumberFromName(String noteName) {
            for(var i = 0; i < NoteSeries.Count; i++) {
                if(noteName == NoteSeries[i])
                    return i;
            }
            return -1;
        }

        public static string NoteNameFromNumber(int number) {
            return NoteSeries[number % 12];
        }

        public static bool IsInScale(int[] scale, String note) {
            var noteNumber = NoteNumberFromName(Regex.Replace(note, @"[\d-]", string.Empty));
            return scale.Contains(noteNumber);
        }

        public static int[] InitScale(int[] scale, string root) {
            var rootNumber = NoteNumberFromName(root);
            var notes = new List<int>();
            notes.Add(rootNumber);
            foreach(var i in scale) {
                rootNumber = (rootNumber + i) % 12;
                notes.Add(rootNumber);
            }
            Console.Write("Scale filtered on: ");
            foreach(var i in notes) {
                Console.Write(NoteNameFromNumber(i) + " ");
            }
            Console.WriteLine("");
            return notes.ToArray();
        }
    }

    class Program {
        static int midiInDevice = -1;
        static int midiOutDevice = -1;
        static MidiIn midiIn;
        static MidiOut midiOut;

        static int[] scaleProgression;

        static void FilterNote(MidiEvent e) {
            var shouldSend = true;

            if(e is NoteEvent && ((NoteEvent)e).CommandCode == MidiCommandCode.NoteOn)
                shouldSend = Scale.IsInScale(scaleProgression, ((NoteEvent)e).NoteName);

            if(shouldSend)
                midiOut.Send(e.GetAsShortMessage());
            else 
                Console.WriteLine(String.Format("Event {0} was filtered out.", e));
        }

        static void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e) {
            Console.WriteLine(String.Format("ERR Time {0} Message 0x{1:X8} Event {2}", e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        static void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e) {
            FilterNote(e.MidiEvent);
        }

        static void PrintUsageAndMidiDevices() {
            Console.WriteLine("This program needs to be run as such:");
            Console.WriteLine("MidiScaleEnforcer.exe <midi-in> <midi-out> <scale> <root note>");
            Console.WriteLine("Run 'MidScaleEnforcer.exe scales' for a list of available scales.");
            Console.WriteLine("Midi IN devices:");
            for(var i = 0; i < MidiIn.NumberOfDevices; i++) {
                Console.WriteLine("\t" + MidiIn.DeviceInfo(i).ProductName);
            }
            Console.WriteLine("Midi OUT devices:");
            for(var i = 0; i < MidiOut.NumberOfDevices; i++) {
                Console.WriteLine("\t" + MidiOut.DeviceInfo(i).ProductName);
            }
        }

#region ScaleList
        static void PrintScaleList() {
            Console.WriteLine("The following scales are available to filter on:");
            Console.WriteLine("- Major");
            Console.WriteLine("- Ionian");
            Console.WriteLine("- Phrygian");
            Console.WriteLine("- Lydian");
            Console.WriteLine("- Mixolydian");
            Console.WriteLine("- Minor");
            Console.WriteLine("- Aeolian");
            Console.WriteLine("- Locrian");
            Console.WriteLine("- HexMajor6");
            Console.WriteLine("- HexDorian");
            Console.WriteLine("- HexPhrygian");
            Console.WriteLine("- HexMajor7");
            Console.WriteLine("- HexSus");
            Console.WriteLine("- HexAeolian");
            Console.WriteLine("- MinorPentatonic");
            Console.WriteLine("- Yu");
            Console.WriteLine("- MajorPentatonic");
            Console.WriteLine("- Gong");
            Console.WriteLine("- Egyptian");
            Console.WriteLine("- Shang");
            Console.WriteLine("- Jiao");
            Console.WriteLine("- Pentatonic");
            Console.WriteLine("- Zhi");
            Console.WriteLine("- Ritusen");
            Console.WriteLine("- WholeTone");
            Console.WriteLine("- Whole");
            Console.WriteLine("- Messiaen1");
            Console.WriteLine("- Messiaen2");
            Console.WriteLine("- Messiaen3");
            Console.WriteLine("- Messiaen4");
            Console.WriteLine("- Messiaen5");
            Console.WriteLine("- Messiaen6");
            Console.WriteLine("- Messiaen7");
            Console.WriteLine("- HarmonicMinor");
            Console.WriteLine("- MelodicMinorAscending");
            Console.WriteLine("- HungarianMinor");
            Console.WriteLine("- Octatonic");
            Console.WriteLine("- SuperLocrian");
            Console.WriteLine("- Hirajoshi");
            Console.WriteLine("- Kumoi");
            Console.WriteLine("- NeapolitanMajor");
            Console.WriteLine("- Bartok");
            Console.WriteLine("- Bhairav");
            Console.WriteLine("- LocrianMajor");
            Console.WriteLine("- AhirBhairav");
            Console.WriteLine("- Enigmatic");
            Console.WriteLine("- NeapolitanMinor");
            Console.WriteLine("- Pelog");
            Console.WriteLine("- Augmented2");
            Console.WriteLine("- Scriabin");
            Console.WriteLine("- HarmonicMajor");
            Console.WriteLine("- MelodicMinorDescending");
            Console.WriteLine("- RomanianMinor");
            Console.WriteLine("- Hindu");
            Console.WriteLine("- Iwato");
            Console.WriteLine("- MelodicMinor");
            Console.WriteLine("- Diminished2");
            Console.WriteLine("- Marva");
            Console.WriteLine("- MelodicMajor");
            Console.WriteLine("- Indian");
            Console.WriteLine("- Spanish");
            Console.WriteLine("- Prometheus");
            Console.WriteLine("- Diminished");
            Console.WriteLine("- Todi");
            Console.WriteLine("- LeadingWhole");
            Console.WriteLine("- Augmented");
            Console.WriteLine("- Purvi");
            Console.WriteLine("- Chinese");
            Console.WriteLine("- LydianMinor");
            Console.WriteLine("- Chromatic");
        }

#endregion ScaleList

#region ScaleSelector
        static int[]GetScaleFromString(string scale) {
            switch(scale.ToLower()) {
                case "major":
                case "ionian":
                    return Scale.Major;
                case "phrygian":
                    return Scale.Phrygian;
                case "lydian":
                    return Scale.Lydian;
                case "mixolydian":
                    return Scale.Mixolydian;
                case "minor":
                case "aeolian":
                    return Scale.Minor;
                case "locrian":
                    return Scale.Locrian;
                case "hexmajor6":
                    return Scale.HexMajor6;
                case "hexdorian":
                    return Scale.HexDorian;
                case "hexphrygian":
                    return Scale.HexPhrygian;
                case "hexmajor7":
                    return Scale.HexMajor7;
                case "hexsus":
                    return Scale.HexSus;
                case "hexaeolian":
                    return Scale.HexAeolian;
                case "minorpentatonic":
                case "yu":
                    return Scale.MinorPentatonic;
                case "majorpentatonic":
                case "gong":
                    return Scale.MajorPentatonic;
                case "egyptian":
                case "shang":
                    return Scale.Egyptian;
                case "jiao":
                    return Scale.Jiao;
                case "pentatonic":
                case "zhi":
                case "ritusen":
                    return Scale.Pentatonic;
                case "wholetone":
                case "whole":
                case "messiaen1":
                    return Scale.WholeTone;
                case "harmonicminor":
                    return Scale.HarmonicMinor;
                case "melodicminorascending":
                    return Scale.MelodicMinorAscending;
                case "hungarianminor":
                    return Scale.HungarianMinor;
                case "octatonic":
                    return Scale.Octatonic;
                case "messiaen2":
                    return Scale.Messiaen2;
                case "messiaen3":
                    return Scale.Messiaen3;
                case "messiaen4":
                    return Scale.Messiaen4;
                case "messiaen5":
                    return Scale.Messiaen5;
                case "messiaen6":
                    return Scale.Messiaen6;
                case "messiaen7":
                    return Scale.Messiaen7;
                case "superlocrian":
                    return Scale.SuperLocrian;
                case "hirajoshi":
                    return Scale.Hirajoshi;
                case "kumoi":
                    return Scale.Kumoi;
                case "neapolitanmajor":
                    return Scale.NeapolitanMajor;
                case "bartok":
                    return Scale.Bartok;
                case "bhairav":
                    return Scale.Bhairav;
                case "locrianmajor":
                    return Scale.LocrianMajor;
                case "ahirbhairav":
                    return Scale.AhirBhairav;
                case "enigmatic":
                    return Scale.Enigmatic;
                case "neapolitanminor":
                    return Scale.NeapolitanMinor;
                case "pelog":
                    return Scale.Pelog;
                case "augmented2":
                    return Scale.Augmented2;
                case "scriabin":
                    return Scale.Scriabin;
                case "harmonicmajor":
                    return Scale.HarmonicMajor;
                case "melodicminordescending":
                    return Scale.MelodicMinorDescending;
                case "romanianminor":
                    return Scale.RomanianMinor;
                case "hindu":
                    return Scale.Hindu;
                case "iwato":
                    return Scale.Iwato;
                case "melodicminor":
                    return Scale.MelodicMinor;
                case "diminished2":
                    return Scale.Diminished2;
                case "marva":
                    return Scale.Marva;
                case "melodicmajor":
                    return Scale.MelodicMajor;
                case "indian":
                    return Scale.Indian;
                case "spanish":
                    return Scale.Spanish;
                case "prometheus":
                    return Scale.Prometheus;
                case "diminished":
                    return Scale.Diminished;
                case "todi":
                    return Scale.Todi;
                case "leadingwhole":
                    return Scale.LeadingWhole;
                case "augmented":
                    return Scale.Augmented;
                case "purvi":
                    return Scale.Purvi;
                case "chinese":
                    return Scale.Chinese;
                case "lydianminor":
                    return Scale.LydianMinor;
                case "chromatic":
                default:
                    return Scale.Chromatic;
            }
        }

#endregion ScaleSelector

        static void Main(string[] args) {
            if(args.Count() == 2 && args[1] == "scales") {
                PrintScaleList();
                return;
            }
            if(args.Count() < 4) {
                PrintUsageAndMidiDevices();
                return;
            }

            var midiInName = args[1];
            var midiOutName = args[2];
            var scale = args[3];
            var rootNote = args[4].ToUpper();

            for (var i = 0; i < MidiIn.NumberOfDevices; i++) {
                if(MidiIn.DeviceInfo(i).ProductName == midiInName)
                    midiInDevice = i;
            }
            for (var i = 0; i < MidiOut.NumberOfDevices; i++) {
                if(MidiOut.DeviceInfo(i).ProductName == midiOutName)
                    midiOutDevice = i;
            }

            if(midiInDevice == -1) {
                Console.WriteLine("[IN] Device not found.");
                return;
            }
            if(midiOutDevice == -1) {
                Console.WriteLine("[OUT] Device not found.");
                return;
            }

            scaleProgression = Scale.InitScale(GetScaleFromString(scale), rootNote);

            midiIn = new MidiIn(midiInDevice);
            Console.WriteLine("[IN] Connected to " + MidiIn.DeviceInfo(midiInDevice).ProductName);
            midiOut = new MidiOut(midiOutDevice);
            Console.WriteLine("[Out] Connected to " + MidiOut.DeviceInfo(midiOutDevice).ProductName);
            midiIn.MessageReceived += midiIn_MessageReceived;
            midiIn.ErrorReceived += midiIn_ErrorReceived;
            midiIn.Start();
            while(true);
        }
    }
}
