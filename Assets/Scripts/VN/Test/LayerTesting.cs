using UnityEngine;
using UnityEngine.Video;

public class LayerTesting : MonoBehaviour {

    BackgroundFunction controller;
    
    public Texture texture;
    

    void Start ()
    {
        controller = BackgroundFunction.instance;
    }

    void Update ()
    {
        BackgroundFunction.Layer layer = null;

        if (Input.GetKey(KeyCode.Q))
            layer = controller.Background;
        
        if (Input.GetKey(KeyCode.W))
            layer = controller.Cinematic;
        
        if (Input.GetKey(KeyCode.E))
            layer = controller.Foreground;
        
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
                layer.SetTexture(texture);

            if (Input.GetKeyDown(KeyCode.D))
                layer.TransitionToTexture(texture);
        }
    }
}