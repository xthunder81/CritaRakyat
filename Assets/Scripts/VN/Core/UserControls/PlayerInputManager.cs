using UnityEngine;

namespace DIALOGUE
{    
    public class PlayerInputManager : MonoBehaviour {
        
        void Start ()
        {

        }

        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {

            }
        }

        public void PromptAdvance ()
        {
            DialogueSystem.Instance.OnUserPrompt_Next();
        }
    }
}