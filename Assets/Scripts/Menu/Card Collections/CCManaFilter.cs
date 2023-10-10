using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCManaFilter : MonoBehaviour
{
    public Image[] Crystals;
    public Color32 HighlightedColor = Color.white;
    public Color32 UnactiveColor = Color.gray;

    private int currentIndex = -1;

    void Start() {
        RemoveCrystalFilter();
        currentIndex = -1;
        CardCollectionsScreen.Instance.collectionBrowser.ManaCost = currentIndex;
    }

    public void PressOnCrystal (int index) 
    {
        RemoveCrystalFilter();
        if (index != currentIndex)
        {
            currentIndex = index;
            Crystals[index].color = HighlightedColor;
        }
        else
        {
            currentIndex = -1;
        }

        CardCollectionsScreen.Instance.collectionBrowser.ManaCost = currentIndex;
    }

    public void RemoveCrystalFilter ()
    {
        foreach (Image image in Crystals) 
        {
            image.color = UnactiveColor;
        }
    }
}