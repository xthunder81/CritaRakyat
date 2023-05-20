using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]

public class ManaPools : MonoBehaviour
{
    public int fullCrystall, CrystallPerTurn;

    public Image[] crystall;
    public TextMeshProUGUI prosessText;

    private int totalCrystall, availableCrystal;
    public int totalCrystalls
    {
        get { return totalCrystall; }

        set
        {
            // Test menggunakan Debug.Log
            if (value > crystall.Length)
                totalCrystall = crystall.Length;

            else if (value < 0)
                totalCrystall = 0;

            else
                totalCrystall = value;

            for (int i = 0; i < crystall.Length; i++)
            {
                if (i < totalCrystall)
                {
                    if (crystall[i].color == Color.clear)
                        crystall[i].color = Color.gray;
                }
                else
                {
                    crystall[i].color = Color.clear;
                }
            }
            prosessText.text = string.Format("{0}/{1}", availableCrystal.ToString(), totalCrystall.ToString());
        }
    }


    public int availableCrystals
    {
        get { return availableCrystal; }

        set
        {
            //Debug.Log("Changed mana this turn to: " + value);

            if (value > totalCrystall)
            {
                availableCrystal = totalCrystall;
            }
            else if (value < 0)
            {
                availableCrystal = 0;
            }
            else
            {
                availableCrystal = value;
            }

            for (int i = 0; i < totalCrystall; i++)
            {
                if (i < availableCrystal)
                    crystall[i].color = Color.white;
                
                else
                
                    crystall[i].color = Color.gray;
                
            }

            prosessText.text = string.Format("{0}/{1}", availableCrystal.ToString(), totalCrystall.ToString());
        }
    }

    void Update()
    {
        if (Application.isEditor && !Application.isPlaying) {
            totalCrystalls = CrystallPerTurn;
            availableCrystals = fullCrystall;
        }
    }

}
