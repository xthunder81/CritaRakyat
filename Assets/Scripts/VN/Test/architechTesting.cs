using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class architechTesting : MonoBehaviour {
    
    public TextMeshProUGUI text;
    TextArchitext architect;

    [TextArea(5, 50)]
    public string say;
    public int charactersPerFrame =1;
    public float speed = 0.5f;

    void Start ()
    {
        architect = new TextArchitext(text,say, "", charactersPerFrame, speed);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            architect = new TextArchitext(text,say, "", charactersPerFrame, speed);
        }
    }

}