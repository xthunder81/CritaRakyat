using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPemain : MonoBehaviour
{
    private List<Kartu> Deck = new List<Kartu>();
    public List<Kartu> shuffleDeck = new List<Kartu>();
    private int x, i;
    private int deckSize = 40;

    void Start()
    {
        x = 0;
        i = 0;
        while (i < deckSize)
        {
            x = Random.Range(0, 6);
            Deck[i] = DatabaseKartu.listKartu[x];
            i++;
        }
    }

    void Update()
    {

    }

    public void shuffle()
    {
        // while (i < deckSize)
        // {
        //     shuffleDeck[0] = Deck[i];
        //     int randomIndex = Random.Range(i, deckSize);
        //     Deck[i] = Deck[randomIndex];
        //     Deck[randomIndex] = shuffleDeck[0];
        //     i++;
        // }

        for (i = 0; i < deckSize;i++)
        {
            shuffleDeck[0] = Deck[i];
            int randomIndex = Random.Range(i, deckSize);
            Deck[i] = Deck[randomIndex];
            Deck[randomIndex] = shuffleDeck[0];
        }
    }
}