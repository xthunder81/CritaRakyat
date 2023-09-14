using System.Collections;
using System.Collections.Generic;
using DIALOGUE;
using UnityEngine;

public class TestDialogueFiles : MonoBehaviour
{
    [SerializeField] private TextAsset fileToRead = null;

    void Start()
    {

        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset(fileToRead);

        // for (int i = 0; i < lines.Count; i++)
        // {
        //     string line = lines[i];

        //     if (string.IsNullOrWhiteSpace(line))
        //         continue;

        //     Dialogue_Line dialogue_Line = DialogueParser.Parse(line);

        //     Debug.Log($"{dialogue_Line.speaker.name} as [{(dialogue_Line.speaker.castName != string.Empty ? dialogue_Line.speaker.castName : dialogue_Line.speaker.name)}] at {dialogue_Line.speaker.castPosition}");

        //     List<(int ln, string ex)> expr = dialogue_Line.speaker.castExpressions;

        //     for (int j = 0; j < expr.Count; j++)
        //     {
        //         Debug.Log($"[Layer[{expr[j].ln}] = '{expr[j].ex}']");
        //     }
        // }

        DialogueSystem.Instance.Say(lines);
    }
}