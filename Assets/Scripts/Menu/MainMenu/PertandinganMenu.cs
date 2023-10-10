using UnityEngine;
using UnityEngine.UI;

public class PertandinganMenu : MonoBehaviour 
{
    [Header("Button Reference")]
    public Button PVSA;
    public Button AVSA;

    [Header("Audio Reference")]
    public AudioSource audioSource;

    [Header("GameObejct Reference")]
    public GameObject menuUtama;
    public GameObject PlayerButton;
    public GameObject AIButton;

    public void PVSAScene ()
    {
        audioSource.Play();
        menuUtama.SetActive(false);
        DeckSelectionScreen.Instance.ShowScreen();
        PlayerButton.SetActive(true);
        AIButton.SetActive(false);
    }

    public void AVSAScene ()
    {
        audioSource.Play();
        menuUtama.SetActive(false);
        DeckSelectionScreen.Instance.ShowScreen();
        PlayerButton.SetActive(false);
        AIButton.SetActive(true);        
    }
}
