using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuildingScreen : MonoBehaviour
{

    public GameObject ScreenContent;
    public GameObject DeckSection;
    public GameObject GridCardsList;
    public GameObject ReadyDecksList;
    public GameObject CardsInDeckList;
    public GameObject BackToMenu;
    public DeckBuilder BuilderScript;
    public ListOfDecksInCollection ListOfReadyMadeDecksScript;
    public CollectionBrowser CollectionBrowserScript;
    public CharacterSelectionTabs TabsScript;
    public bool ShowReducedQuantitiesInDeckBuilding = true;

    public static DeckBuildingScreen Instance;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
        HideScreen();
    }

    public void ShowScreenForCollectionBrowsing()
    {
        ScreenContent.SetActive(true);
        ReadyDecksList.SetActive(true);
        DeckSection.SetActive(false);
        CardsInDeckList.SetActive(false);
        BuilderScript.InDeckBuildingMode = false;
        GridCardsList.SetActive(false);
        BackToMenu.SetActive(true);
        // TabsScript.gameObject.SetActive(true);

        ListOfReadyMadeDecksScript.UpdateList();

        CollectionBrowserScript.AllCharactersTabs.gameObject.SetActive(true);
        CollectionBrowserScript.OneCharacterTabs.gameObject.SetActive(false);
        Canvas.ForceUpdateCanvases();

        CollectionBrowserScript.ShowCollectionForBrowsing();
    }

    public void ShowScreenForDeckBuilding()
    {
        ScreenContent.SetActive(true);
        ReadyDecksList.SetActive(false);
        CardsInDeckList.SetActive(true);
        DeckSection.SetActive(true);
        GridCardsList.SetActive(true);
        BackToMenu.SetActive(false);
        // TabsScript.gameObject.SetActive(true);

        CollectionBrowserScript.AllCharactersTabs.gameObject.SetActive(false);
        CollectionBrowserScript.OneCharacterTabs.gameObject.SetActive(true);
        Canvas.ForceUpdateCanvases();
        
    }

    public void BuildADeckFor(CharacterAsset asset)
    {
        ShowScreenForDeckBuilding();
        CollectionBrowserScript.ShowCollectionForDeckBuilding(asset);
        // DeckBuildingScreen.Instance.TabsScript.SetClassOnClassTab(asset);
        // DeckBuildingScreen.Instance.TabsScript.Set;
        BuilderScript.BuildADeckFor(asset);
    }

    public void HideScreen()
    {
        ScreenContent.SetActive(false);
        CollectionBrowserScript.ClearCreatedCards();
    }
}
