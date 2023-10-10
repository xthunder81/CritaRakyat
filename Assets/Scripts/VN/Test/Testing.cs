using UnityEngine;

public class Testing : MonoBehaviour {
    
    DialogueSystem dialogue;

    void Start ()
    {
        dialogue = DialogueSystem.instance;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartSpeak();
    }

    public string[] s = new string[]
    {
        "Hai, bagaimana kabarmu Deka? :Desi",
        "Baik, cuaca hari ini sangat bagus :Deka",
        "kalau boleh berkata jujur, aku lega hari ini tidak turun salju"
    };

    int index = 0;

    void Say (string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say (speech, speaker);
    }

    public void StartSpeak ()
    {
        if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
        {
            if (index >= s.Length)
                return;
            
            Say (s[index]);
            index++;
        }
    }
}