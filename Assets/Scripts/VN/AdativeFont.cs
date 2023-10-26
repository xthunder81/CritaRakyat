using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdativeFont : MonoBehaviour {
    
    TextMeshProUGUI text;
    public bool continualUpdate = true;    
    public int fontSizeAtDefaultResolution = 30; 
    public static float defaultResolution = 2525f;

    void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (continualUpdate)
        {
            InvokeRepeating("Adjust", 0f, Random.Range(0.5f, 2f));
        }

        else
        {
            Adjust();
            enabled = false;
        }
    }


    void Adjust()
    {
        if(!enabled || gameObject.activeInHierarchy)
            return;
        
        float totalCurrentRes = Screen.height + Screen.width;
        float percent = totalCurrentRes / defaultResolution;
        int fontSize = Mathf.RoundToInt((float)fontSizeAtDefaultResolution * percent);

        text.fontSize = fontSize;
    }
}