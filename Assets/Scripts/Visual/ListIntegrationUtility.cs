using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ListIntegrationUtility : MonoBehaviour
{
    // Untuk memanggil database
    private List<Kartu> TestKartu = new List<Kartu>();
    
    // [Header("Memanggil Data Kartu")]
    public int idKartu, id, energy, serangan, pertahanan, effect, jeniskartu;
    public string namaKartu, deskripsikartu, kisahkartu;
    public Sprite gambarkartu;

    // mendapatkan objek text pada kartu
    // [Header("Object Kartu")]
    public TextMeshProUGUI energyText, namaKartuText, seranganText, pertahananText, deskripsiText;
    public GameObject attackA, attackB, defenseA, defenseB;

    public Image menampilkangambar, GlowFace, GlowBack;

    void Start()
    {
        // TestKartu[0] = DatabaseKartu.listKartu[idKartu];
        TestKartu.Add(DatabaseKartu.listKartu[idKartu]);
    }

    void Update()
    {
        id = TestKartu[0].id;
        energy = TestKartu[0].energy;
        serangan = TestKartu[0].serangan;
        pertahanan = TestKartu[0].pertahanan;
        effect = TestKartu[0].effect;
        namaKartu = TestKartu[0].namaKartu;
        deskripsikartu = TestKartu[0].deskripsiKartu;
        kisahkartu = TestKartu[0].deskripsiKartu;
        jeniskartu = TestKartu[0].jenisKartu;
        gambarkartu = TestKartu[0].gambarKartu;

        energyText.text = "" + energy;
        namaKartuText.text = "" + namaKartu;
        seranganText.text = "" + serangan;
        pertahananText.text = "" + pertahanan;
        deskripsiText.text = "" + deskripsikartu;
        menampilkangambar.sprite = gambarkartu;

        if (pertahanan == 0)
        {
            attackA.SetActive(false);
            attackB.SetActive(false);
            defenseA.SetActive(false);
            defenseB.SetActive(false);
        }

        else
        {
            attackA.SetActive(true);
            attackB.SetActive(true);
            defenseA.SetActive(true);
            defenseB.SetActive(true);
        }
    }
}
