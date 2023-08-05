using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryTypeData
{
    public StoryType options;
    public Color32 color;
}

public class StoryTypeColors : MonoBehaviour
{
    //Get StoryType Color Data
    public StoryTypeData[] data;
    public Dictionary<StoryType, Color32> colorDictionary = new Dictionary<StoryType, Color32>();

    public static StoryTypeColors Instance;

    void Awake()
    {
        if (Instance != this && Instance!=null)
            Destroy(Instance.gameObject);
        Instance = this;

        DontDestroyOnLoad(this);

        foreach (StoryTypeData d in data)
        {
            colorDictionary.Add(d.options, d.color);
        }
    }
}