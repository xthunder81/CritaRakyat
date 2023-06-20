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
    Common, Rare, Epic, Legendary
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
    [TextArea(2, 3)]
    public string Description;  // Description for spell or character
    [TextArea(2, 3)]
    public string Story;    //Story For spell or character
    public StoryType storyType;

    public RarityOptions rarityOptions;

    public TypesOfCards typeOfCard;

    // [PreviewSprite]
    public Sprite CardImage;
    public int ManaCost;
    public bool TokenCard = false; // token cards can not be seen in collection
    public int OverrideLimitOfThisCardInDeck = -1;

    [Header("Creature Info")]
    public int MaxHealth;   // =0 => spell card
    public int Attack;
    public int AttacksForOneTurn = 1;
    public bool Charge;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;

}
