using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{

    public string dlCharacterName;

    public bool isMultiLayerCHaracter { get { return renderers.renderer; } }

    public bool enabled { get { return root.gameObject.activeInHierarchy; } set { root.gameObject.SetActive(value); } }

    public Vector2 anchorPadding { get { return root.anchorMax - root.anchorMin; } }

    DialogueSystem dialogue;

    /// <summary>
    /// untuk menampung semua gambar yang berhubungan dengan scene.
    /// </summary>
    [HideInInspector] public RectTransform root;

    /// <summary>
    /// membuat karakter muncul sesuai percakapan
    /// </summary>
    /// <param name="speech"></param>
    public void Say(string speech, bool add = false)
    {
        if (!enabled)
            enabled = true;

        if (!add)
            dialogue.Say(speech, dlCharacterName);

        else
            dialogue.AddSay(speech, dlCharacterName);
    }

    Vector2 n2Move;
    Coroutine moving;
    bool isMoving { get { return moving != null; } }

    /// <summary>
    /// membuat karakter bergerak di posisi yang diinginkan
    /// </summary>
    public void Move(Vector2 target, float speed, bool smooth = true)
    {
        // root.Translate();
        // berhenti bergerak
        StopMoving();

        // mulai bergerak
        moving = CharacterManager.instance.StartCoroutine(DLMove(target, speed, smooth));
    }

    /// <summary>
    /// fungsi dari menggerakkan karakter
    /// </summary>
    IEnumerator DLMove(Vector2 target, float speed, bool smooth)
    {
        n2Move = target;

        // untuk mendapatkan jarak dari antar pembatas 
        Vector2 padding = anchorPadding;

        // mendapatkan nilai pembatas dari 0% sampai 100%
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        Vector2 minAnchorTarget = new Vector2(maxX * n2Move.x, maxY * n2Move.y);
        speed *= Time.deltaTime;

        // bergerak sampai menuju lokasi yang ditentukan
        while (root.anchorMin != minAnchorTarget)
        {
            root.anchorMin = (!smooth) ? Vector2.MoveTowards(root.anchorMin, minAnchorTarget, speed) : Vector2.Lerp(root.anchorMin, minAnchorTarget, speed);
            root.anchorMax = root.anchorMin + padding;

            yield return new WaitForEndOfFrame();
        }

        StopMoving();
    }

    /// <summary>
    /// menghentikan pergerakan karakter
    /// </summary>
    public void StopMoving(bool arriveAtTargetPosition = false)
    {
        if (isMoving)
            CharacterManager.instance.StopCoroutine(moving);
        if (arriveAtTargetPosition)
            SetPosition(n2Move);

        moving = null;
    }

    /// <summary>
    /// menentukan posisi karakter di lokasi yang sudah ditentukan
    /// </summary>
    public void SetPosition(Vector2 target)
    {
        // untuk mendapatkan jarak dari antar pembatas 
        Vector2 padding = anchorPadding;

        // mendapatkan nilai pembatas dari 0% sampai 100%
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        Vector2 minAnchorTarget = new Vector2(maxX * n2Move.x, maxY * n2Move.y);

        // bergerak sampai menuju lokasi yang ditentukan
        root.anchorMin = minAnchorTarget;
        root.anchorMax = root.anchorMin + padding;
    }

    /// <summary>
    /// membuat karakter
    /// </summary>
    /// <param name="_name"></param>
    public Character(string _name, bool enableOnStart = true)
    {
        CharacterManager cm = CharacterManager.instance;

        // lokasi prefabs
        GameObject prefabs = Resources.Load("Story/Character/Character[" + _name + "]") as GameObject;

        // memanggil prefabs yang dibutuhkan
        GameObject ob = GameObject.Instantiate(prefabs, cm.characterPanel);

        root = ob.GetComponent<RectTransform>();
        dlCharacterName = _name;

        //memanggil komponen objek karakter
        renderers.renderer = ob.GetComponentInChildren<Image>();

        // untuk mengetahui objek yang akan dipanggil hanya 1 layer atau multi layer
        if (isMultiLayerCHaracter)
        {
            renderers.bodyRenderer = ob.transform.Find("bodyRenderer").GetComponent<Image>();
            renderers.expressionRenderer = ob.transform.Find("expressionRenderer").GetComponent<Image>();
            renderers.allBodyRenderers.Add(renderers.bodyRenderer);
            renderers.allExpressionRenderers.Add(renderers.expressionRenderer);
        }

        dialogue = DialogueSystem.instance;

        enabled = enableOnStart;
    }

    [System.Serializable]
    public class Renderers
    {
        public Image renderer;

        // untuk karakter multi layer
        public Image bodyRenderer, expressionRenderer;
        public List<Image> allBodyRenderers = new List<Image>();
        public List<Image> allExpressionRenderers = new List<Image>();
    }

    public Renderers renderers = new Renderers();
}