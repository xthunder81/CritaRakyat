using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailScreenCard : MonoBehaviour
{
    public static DetailScreenCard Instance;

    public GameObject content;
    public GameObject CreatureCard;
    public GameObject SpellCard;

    public TextMeshProUGUI storyTypeCard;
    

    private CardAsset currentCard;

    public bool Visible { get { return content.activeInHierarchy; } }



    void Awake()
    {
        Instance = this;
    }

    

    public void ShowDetailScreen(CardAsset cardToShow)
    {
        currentCard = cardToShow;

        // select type of card to show on this screen - creature or spell
        GameObject cardObject;
        if (currentCard.TypeOfCard == TypesOfCards.Creature)
        {
            cardObject = CreatureCard;
            CreatureCard.SetActive(true);
            SpellCard.SetActive(false);
        }

        else
        {
            cardObject = SpellCard;
            CreatureCard.SetActive(false);
            SpellCard.SetActive(true);
        }

        // change the look of the card to the card that we selected 
        OneCardManager manager = cardObject.GetComponent<OneCardManager>();
        manager.cardAsset = cardToShow;
        manager.ReadCardFromAsset();

        // change the text on StoryType
        storyTypeCard.text = currentCard.storyType.ToString();

        content.SetActive(true);
    }

    public void HideDetailScreen()
    {
        content.SetActive(false);
    }
}
