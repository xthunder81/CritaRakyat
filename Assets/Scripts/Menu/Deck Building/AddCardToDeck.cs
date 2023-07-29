using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AddCardToDeck : MonoBehaviour,IPointerClickHandler
{

    public TextMeshProUGUI QuantityText;
    private float InitialScale;
    private float scaleFactor = 2f;
    private CardAsset cardAsset;
    private int clickCount = 1;

    void Awake()
    {
        InitialScale = transform.localScale.x;
    }

    public void SetCardAsset(CardAsset asset) { cardAsset = asset; }

    void OnMouseDown()
    {
        CardAsset asset = GetComponent<OneCardManager>().cardAsset;
        if (asset == null)
            return;

        // check that these cards are available in collection (Quantity>0) or (TotalQuantity-AmountAlreadyInDeck)>0
        if (CardCollection.Instance.QuantityOfEachCard[cardAsset] - DeckBuildingScreen.Instance.BuilderScript.NumberOfThisCardInDeck(cardAsset) > 0)
        {
            DeckBuildingScreen.Instance.BuilderScript.AddCard(asset);
            UpdateQuantity();
        }
        else
        {
            // say that you do not have enough cards
        }
    }

    void OnMouseEnter()
    {

        if (CraftingScreen.Instance.Visible)
            return;

        // transform.DOScale(InitialScale * scaleFactor, 0.5f);
    }

    void OnMouseExit()
    {
        // if you remove / comment out this if statement, when the crefting screen is pened, when the cursor exits the card it will return to original scale.
        // if (CraftingScreen.Instance.Visible)
        //return;

        // transform.DOScale(InitialScale, 0.5f);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick();
            
            // startHoldClick = Time.deltaTime;
            // Debug.Log(startHoldClick);
            // if (Input.GetMouseButtonDown(0) && startHoldClick >= holdClick) { OnRightClick(); }
        }
    }

    // public void OnPointerClick(PointerEventData eventData) {
    //     if (eventData.clickCount >= clickCount) {
            
    //     }
    // }



    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            // See if the ray collided with an object
            if (Physics.Raycast(clickPoint, out hitPoint))
            {
                // Make sure this object was the
                // one that received the right-click
                if (hitPoint.collider == this.GetComponent<Collider>())
                {
                    // Put code for the right click event
                    //Debug.Log("Right Clicked on " + this.name);
                    Debug.Log("double click");

                    // show craft/disenchant info
                    CraftingScreen.Instance.ShowCraftingScreen(GetComponent<OneCardManager>().cardAsset);
                }
            }
            Debug.Log("double click");
        }
    }

    // Check for Right-Click
    void OnRightClick()
    {
        if (CraftingScreen.Instance.Visible)
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
                // Put code for the right click event
                Debug.Log("Right Clicked on " + this.name);

                // show craft/disenchant info
                CraftingScreen.Instance.ShowCraftingScreen(GetComponent<OneCardManager>().cardAsset);
            }
        }
    }

    public void UpdateQuantity()
    {
        int quantity = CardCollection.Instance.QuantityOfEachCard[cardAsset];

        if (DeckBuildingScreen.Instance.BuilderScript.InDeckBuildingMode && DeckBuildingScreen.Instance.ShowReducedQuantitiesInDeckBuilding)
            quantity -= DeckBuildingScreen.Instance.BuilderScript.NumberOfThisCardInDeck(cardAsset);

        QuantityText.text = "X" + quantity.ToString();

    }
}
