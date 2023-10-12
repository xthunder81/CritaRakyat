using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

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
    public void Say(string speech, string speakerName = "", bool additive = false)
    {
        StopSpeaking();

        if (additive)
            speechText.text = targerSpeech;

        speaking = StartCoroutine(Speaking(speech, additive, speakerName));
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }

        if (textArchitext != null && textArchitext.isTextConstructing)
		{
			textArchitext.Stop();
		}

        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }

    [HideInInspector] public bool isWaitingForUserInput = false;

    public string targerSpeech = "";
    Coroutine speaking = null;

    TextArchitext textArchitext = null;

    /// <summary>
    /// Fungsi Dialog
    /// </summary>
    IEnumerator Speaking(string speech, bool additive, string speaker = "")
    {
        speechPanel.SetActive(true);

        string additiveSpeech = additive ? speechText.text : "";
        targerSpeech = additiveSpeech + speech;

        TextArchitext textArchitect = new TextArchitext(speech, additiveSpeech);

        speakerNameText.text = CheckSpeaker(speaker);
        //speakerNamePanel.SetActive(speakerNameText.text != "");

        isWaitingForUserInput = false;

        while (textArchitect.isTextConstructing)
        {
            if (Input.GetKey(KeyCode.Space))
				textArchitect.skip = true;
            
            speechText.text = textArchitect.currentText;

            yield return new WaitForEndOfFrame();
        }

        // untuk menghalau teks dari selesai memperbarui
        speechText.text = textArchitect.currentText;

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
            retVal = (s.ToLower().Contains("narator")) ? "" : s;

        return retVal;
    }

    /// <summary>
    /// Menutup Speech Panel dan menghentikan semua dialogue percakapan
    /// </summary>
    public void CloseSay()
    {
        StopSpeaking();
        speechPanel.SetActive(false);
    }

    [System.Serializable]
    public class ELEMENTS
    {
        /// <summary>
        /// Panel Utama yang berisikan semua element dialog yang ada di UI
        /// </summary>

        public GameObject speechPanel;
        public GameObject speakerNamePanel;
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI speechText;
    }

    public GameObject speechPanel { get { return elements.speechPanel; } }
    public TextMeshProUGUI speakerNameText { get { return elements.speakerNameText; } }
    public TextMeshProUGUI speechText { get { return elements.speechText; } }
    public GameObject speakerNamePanel {get{return elements.speakerNamePanel;}}

}