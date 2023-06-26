using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public enum RarityOptions
{
    Basic, Common, Rare, Epic, Legendary
}

public enum StoryType
{
    None,
    Mitos,
    Legenda,
    Dongeng
}

public enum TypesOfCards
{
    Creature, Spell
}

public class CardAsset : ScriptableObject
{
    // this object will hold the info about the most general card
    [Header("General info")]
    public CharacterAsset characterAsset;  // if this is null, it`s a neutral card
    public string Tags;
    [TextArea(2, 3)]
    public string Description;  // Description for spell or character
    [TextArea(2, 3)]
    public string Story;    //Story For spell or character
    public StoryType storyType;

    public RarityOptions Rarity;

    public TypesOfCards TypeOfCard;

    [PreviewSprite]
    public Sprite CardImage;
    [Range(1, 20)]
    public int ManaCost;
    public bool TokenCard = false; // token cards can not be seen in collection
    public int OverrideLimitOfThisCardInDeck = -1;

    [Header("Creature Info")]
    [Range(1, 20)]
    public int MaxHealth;   // =0 => spell card
    [Range(1, 10)]
    public int Attack;
    [Range(1, 10)]
    public int AttacksForOneTurn = 1;
    public bool Taunt;
    public bool Charge;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;

}
