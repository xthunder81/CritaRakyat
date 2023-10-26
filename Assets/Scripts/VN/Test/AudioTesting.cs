using UnityEngine;

public class AudioTesting : MonoBehaviour {
    
    public float volume, pitch;
    public AudioClip[] clips;
    public AudioClip[] musics;

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Tab))
        {
            DLAudioManager.instance.PlaySFX(clips[Random.Range(0,clips.Length)], volume, pitch);
        }

        if (Input.GetKeyDown (KeyCode.R))
            DLAudioManager.instance.PlaySong(musics[Random.Range(0, musics.Length)]);
    }
}