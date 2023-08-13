using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueContainer
{
    [Header("Game Object Reference")]
    public GameObject Root;

    [Header("Text Reference")]
    public TextMeshProUGUI namaCharText;
    public TextMeshProUGUI dialogText;
}