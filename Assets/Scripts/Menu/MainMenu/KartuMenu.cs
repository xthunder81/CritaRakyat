using UnityEngine;
using UnityEngine.UI;

public class KartuMenu : MonoBehaviour 
{
    [Header("Button Reference")]
    public Button PengaturanDeck;
    public Button GaleriKartu;

    [Header("Audio Button Reference")]
    public AudioSource audioButton;

    [Header("GameObject Reference")]
    public GameObject halamanAwal;

    public void MenuPengaturanDeck()
    {
        halamanAwal.SetActive(false);
        audioButton.Play();
    }

    public void MenuGaleriKartu()
    {
        halamanAwal.SetActive(false);
        audioButton.Play();
    }
}