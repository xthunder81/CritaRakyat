using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntegrasiKartu : MonoBehaviour
{
    public AssetKartu assetKartu;
    public IntegrasiKartu tampilanKartu;

    // Untuk Mendapatkan Objek Teks
    // [Header ("Referensi Komponen Teks")]
    public TextMeshProUGUI namaText, energyCostText, seranganText, pertahananText, deskripsiText, kisahText;

    // untuk mendapatkan gameobject
    // [Header ("Referensi Komponen GameObject")]
    // public GameObject seranganIcon, pertahananIcon;

    // untuk mendapatkan gambar pada gameobject
    // [Header ("Referensi Komponen Gambar")]
    public Image frameCard, bodyCard, textFrameNameCard, imageCard, textDescFrameCard, glowFace, glowBack;

    void Awake()
    {
        if (assetKartu != null)
        {
            MembacaKartu();
        }
    }

    private bool kartuBisaDimainkan = false;
    public bool KartuBisaDimainkan
    {
        get
        {
            return kartuBisaDimainkan;
        }

        set
        {
            kartuBisaDimainkan = value;

            glowFace.enabled = value;
        }
    }

    public void MembacaKartu()
    {
        if (assetKartu.karakterKartu != null)
        {
            bodyCard.color = assetKartu.karakterKartu.ClassCardTint;
            frameCard.color = assetKartu.karakterKartu.ClassCardTint;
            textFrameNameCard.color = assetKartu.karakterKartu.ClassCardTint;
            textDescFrameCard.color = assetKartu.karakterKartu.ClassCardTint;
        }

        else
        {
            //CardBodyImage.color = GlobalSettings.Instance.CardBodyStandardColor;
            // CardFaceFrameImage.color = Color.white;
            //CardTopRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
            //CardLowRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
        }

        // memberikan nama pada kartu
        namaText.text = assetKartu.name;
        // menenrukan energy pada kartu
        energyCostText.text = assetKartu.EnergyCost.ToString();
        // memberikan deskripsi pada kartu
        deskripsiText.text = assetKartu.Deskripsi;

        // mengganti sprite kartu
        imageCard.sprite = assetKartu.GambarKartu;

        if (assetKartu.TotalPertahanan != 0)
        {
            seranganText.text = assetKartu.Serangan.ToString();
            pertahananText.text = assetKartu.TotalPertahanan.ToString();
        }

        if (tampilanKartu != null)
        {
            tampilanKartu.assetKartu = assetKartu;
            tampilanKartu.MembacaKartu();
        }

        // memberikan kisah pada kartu
        // if (kisahText.text != null)
        // {
        //     kisahText.text = assetKartu.KisahKartu;
        // }
    }
}