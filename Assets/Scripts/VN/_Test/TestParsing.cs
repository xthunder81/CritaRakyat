using System.Collections.Generic;
using System.IO;
using DIALOGUE;
using UnityEngine;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        
        void Start()
        {
            // string line = "Speaker \"Terjadi \\\"Percakapan Dialog \\\" di Sini!\" Command(argumen)";

            // DialogueParser.Parse(line);

            SendFileToText();
        }

        void SendFileToText()
        {
            List<string> lines = FileManager.ReadTextAsset("testFile");

            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    continue;
                }
                Dialogue_Line dialogue_Line = DialogueParser.Parse(line);
            }
        }
    }
}