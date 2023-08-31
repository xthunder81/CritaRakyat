using UnityEngine;
using TMPro;
using DIALOGUE;

[System.Serializable]
public class DialogueContainer
{
    [Header("Game Object Reference")]
    public GameObject Root;

    [Header("Text Reference")]
    public NameContainer nameContainer;
    public TextMeshProUGUI dialogText;
}