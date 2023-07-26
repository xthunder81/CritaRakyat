using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCollectionsScreen : MonoBehaviour
{
    public GameObject ScreenContent;
    public CollectionBrowser_2 collectionBrowser;
    public CharacterSelectionTabs TabsScript;

    // public CardsThatYouDoNotHaveToggle CardsThatYouDoNotHaveToggleScript;
    // public ManaFilter ManaFilterSctipt;

    public static CardCollectionsScreen Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        HideScreen();
    }

    public void ShowScreenForCollectionBrowsing()
    {
        ScreenContent.SetActive(true);
        // TabsScript.gameObject.SetActive(true);
        
        collectionBrowser.AllCharactersTabs.gameObject.SetActive(true);
        collectionBrowser.OneCharacterTabs.gameObject.SetActive(false);
        Canvas.ForceUpdateCanvases();

        collectionBrowser.ShowCollectionForBrowsing();
    }

    public void HideScreen()
    {
        ScreenContent.SetActive(false);
        collectionBrowser.ClearCreatedCards();
    }
}
