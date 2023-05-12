using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class DatabaseKartu : MonoBehaviour
{

    // Membuat Object 
    public static List<Kartu> listKartu = new List<Kartu>();

    // Menambahkan Object berdasarkan List Yang Dibuat
    void Awake()
    {
        listKartu.Add(new Kartu(0, 1, 1, 1, 1, "test 1", "test 1", "test 1", 0, Resources.Load<Sprite>("Gambar Kartu/0")));
        listKartu.Add(new Kartu(1, 2, 2, 3, 1, "test 2", "test 2", "test 2", 1, Resources.Load<Sprite>("Gambar Kartu/1")));
        listKartu.Add(new Kartu(2, 1, 2, 0, 3, "test 3", "test 3", "test 3", 2, Resources.Load<Sprite>("Gambar Kartu/2")));
        listKartu.Add(new Kartu(3, 3, 3, 3, 3, "test 4", "test 4", "test 4", 1, Resources.Load<Sprite>("Gambar Kartu/3")));
        listKartu.Add(new Kartu(4, 4, 4, 3, 4, "test 5", "test 5", "test 5", 1, Resources.Load<Sprite>("Gambar Kartu/4")));
        listKartu.Add(new Kartu(5, 1, 1, 0, 1, "test 6", "test 6", "test 6", 2, Resources.Load<Sprite>("Gambar Kartu/5")));
        listKartu.Add(new Kartu(6, 1, 1, 1, 1, "test 7", "test 7", "test 7", 0, Resources.Load<Sprite>("Gambar Kartu/6")));
    }

    
}
