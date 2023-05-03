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
    public string Description;  // Description for spell or character
    public string KisahKartu; // Deskripsi Kisah Kartu
	public Sprite CardImage;
    public int ManaCost;

    [Header("Karakter Info")]
    public int MaxHealth;
    public int Attack;
    public int AttacksForOneTurn = 1;
    public bool Taunt;
    public bool Charge;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("Spell Info")]
    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;
}
