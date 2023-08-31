using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DIALOGUE
{
    public class ConversationManager
    {
        private Coroutine process = null;
        private DialogueSystem dialogueSystem => DialogueSystem.Instance;

        public bool isRunning => process != null;

        private TextArchitect architect = null;

        private bool userPrompt = false;

        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem.onUserPrompt_Next += OnUserPrompt_Next;
        }

        private void OnUserPrompt_Next()
        {
            userPrompt = true;
        }

        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation()
        {
            if (!isRunning)
            {
                return;
            }

            dialogueSystem.StopCoroutine(process);
            process = null;
        }

        IEnumerator RunningConversation(List<string> conversation)
        {
            for (int i = 0; i < conversation.Count; i++)
            {
                // bypass blank lines
                if (string.IsNullOrWhiteSpace(conversation[i]))
                {
                    continue;
                }
                Dialogue_Line line = DialogueParser.Parse(conversation[i]);

                if (line.hasDialogue)
                {
                    yield return Line_RunDialogue(line);
                }

                if (line.hasCommand)
                {
                    yield return Line_RunCommands(line);
                }

                //yield return new WaitForSeconds(1);
            }
        }

        IEnumerator Line_RunDialogue(Dialogue_Line line)
        {
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker.displayName);



            // Build Dialogue
            yield return BuildLineSegments(line.dialogue);

            // Wait User Input
            yield return WaitForUserInput();
        }

        IEnumerator Line_RunCommands(Dialogue_Line line)
        {
            Debug.Log(line.command);
            yield return null;
        }

        IEnumerator BuildLineSegments(DL_Dialogue_Data line)
        {
            for (int i = 0; i < line.segments.Count; i++)
            {
                DL_Dialogue_Data.Dialogue_Segment segment = line.segments[i];

                yield return WaitForDIalogueSegmentSignalToBeTriggered(segment);
                yield return BuildDialogue(segment.dialogue, segment.appendText);
            }
        }

        IEnumerator WaitForDIalogueSegmentSignalToBeTriggered(DL_Dialogue_Data.Dialogue_Segment segment)
        {
            switch (segment.startSignal)
            {
                case DL_Dialogue_Data.Dialogue_Segment.StartSignal.C:
                case DL_Dialogue_Data.Dialogue_Segment.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DL_Dialogue_Data.Dialogue_Segment.StartSignal.WC:
                case DL_Dialogue_Data.Dialogue_Segment.StartSignal.WA:
                    yield return new WaitForSeconds(segment.delaySignal);
                    break;
                default:
                    break;                
            }
        }

        IEnumerator BuildDialogue(string dialogue, bool append = false)
        {
            // Build Dialogue
            if (!append)
                architect.Build(dialogue);
            else
                architect.Append(dialogue);

            // Wait Dialogue to complete
            while (architect.isBuilding)
            {
                if (userPrompt)
                {
                    if (!architect.increaseSpeed)
                        architect.increaseSpeed = true;
                    else
                        architect.ForceComplete();

                    userPrompt = false;
                }
                yield return null;
            }
        }

        IEnumerator WaitForUserInput()
        {
            while (!userPrompt)
                yield return null;

            userPrompt = false;
        }
    }
}