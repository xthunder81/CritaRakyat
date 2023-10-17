using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Main Button Reference")]
    public Button HomeMenu;
    public Button PertandinganMenu;
    public Button DekKartuMenu;
    public Button KartuMenu;
    public Button TokoMenu;
    public Button KeluarMenu;

    [Header("Hame Object Reference")]
    public GameObject HalamanUtama;
    public GameObject SubPertandinganMenu;
    public GameObject SubKartuMenu;

    [Header("Audio Button Reference")]
    public AudioSource audioButton;

    public void TombolHome()
    {
        
        SubPertandinganMenu.SetActive(false);
        SubKartuMenu.SetActive(false);
        audioButton.Play();
    }

    public void TombolPertandingan()
    {

        SubPertandinganMenu.SetActive(true);
        audioButton.Play();
    }


    public void MenuPengaturanDeck()
    {
        HalamanUtama.SetActive(false);
        DeckBuildingScreen.Instance.ShowScreenForCollectionBrowsing();
        audioButton.Play();
    }

    public void MenuGaleriKartu()
    {
        HalamanUtama.SetActive(false);
        CardCollectionsScreen.Instance.ShowScreenForCollectionBrowsing();
        audioButton.Play();
    }

    public void TombolToko()
    {
        HalamanUtama.SetActive(false);
        ShopManager.Instance.ShowScreen();
        audioButton.Play();
    }

    public void TombolKeluar()
    {
        Application.Quit();
        audioButton.Play();
    }
}