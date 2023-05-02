using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Kartu : MonoBehaviour
{
    public int id, energy, serangan, pertahanan, effect;
    public string namaKartu, deskripsiKartu, kisahKartu;
    public bool jenisKartu, statusKartu;

    // Kartu Manager
    public Kartu ()
    {

    }

    public Kartu (int Id, int Energy, int Serangan, int Pertahanan, int Effect, string NamaKartu, 
                    string DeskripsiKartu, string KisahKartu, bool JenisKartu, bool StatusKartu)
    {
        id = Id;
        energy = Energy;
        serangan = Serangan;
        pertahanan = Pertahanan;
        effect = Effect;
        namaKartu = NamaKartu;
        deskripsiKartu = DeskripsiKartu;
        kisahKartu = KisahKartu;
        jenisKartu = JenisKartu;
        statusKartu = StatusKartu;
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
