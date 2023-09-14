using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCToggle : MonoBehaviour
{
    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void ccValueChange()
    {
        CardCollectionsScreen.Instance.collectionBrowser.ShowingCardsPlayerDoesNotOwn = toggle.isOn;
    }

    public void ccSetValue (bool val) {
        if (toggle!=null)
            toggle.isOn = val;
    }
}