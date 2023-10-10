using UnityEngine;

public class TextTagsManager : MonoBehaviour {
    
    public static string[] SplitByTags(string targetText)
    {
        return targetText.Split(new char[2]{'<', '>'});
    }
}