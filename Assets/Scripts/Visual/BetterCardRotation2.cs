using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class BetterCardRotation2 : MonoBehaviour {
 
    
    public RectTransform CardFront;
 
    
    public RectTransform CardBack;
 
    // Update is called once per frame
    void Update() 
    {
        if (isCardFrontFacingCamera())
        {
             // show the front side
            CardFront.gameObject.SetActive(true);
            CardBack.gameObject.SetActive(false);
        }

        else 
        {
            // show the back side
            CardFront.gameObject.SetActive(false);
            CardBack.gameObject.SetActive(true);
        }

        // if (isCardBackFacingCamera())
        // {
        //     // show the back side
        //     CardFront.gameObject.SetActive(false);
        //     CardBack.gameObject.SetActive(true);
        // }
    }
 
    bool isCardFrontFacingCamera()
    {
        return Vector3.Dot(
            CardFront.transform.forward,
            Camera.main.transform.position - CardFront.transform.position) < 0;
    }

    bool isCardBackFacingCamera()
    {
        return Vector3.Dot(
            CardBack.transform.forward,
            Camera.main.transform.position - CardFront.transform.position) < 0;
    }
}
