using System.Collections;
using UnityEngine;

// Untuk Mendapatkan posisi elemen awal dan elemen akhir dari children array
// Setelah ELement Awal dan Element Akhir di dapatkan maka secara otomatis memebrikan jarak 
public class SameDistanceChildren : MonoBehaviour
{
    public Transform[] childrens;

    void Awake()
    {
        Vector3 firstElements = childrens[0].transform.position;
        Vector3 lastElements = childrens[childrens.Length - 1].transform.position;

        // menentukan koordinat posisi x, y, dan z dari element awal dan element akhir
        float xDist = (lastElements.x - firstElements.x) / (float)(childrens.Length - 1);
        float yDist = (lastElements.y - firstElements.y) / (float)(childrens.Length - 1);
        float zDist = (lastElements.z - firstElements.z) / (float)(childrens.Length - 1);

        Vector3 Dist = new Vector3(xDist, yDist, zDist);

        for (int i = 1; i < childrens.Length; i++)
        {
            childrens[i].transform.position = childrens[i - 1].transform.position + Dist;
        }
    }
}