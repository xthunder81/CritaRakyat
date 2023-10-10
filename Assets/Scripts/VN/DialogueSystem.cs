using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem instance;

    public ELEMENTS elements;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// mengatakan sesuatu dan ditampilkan pada kolom dialog
    /// </summary>
    public void Say(string speech, string speakerName = "")
    {
        StopSpeaking();

        speaking = StartCoroutine(Speaking(speech, false, speakerName));
    }

    /// <summary>
    /// mengatakan sesuatu untuk ditambahkan pada dialog yang sudah ada di kolom dialog
    /// </summary>
    public void AddSay(string speech, string speakerName = "")
    {
        StopSpeaking();

        speechText.text = targerSpeech;

        speaking = StartCoroutine(Speaking(speech, true, speakerName));
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }

        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }

    [HideInInspector] public bool isWaitingForUserInput = false;

    public string targerSpeech = "";
    Coroutine speaking = null;

    /// <summary>
    /// Fungsi Dialog
    /// </summary>
    IEnumerator Speaking(string speech, bool additive, string speaker = "")
    {
        speechPanel.SetActive(true);

        targerSpeech = speech;

        if (!additive)
            speechText.text = "";

        else
            targerSpeech = speechText.text + targerSpeech;

        speakerNameText.text = CheckSpeaker(speaker);
        
        isWaitingForUserInput = false;

        while (speechText.text != targerSpeech)
        {
            speechText.text += targerSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        // Text Selesai
        isWaitingForUserInput = true;

        while (isWaitingForUserInput)
            yield return null;

        StopSpeaking();
    }

    //untuk mengetahui nama pembicara
    string CheckSpeaker(string s)
    {
        string retVal = speakerNameText.text;

        if (s != speakerNameText.text && s != "")
            retVal = (s.ToLower().Contains("narrator")) ? "" : s;

        return retVal;
    }

    /// <summary>
    /// Menutup Speech Panel dan menghentikan semua dialogue percakapan
    /// </summary>
    public void CloseSay()
	{
		StopSpeaking ();
		speechPanel.SetActive (false);
	}

    [System.Serializable]
    public class ELEMENTS
    {
        /// <summary>
        /// Panel Utama yang berisikan semua element dialog yang ada di UI
        /// </summary>

        public GameObject speechPanel;
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI speechText;
    }

    public GameObject speechPanel { get { return elements.speechPanel; } }
    public TextMeshProUGUI speakerNameText { get { return elements.speakerNameText; } }
    public TextMeshProUGUI speechText { get { return elements.speechText; } }

}