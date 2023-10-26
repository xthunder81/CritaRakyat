using UnityEngine;

public class CharacterTesting : MonoBehaviour {
    
    public Character deka;

    void Start ()
    {
        deka = CharacterManager.instance.GetCharacter("Deka", enableCreatedCharacterOnStart:false);
    }

    public string[] speech;

    int i = 0;

    public Vector2 moveTarget;
    public float moveSpeed;
    public bool smooth;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < speech.Length)
                deka.Say(speech[i]);
            
            else
                DialogueSystem.instance.CloseSay();
            
            i++;
        }

        if (Input.GetKey(KeyCode.A))
            deka.Move(moveTarget, moveSpeed, smooth);
        
        if (Input.GetKey(KeyCode.D))
            deka.StopMoving(true);
    }
}