using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    
    public DialogueContainer dialogueContainer = new DialogueContainer();

    public static DialogueSystem Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }


}