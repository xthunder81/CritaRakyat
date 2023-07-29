﻿using UnityEngine;
using System.Collections;

public enum CharClass
{
    Mitos, Legenda, Dongeng
}

public class CharacterAsset : ScriptableObject
{
    public CharClass Class;
    public string ClassName;
    public int MaxHealth = 20;
    public string HeroPowerName;
    public Sprite AvatarImage;
    public Sprite HeroPowerIconImage;
    public Sprite AvatarBGImage;
    public Sprite HeroPowerBGImage;
    public Color32 AvatarBGTint;
    public Color32 HeroPowerBGTint;
    public Color32 ClassCardTint;
    public Color32 ClassRibbonsTint;
}
