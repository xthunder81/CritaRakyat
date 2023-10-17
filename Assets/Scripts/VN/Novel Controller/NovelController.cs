using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NovelController : MonoBehaviour
{

    public static NovelController instance;

    List<string> data = new List<string>();

    int progress = 0;

    public string vnStory;

    void Awake ()
    {
        instance = this;
    }

    void Start()
    {
        LoadChapterFiles(vnStory);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleLing(data[progress]);
            progress++;
        }


    }

    public void NextText()
    {
        HandleLing(data[progress]);
        progress++;
    }

    public void LoadChapterFiles(string fileName)
    {
        data = FileManager.LoadFile(FileManager.savPath + "Resources/VisualNovel/Story/" + fileName);
        progress = 0;
    }

    void HandleLing(string line)
    {
        string[] dialogueAndAction = line.Split('"');

        // 3 dimaksudkan bahwa ada dialog didalam baris tersebut
        // 1 dimaksudkan bahwa tidak ada dialog hanya perintah

        if (dialogueAndAction.Length == 3)
        {
            HandleDialogue(dialogueAndAction[0], dialogueAndAction[1]);
            HandleEventFromLine(dialogueAndAction[2]);
        }

        else
        {
            HandleEventFromLine(dialogueAndAction[0]);
        }
    }

    [HideInInspector]
    public string cachedLastSpeaker = "";
    void HandleDialogue(string dialogueDetails, string dialogue)
    {
        string speaker = cachedLastSpeaker;
        bool additive = dialogueDetails.Contains("+");

        // menghapus tanda yang menandakan teks tambahan dari nama pembicara
        if (additive)
        {
            dialogueDetails = dialogueDetails.Remove(dialogueDetails.Length - 1);
        }

        // 
        if (dialogueDetails.Length > 0)
        {
            //menghapus spasi setelah nama pembicara bila ada
            if (dialogueDetails[dialogueDetails.Length - 1] == ' ')
                dialogueDetails = dialogueDetails.Remove(dialogueDetails.Length - 1);

            speaker = dialogueDetails;
            cachedLastSpeaker = speaker;
        }

        // narator tidak di anggap sebagai pembicara
        if (speaker != "narator")
        {
            Character character = CharacterManager.instance.GetCharacter(speaker);
            character.Say(dialogue, additive);
        }

        else
        {
            DialogueSystem.instance.Say(dialogue, speaker, additive);
        }
    }

    void HandleEventFromLine(String events)
    {
        string[] actions = events.Split(' ');

        foreach (string action in actions)
        {
            HandleAction(action);
        }
    }

    VNCommand command = VNCommand.instance;

    void HandleAction(string action)
    {
        print("Handle Action [" + action + "]");

        string[] data = action.Split('(', ')');

        switch (data[0])
        {
            case ("setBackground"):
                VNSetLayerImage(data[1], BackgroundFunction.instance.Background);
                break;
            case ("setCinematic"):
                VNSetLayerImage(data[1], BackgroundFunction.instance.Cinematic);
                break;
            case ("setForeground"):
                VNSetLayerImage(data[1], BackgroundFunction.instance.Foreground);
                break;
            case ("playSFX"):
                VNPlaySFX(data[1]);
                break;
            case ("playMusic"):
                VNPlayMusic(data[1]);
                break;
            case ("move"):
                VNMoveCharacter(data[1]);
                break;
            case ("setPosition"):
                VNSetPosition(data[1]);
                break;
            case ("flip"):
                VNCharacterFlip(data[1]);
                break;
            case ("flipLeft"):
                VNCharacterFlipLeft(data[1]);
                break;
            case ("flipRight"):
                VNCharacterFlipRight(data[1]);
                break;
            case ("enter"):
                VNEnter(data[1]);
                break;
            case ("exit"):
                VNExit(data[1]);
                break;
        }
    }


    void VNSetLayerImage(string data, BackgroundFunction.Layer layer)
    {
        string textureName = data.Contains(",") ? data.Split(',')[0] : data;
        Texture2D texture = textureName == "null" ? null : Resources.Load("VisualNovel/Images/" + textureName) as Texture2D;

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
            //Debug.LogError("Clip tidak ditemukan");
            DLAudioManager.instance.PlaySFX(null);
    }

    void VNPlayMusic(string data)
    {
        AudioClip clip = Resources.Load("VisualNovel/Audio/Music/" + data) as AudioClip;

        if (clip != null)
            DLAudioManager.instance.PlaySong(clip);

        else
            // Debug.LogError("Clip tidak ditemukan");
            DLAudioManager.instance.PlaySong(null);

    }

    void VNMoveCharacter(string data)
    {
        string[] parameters = data.Split(',');
        string character = parameters[0];
        float locationX = float.Parse(parameters[1]);
        float locationY = parameters.Length >= 3 ? float.Parse(parameters[2]) : 0;
        float speed = parameters.Length >= 4 ? float.Parse(parameters[3]) : 1f;
        bool smooth = parameters.Length == 5 ? bool.Parse(parameters[4]) : true;

        Character chara = CharacterManager.instance.GetCharacter(character);
        chara.Move(new Vector2(locationX, locationY), speed, smooth);
    }

    void VNSetPosition(string data)
    {
        string[] parameters = data.Split(',');
        string character = parameters[0];
        float locationX = float.Parse(parameters[1]);
        float locationY = float.Parse(parameters[2]);

        Character chara = CharacterManager.instance.GetCharacter(character);
        chara.SetPosition(new Vector2(locationX, locationY));
    }

    void VNCharacterFlip(string data)
    {
        Character chara = CharacterManager.instance.GetCharacter(data);
        chara.FlipCharacter();
    }

    void VNCharacterFlipLeft(string data)
    {
        Character chara = CharacterManager.instance.GetCharacter(data);
        chara.FlipCharacterLeft();
    }

    void VNCharacterFlipRight(string data)
    {
        Character chara = CharacterManager.instance.GetCharacter(data);
        chara.FlipCharacterRight();
    }

    void VNExit(string data)
    {
        string[] parameters = data.Split(',');
        string[] characters = parameters[0].Split(';');
        float speed = 3;
        bool smooth = false;
        for (int i = 1; i < parameters.Length; i++)
        {
            float fVal = 0; bool bVal = false;
            if (float.TryParse(parameters[i], out fVal))
            { speed = fVal; continue; }
            if (bool.TryParse(parameters[i], out bVal))
            { smooth = bVal; continue; }
        }

        foreach (string s in characters)
        {
            Character c = CharacterManager.instance.GetCharacter(s);
            c.FadeOut(speed, smooth);
        }
    }

    void VNEnter(string data)
    {
        string[] parameters = data.Split(',');
        string[] characters = parameters[0].Split(';');
        float speed = 3;
        bool smooth = false;
        for (int i = 1; i < parameters.Length; i++)
        {
            float fVal = 0; bool bVal = false;
            if (float.TryParse(parameters[i], out fVal))
            { speed = fVal; continue; }
            if (bool.TryParse(parameters[i], out bVal))
            { smooth = bVal; continue; }
        }

        foreach (string s in characters)
        {
            Character c = CharacterManager.instance.GetCharacter(s, true, false);
            if (!c.enabled)
            {
                c.renderers.bodyRenderer.color = new Color(1, 1, 1, 0);
                c.renderers.expressionRenderer.color = new Color(1, 1, 1, 0);
                c.enabled = true;

                c.TransitionBody(c.renderers.bodyRenderer.sprite, speed, smooth);
                c.TransitionExpression(c.renderers.expressionRenderer.sprite, speed, smooth);
            }
            else
                c.FadeIn(speed, smooth);
        }
    }
}