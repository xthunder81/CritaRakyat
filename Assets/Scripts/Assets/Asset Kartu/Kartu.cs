using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
[System.Serializable]

public class Kartu
{
    public int id, energy, serangan, pertahanan, effect, jenisKartu;
    public string namaKartu, deskripsiKartu, kisahKartu;

    public Sprite gambarKartu;

    // Kartu Manager
    public Kartu()
    {

    }

    public Kartu(int Id, int Energy, int Serangan, int Pertahanan, int Effect, string NamaKartu,
                    string DeskripsiKartu, string KisahKartu, int JenisKartu, Sprite GambarKartu)
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
        gambarKartu = GambarKartu;
    }
}
