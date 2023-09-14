using UnityEngine;
using TMPro;
using DIALOGUE;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    
    public DialogueContainer dialogueContainer = new DialogueContainer();

    private ConversationManager conversationManager;

    private TextArchitect architect;

    public static DialogueSystem Instance {get; private set;}

    public delegate void DialogueSystemEvent();
    public event DialogueSystemEvent onUserPrompt_Next;

    public bool conversationIsRunning => conversationManager.isRunning;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }   
        else
            DestroyImmediate(gameObject);
    }


    bool _initialized = false;
    private void Initialize()
    {
        if (_initialized)
            return;
        
        architect = new TextArchitect(dialogueContainer.dialogText);
        conversationManager = new ConversationManager(architect);
    }

    public void OnUserPrompt_Next()
    {
        onUserPrompt_Next?.Invoke();
    }

    // Show or Hide Speaker Name
    public void ShowSpeakerName(string speakerName = "")
    {
        if (speakerName.ToLower() != "narator")
            dialogueContainer.nameContainer.Show(speakerName);
        else
            dialogueContainer.nameContainer.Hide();
    }

    public void HideSpeakerName() => dialogueContainer.nameContainer.Hide();


    public void Say (string speaker, string dialogue)
    {
        List<string> conversation = new List<string>() { $"{speaker} \"{dialogue}\""};
        Say(conversation);
    }

    public void Say (List<string> conversation)
    {
        conversationManager.StartConversation(conversation);
    }
}