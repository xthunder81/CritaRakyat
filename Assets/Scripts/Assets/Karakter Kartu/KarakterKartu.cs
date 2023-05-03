using UnityEngine;

public enum JenisCerita
{
    Mistis, Legenda, Dongeng
}

[CreateAssetMenu(menuName = "Integrasi/KarakterKartu")]
public class KarakterKartu : ScriptableObject
{
    public JenisCerita jenisCerita;
	public string namaJenisCerita;
	public int MaxHealth = 30;
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