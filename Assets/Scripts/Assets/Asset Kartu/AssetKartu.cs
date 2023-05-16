using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetingOptions
{
    NoTarget,
    AllCreatures, 
    EnemyCreatures,
    YourCreatures, 
    AllCharacters, 
    EnemyCharacters,
    YourCharacters
}

[CreateAssetMenu(menuName = "Integrasi/AssetKartu")]

public class AssetKartu : ScriptableObject
{
    [Header("General info")]
    public KarakterKartu karakterKartu;  // if this is null, it`s a neutral card
    [TextArea(2,3)]
    public string Deskripsi;  // Description for spell or character
    [TextArea(2,3)]
    public string KisahKartu; // Deskripsi Kisah Kartu
	public Sprite GambarKartu;
    public int EnergyCost;

    [Header("Karakter Info")]
    public int TotalPertahanan; //total Pertahanan yang dimiliki oleh kartu
    public int Serangan;
    public int KesempatanMenyerang = 1; // giliran menyerang pada 1 giliran
    public bool Taunt;
    public bool Charge;
    public string CreatureScriptName; //nama karakter
    public int specialCreatureAmount; 

    [Header("Spell Info")]
    public string SpellScriptName; //nama spell
    public int specialSpellAmount; 
    public TargetingOptions Targets;
}
