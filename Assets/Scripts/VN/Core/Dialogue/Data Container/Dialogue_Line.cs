using UnityEngine;

namespace DIALOGUE
{
    public class Dialogue_Line
    {
        public Dl_Speaker_Data speaker;
        public DL_Dialogue_Data dialogue;
        public string command;

        // check variable Empty Or Not
        public bool hasSpeaker => speaker != null;//speaker != string.Empty;
        public bool hasDialogue => dialogue.hasDialogue; //dialogue != string.Empty;
        public bool hasCommand => command != string.Empty;
    
        public Dialogue_Line(string speaker, string dialogue, string command)
        {
            this.speaker = (string.IsNullOrWhiteSpace(speaker) ? null : new Dl_Speaker_Data(speaker));
            this.dialogue = new DL_Dialogue_Data(dialogue); //dialogue;
            this.command = command;
        }
    }
}