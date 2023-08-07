using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryTypeData
{
    public StoryType options;
    public Color color;
}

public class StoryTypeColors : MonoBehaviour
{
    //Get StoryType Color Data
    public StoryTypeData[] Data;
    public Dictionary<StoryType, Color> colorDictionary = new Dictionary<StoryType, Color>();

    public static StoryTypeColors Instance;

    void Awake()
    {
        if (Instance != this && Instance!=null)
            Destroy(Instance.gameObject);
        Instance = this;

        DontDestroyOnLoad(this);

        foreach (StoryTypeData d in Data)
        {
            colorDictionary.Add(d.options, d.color);
        }
    }
}