using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

// berisikan referensi text dan gambar pada kartu
public class OneCardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI ManaCostText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI StoryText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI StoryType;
    [Header("Image References")]
    public Image CardTopRibbonImage;
    public Image CardGraphicImage;
    public Image CardBodyImage;
    public Image CardFaceFrameImage;
    public Image CardFaceGlowImage;
    public Image RarityStoneImage;

    void Awake()
    {
        if (cardAsset != null)
            ReadCardFromAsset();
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;

            CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {
        // universal actions for any Card
        // 1) membarikan gambar
        // CardFaceFrameImage.color = StoryTypeColors.Instance.colorDictionary[cardAsset.storyType];
        if (CardFaceFrameImage != null) 
        {
            // if (cardAsset.storyType == 0)
            //     CardFaceFrameImage.color = Color.;
            CardFaceFrameImage.color = StoryTypeColors.Instance.colorDictionary[cardAsset.storyType];
        }
        // 2) menambahkan nama
        NameText.text = cardAsset.name;
        // 3) manambahkan jumlah mana
        ManaCostText.text = cardAsset.ManaCost.ToString();
        // 4) menambahkan deskripsi
        if (DescriptionText != null)
        {
            DescriptionText.text = cardAsset.Description;
        }    
        // 5) merubah tampilan CardGraphicImage
        CardGraphicImage.sprite = cardAsset.CardImage;

        if (cardAsset.MaxHealth != 0)
        {
            AttackText.text = cardAsset.Attack.ToString();
            HealthText.text = cardAsset.MaxHealth.ToString();
        }

        if (PreviewManager != null)
        {
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }

        if (StoryText != null)
        {
            StoryText.text = cardAsset.Story.ToString();
        }

        if (StoryType != null)
        {
            StoryType.text = cardAsset.storyType.ToString();
        }

        if (RarityStoneImage != null)
        {
            RarityStoneImage.color = RarityColors.Instance.ColorsDictionary[cardAsset.Rarity];
            // RarityStoneImage.color = StoryTypeColors.Instance.colorDictionary[cardAsset.storyType];
        }
        
    }
}
