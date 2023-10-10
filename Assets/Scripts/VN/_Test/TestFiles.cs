using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFiles : MonoBehaviour
{
    // private string fileName = "testFile.txt";
    //private string fileName = "testFile";
    [SerializeField] private TextAsset fileName;

    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        // List<string> lines = FileManager.ReadTextFile(fileName, true);
        List<string> lines = FileManager.ReadTextAsset(fileName, true);

        foreach (string line in lines)
        {
            Debug.Log(line);
        }

        yield return null;
    }
}