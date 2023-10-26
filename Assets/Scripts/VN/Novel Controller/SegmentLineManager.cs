using System.Collections.Generic;
using UnityEngine;

public class SegmentLineManager : MonoBehaviour {
    
    public static Line Interpret (string rawLine)
    {
        return new Line(rawLine);
    }

    public class Line
    {
        public string speaker = "";

        public List<Segment> segments = new List<Segment>();
        public List<string> actions = new List<string>();

        public Line(string rawLine)
        {
            string[] dialogueAndAction = rawLine.Split('"');
            char actionSplitter = ' ';
            string[] actionArgument = dialogueAndAction.Length == 3 ? dialogueAndAction[2].Split(actionSplitter) : dialogueAndAction[0].Split(actionSplitter);
        
            if(dialogueAndAction.Length == 3)
            {
                speaker = dialogueAndAction[0] == "" ? NovelController.instance.cachedLastSpeaker : dialogueAndAction[0];

                if (speaker[speaker.Length-1] == ' ')
                    speaker = speaker.Remove(speaker.Length-1);
                
                NovelController.instance.cachedLastSpeaker = speaker;
            }

            else
            {}

        }

        void SegmentDialogue(string dialogue)
        {
            segments.Clear();

            string[] parts = dialogue.Split('{','}');

            for (int i = 0; i < parts.Length; i++)
            {
                Segment segment = new Segment();
                bool isOdd = i%2 != 0;

                if (isOdd)
                {
                    //perintah dan data yang dipisah menggunakan spasi
                    string[] commandData = parts[i].Split(' ');
                    switch(commandData[0])
                    {
                        case "c":
                            break;
                        
                         case "a":
                            break;
                        
                         case "w":
                            break;
                        
                         case "wa":
                            break;
                        
                    }
                }
            }
        }

        public class Segment
        {
            
        }
    }
}