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
        SubKartuMenu.SetActive(false);
        audioButton.Play();
    }


    public void TombolKartu()
    {
        SubPertandinganMenu.SetActive(false);
        SubKartuMenu.SetActive(true);
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