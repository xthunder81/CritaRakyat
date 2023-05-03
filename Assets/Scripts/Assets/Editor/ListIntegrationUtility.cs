using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ListIntegrationUtility : MonoBehaviour
{
    // Untuk membuat asset baru berdasarkan folder yang telah disiapkan

    public static void CreateAsset <T>() where T: ScriptableObject 
    {
        var asset = ScriptableObject.CreateInstance<T>();
        ProjectWindowUtil.CreateAsset(asset, "New " + typeof(T).Name + ".asset");
    }
}
