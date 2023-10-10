using System.Text.RegularExpressions;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueParser
    {
        public const string commandRegexPattern = @"\w*[^\s]\(";

        public static Dialogue_Line Parse(string ramLine)
        {
            Debug.Log($"Parsing Line - '{ramLine}'");

            (string speaker, string dialogue, string command) = RipContent(ramLine);

            Debug.Log($"Speaker = '{speaker}' \nDialogue = '{dialogue}' \nCommands = '{command}'");

            return new Dialogue_Line(speaker, dialogue, command);
        }

        private static (string, string, string) RipContent(string ramLine)
        {
            string speaker = "", dialogue = "", command = "";

            int dialogueStart = -1;
            int dialogueEnd = -1;
            bool isEscaped = false;

            for (int i = 0; i < ramLine.Length; i++)
            {
                char current = ramLine[i];
                if (current == '\\')
                {
                    isEscaped = !isEscaped;
                }

                else if (current == '"' && !isEscaped)
                {
                    if (dialogueStart == -1)
                    {
                        dialogueStart = i;
                    }

                    else if (dialogueEnd == -1)
                    {
                        dialogueEnd = i;
                    }
                }
                else
                {
                    isEscaped = false;
                }
            }

            // Debug.Log(ramLine.Substring(dialogueStart + 1, (dialogueEnd - dialogueStart) - 1));

            // Identified Command Pattern
            Regex commandRegex = new Regex(commandRegexPattern);

            Match match = commandRegex.Match(ramLine);

            int commandStart = -1;
            if (match.Success)
            {
                commandStart = match.Index;

                if (dialogueStart == -1 && dialogueEnd == -1)
                    return ("", "", ramLine.Trim());
            }

            // Figure is Dialogue or Commands
            if (dialogueStart != -1 && dialogueEnd != -1 && (commandStart == -1 || commandStart > dialogueEnd))
            {
                // Detect Valid Dialogue
                speaker = ramLine.Substring(0, dialogueStart).Trim();
                dialogue = ramLine.Substring(dialogueStart + 1, dialogueEnd - dialogueStart - 1).Replace("\\\"", "\"");

                if (commandStart != -1)
                {
                    command = ramLine.Substring(commandStart).Trim();
                }
            }

            else if (commandStart != -1 && dialogueStart > commandStart)
            {
                command = ramLine;
            }

            else
            {
                speaker = ramLine;
            }

            return (speaker, dialogue, command);
        }
    }
}