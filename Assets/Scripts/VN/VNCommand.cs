using UnityEngine;

public class VNCommand {
    
    public static VNCommand instance;

    void CommandSetLayerImage(string data, BackgroundFunction.Layer layer)
    {
        string textureName = data.Contains(",") ? data.Split(',')[0] : data;
        Texture2D texture = Resources.Load("VisualNovel/Images/" + textureName) as Texture2D;

        float speed = 2f;
        bool smooth = false;

        if (data.Contains(","))
        {
            string[] parameters = data.Split(',');

            foreach (string parameter in parameters)
            {
                float speedValue = 0;
                bool smoothValue = false;

                if (float.TryParse(parameter, out speedValue))
                {
                    speed = speedValue;
                }

                if (bool.TryParse(parameter, out smoothValue))
                {
                    smooth = smoothValue;
                }
            }
        }

        layer.TransitionToTexture(texture, speed, smooth);
    }

    void VNPlaySFX(string data)
    {
        AudioClip clip = Resources.Load("VisualNovel/Audio/SFX/" + data) as AudioClip;

        if (clip != null)
            DLAudioManager.instance.PlaySFX(clip);
        
        else
            Debug.LogError("Clip tidak ditemukan");
    }

    void VNPlayMusic(string data)
    {
        AudioClip clip = Resources.Load("VisualNovel/Audio/Music/" + data) as AudioClip;

        if (clip != null)
            DLAudioManager.instance.PlaySong(clip);
        
        else
            Debug.LogError("Clip tidak ditemukan");
    }
}