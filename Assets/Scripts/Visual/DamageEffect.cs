using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class DamageEffect : MonoBehaviour {

    
    public Sprite[] Splashes;

    
    public Image DamageImage;

    
    public CanvasGroup cg;

    
    public TextMeshProUGUI AmountText;

    void Awake()
    {
        
        DamageImage.sprite = Splashes[Random.Range(0, Splashes.Length)];  
    }

    
    private IEnumerator ShowDamageEffect()
    {
        
        cg.alpha = 1f;
        
        yield return new WaitForSeconds(1f);
        
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        
        Destroy(this.gameObject);
    }

   
    public static void CreateDamageEffect(Vector3 position, int amount)
    {
        if (amount == 0)
            return;
        // Instantiate a DamageEffect from prefab
        GameObject newDamageEffect = GameObject.Instantiate(GlobalSettings.Instance.DamageEffectPrefab, position, Quaternion.identity) as GameObject;
        
        // Test Damage Effect
        // GameObject newDamageEffect = new GameObject();
        // newDamageEffect = GameObject.Instantiate(DamageEffectTest.Instance.DamagePrefab, position, Quaternion.identity) as GameObject;
        
        // Get DamageEffect component in this new game object
        DamageEffect de = newDamageEffect.GetComponent<DamageEffect>();

        if (amount < 0)
        {
            // NEGATIVE DAMAGE = HEALING
            de.AmountText.text = "+" + (-amount).ToString();
            de.DamageImage.color = Color.green;
        }
        else
            de.AmountText.text = "-"+amount.ToString();

        de.StartCoroutine(de.ShowDamageEffect());
    }
}
