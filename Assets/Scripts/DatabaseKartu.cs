using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseKartu : MonoBehaviour
{

    // Membuat Object 
    public static List<Kartu> listKartu = new List<Kartu> ();

    // Menambahkan Object berdasarkan List Yang Dibuat
    void Awake()
    {
        listKartu.Add(new Kartu (0, 1, 1, 1, 1, "test 1", "test 1", "test 1", true, true));
        listKartu.Add(new Kartu (1, 2, 2, 3, 1, "test 2", "test 2", "test 2", false, true));
        listKartu.Add(new Kartu (2, 1, 2, 1, 3, "test 3", "test 3", "test 3", false, false));
        listKartu.Add(new Kartu (3, 3, 3, 3, 3, "test 4", "test 4", "test 4", true, false));
        listKartu.Add(new Kartu (4, 4, 4, 3, 4, "test 5", "test 5", "test 5", true, true));
        listKartu.Add(new Kartu (5, 1, 1, 1, 1, "test 6", "test 6", "test 6", true, true));
        listKartu.Add(new Kartu (6, 1, 1, 1, 1, "test 7", "test 7", "test 7", true, true));
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
