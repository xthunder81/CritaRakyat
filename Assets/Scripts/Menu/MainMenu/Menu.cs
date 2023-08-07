using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Main Button Reference")]
    public Button HomeMenu;
    public Button PertandinganMenu;
    public Button KartuMenu;
    public Button TokoMenu;
    public Button KeluarMenu;

    [Header("Sub Button Reference")]
    public GameObject SubPertandinganMenu;
    public GameObject SubKartuMenu; 

    public void TombolHome()
    {
        
    }

    public void TombolPertandingan()
    {
        

    }

    public void TombolKartu()
    {

    }

    public void TombolToko()
    {

    }

    public void TombolKeluar()
    {
        Application.Quit();
    }
}