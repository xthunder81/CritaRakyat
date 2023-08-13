using System.Collections;
using UnityEngine;

public class Test_Achitectur : MonoBehaviour
{
    DialogueSystem dialogueSystem;

    TextArchitect architect;

    public GameObject textButton;

    //private string longLines;

    string[] lines = new string[5]
    {
        "ini adalah percobaan dialog",
        "saya mencoba mengatakan sesuatu",
        "dunia ini terkadang menjadi tempat yang tidak masuk akal",
        "jangan hilang harapan, kedepannya akan menjadi lebih baik",
        "teruslah mencoba"
    };

    void Start()
    {
        dialogueSystem = DialogueSystem.Instance;
        architect = new TextArchitect(dialogueSystem.dialogueContainer.dialogText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;
    }

    void Update()
    {
        string longLines = "Liam Sera Banfield is a reincarnator. He had reincarnated into a fantasy world of magic and swords, but at the time the civilization had already been making advancements into outer space.";

        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (architect.isBuilding)
            {
                if (!architect.increaseSpeed)
                    architect.increaseSpeed = true;
                else
                    architect.ForceComplete();
            }
            else
                architect.Build(longLines);
            // architect.Build(lines[Random.Range(0, lines.Length)]);            
        }
    

        else if (Input.GetKeyDown(KeyCode.A))
        {
            architect.Append(longLines);
            // architect.Append(lines[Random.Range(0, lines.Length)]);
        }
    }

    public void Touch()
{
    if (architect.isBuilding)
    {
        if (!architect.increaseSpeed)
            architect.increaseSpeed = true;
        else
            architect.ForceComplete();
    }
    else
        // architect.Build(longLines);
        architect.Build(lines[Random.Range(0, lines.Length)]);            
}
}