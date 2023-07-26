using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ShowCard : MonoBehaviour
{
    public TextMeshProUGUI QuantityText;
    private float InitialScale;
    private float scaleFactor = 2f;
    private CardAsset cardAsset;

    void Awake()
    {
        InitialScale = transform.localScale.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            OnLeftClick();
    }

    public void SetCardAsset(CardAsset asset) { cardAsset = asset; }

    void OnMouseDown()
    {
        CardAsset asset = GetComponent<OneCardManager>().cardAsset;
        if (asset== null)
            return;
            
    }
    void OnMouseEnter()
    {        
        
        if (DetailScreenCard.Instance.Visible)
            return;

        transform.DOScale(InitialScale*scaleFactor, 0.5f);
    }

    void OnMouseExit()
    {
        // if you remove / comment out this if statement, when the crefting screen is pened, when the cursor exits the card it will return to original scale.
        // if (CraftingScreen.Instance.Visible)
            //return;

        transform.DOScale(InitialScale, 0.5f);
    }

    // Check for Left-Click
    void OnLeftClick()
    {
        if (DetailScreenCard.Instance.Visible)
            return;
        
        // Cast a ray from the mouse
        // cursors position
        Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;

        // See if the ray collided with an object
        if (Physics.Raycast(clickPoint, out hitPoint))
        {
            // Make sure this object was the
            // one that received the right-click
            if (hitPoint.collider == this.GetComponent<Collider>())
            {
                // Put code for the left click event
                Debug.Log("Left Clicked on " + this.name);

                // show craft/disenchant info
                DetailScreenCard.Instance.ShowDetailScreen(GetComponent<OneCardManager>().cardAsset);
            }
        }
    }

    public void UpdateQuantity()
    {
        int quantity = CardCollection.Instance.QuantityOfEachCard[cardAsset];

        // if (CardCollectionsScreen.Instance.BuilderScript.InDeckBuildingMode && DeckBuildingScreen.Instance.ShowReducedQuantitiesInDeckBuilding)
        //     quantity -= DeckBuildingScreen.Instance.BuilderScript.NumberOfThisCardInDeck(cardAsset);
        
        QuantityText.text = "X" + quantity.ToString();

    }

    
}