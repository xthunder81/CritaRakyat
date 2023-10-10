using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DIALOGUE
{
    public class DL_Dialogue_Data
    {
        public List<Dialogue_Segment> segments;
        private const string segmentIdentificationPattern = @"\{[ca]\}|\{w[ca]\s\d*\.?\d*\}";

        public bool hasDialogue => segments.Count > 0;

        public DL_Dialogue_Data(string rawDialogue)
        {
            segments = RipSegments(rawDialogue);
        }

        public List<Dialogue_Segment> RipSegments(string rawDialogue)
        {
            List<Dialogue_Segment> segments = new List<Dialogue_Segment>();
            MatchCollection match = Regex.Matches(rawDialogue, segmentIdentificationPattern);

            int lastIndex = 0;
            
            // Find First Segment on file
            Dialogue_Segment segment = new Dialogue_Segment();
            segment.dialogue = (match.Count == 0 ? rawDialogue : rawDialogue.Substring(0, match[0].Index));
            segment.startSignal = Dialogue_Segment.StartSignal.NONE;
            segment.delaySignal = 0;
            segments.Add(segment);

            if (match.Count == 0)
                return segments;
            
            else
                lastIndex = match[0].Index;
            
            for (int i = 0; i < match.Count; i++)
            {
                Match matches = match[i];
                segment = new Dialogue_Segment();

                // Get Start Signal for Segment
                string matchSignal = matches.Value;
                matchSignal = matchSignal.Substring(1, matches.Length -2);
                string[] splitSignal = matchSignal.Split(' ');

                segment.startSignal = (Dialogue_Segment.StartSignal) Enum.Parse(typeof(Dialogue_Segment.StartSignal), splitSignal[0].ToUpper());

                // Get Delay Signal
                if (splitSignal.Length > 1)
                    float.TryParse(splitSignal[1], out segment.delaySignal);
                
                // Get Dialogue for Segment
                int nextIndex = i + 1 < match.Count ? match[i + 1].Index : rawDialogue.Length;
                segment.dialogue = rawDialogue.Substring(lastIndex + matches.Length, nextIndex - (lastIndex + matches.Length));
                lastIndex = nextIndex;

                segments.Add(segment);
            }

            return segments;
        }

        public struct Dialogue_Segment
        {
            public string dialogue;
            public StartSignal startSignal;
            public float delaySignal;

            public enum StartSignal {NONE, C, A, WA, WC}

            public bool appendText => (startSignal == StartSignal.A || startSignal == StartSignal.WC);
        }
    }
}