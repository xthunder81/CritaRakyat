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

        dialogue.Say(speech, dlCharacterName, add);
    }

    public void FlipCharacter()
    {
        root.localScale = new Vector3(-1,1,1);
    }

    public void FlipCharacterLeft()
    {
        root.localScale = new Vector3(-1,1,1);
    }

    public void FlipCharacterRight()
    {
        root.localScale = new Vector3(1,1,1);
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

    //Begin Transitioning Images\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	public Sprite GetSprite(int index = 0)
	{
		Sprite[] sprites = Resources.LoadAll<Sprite> ("Images/Characters/" + dlCharacterName);
		return sprites[index];
	}

	public Sprite GetSprite(string spriteName = "")
	{
		Sprite[] sprites = Resources.LoadAll<Sprite> ("Images/Characters/" + dlCharacterName);
		for(int i = 0; i < sprites.Length; i++)
		{
			if (sprites[i].name == spriteName)
				return sprites[i];
		}
		return sprites.Length > 0 ? sprites[0] : null;
	}

	public void SetBody(int index)
	{
		renderers.bodyRenderer.sprite = GetSprite (index);
	}
	public void SetBody(Sprite sprite)
	{
		renderers.bodyRenderer.sprite = sprite;
	}
	public void SetBody(string spriteName)
	{
		renderers.bodyRenderer.sprite = GetSprite (spriteName);
	}

	public void SetExpression(int index)
	{
		renderers.expressionRenderer.sprite = GetSprite (index);
	}
	public void SetExpression(Sprite sprite)
	{
		renderers.expressionRenderer.sprite = sprite;
	}
	public void SetExpression(string spriteName)
	{
		renderers.expressionRenderer.sprite = GetSprite (spriteName);
	}

	//Transition Body
	bool isTransitioningBody {get{ return transitioningBody != null;}}
	Coroutine transitioningBody = null;

	public void TransitionBody(Sprite sprite, float speed, bool smooth)
	{
		StopTransitioningBody ();
		transitioningBody = CharacterManager.instance.StartCoroutine (TransitioningBody (sprite, speed, smooth));
	}

	void StopTransitioningBody()
	{
		if (isTransitioningBody)
			CharacterManager.instance.StopCoroutine (transitioningBody);
		transitioningBody = null;
	}

	public IEnumerator TransitioningBody(Sprite sprite, float speed, bool smooth)
	{
		for (int i = 0; i < renderers.allBodyRenderers.Count; i++) 
		{
			Image image = renderers.allBodyRenderers [i];
			if (image.sprite == sprite) 
			{
				renderers.bodyRenderer = image;
				break;
			}
		}

		if (renderers.bodyRenderer.sprite != sprite) 
		{
			Image image = GameObject.Instantiate (renderers.bodyRenderer.gameObject, renderers.bodyRenderer.transform.parent).GetComponent<Image> ();
			renderers.allBodyRenderers.Add (image);
			renderers.bodyRenderer = image;
			image.color = DLGlobalFunction.SetAlpha (image.color, 0f);
			image.sprite = sprite;
		}

		while (DLGlobalFunction.TransitionImages (ref renderers.bodyRenderer, ref renderers.allBodyRenderers, speed, smooth, true))
			yield return new WaitForEndOfFrame ();

		StopTransitioningBody ();
	}

	//Transition Expression
	bool isTransitioningExpression {get{ return transitioningExpression != null;}}
	Coroutine transitioningExpression = null;

	public void TransitionExpression(Sprite sprite, float speed, bool smooth)
	{
		StopTransitioningExpression ();
		transitioningExpression = CharacterManager.instance.StartCoroutine (TransitioningExpression (sprite, speed, smooth));
	}

	void StopTransitioningExpression()
	{
		if (isTransitioningExpression)
			CharacterManager.instance.StopCoroutine (transitioningExpression);
		transitioningExpression = null;
	}

	public IEnumerator TransitioningExpression(Sprite sprite, float speed, bool smooth)
	{
		for (int i = 0; i < renderers.allExpressionRenderers.Count; i++) 
		{
			Image image = renderers.allExpressionRenderers [i];
			if (image.sprite == sprite) 
			{
				renderers.expressionRenderer = image;
				break;
			}
		}

		if (renderers.expressionRenderer.sprite != sprite) 
		{
			Image image = GameObject.Instantiate (renderers.expressionRenderer.gameObject, renderers.expressionRenderer.transform.parent).GetComponent<Image> ();
			renderers.allExpressionRenderers.Add (image);
			renderers.expressionRenderer = image;
			image.color = DLGlobalFunction.SetAlpha (image.color, 0f);
			image.sprite = sprite;
		}

		while (DLGlobalFunction.TransitionImages (ref renderers.expressionRenderer, ref renderers.allExpressionRenderers, speed, smooth, true))
			yield return new WaitForEndOfFrame ();

		StopTransitioningExpression ();
	}
		
	//End Transition Images\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

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

    public void FadeOut(float speed = 3, bool smooth = false)
	{
		Sprite alphaSprite = Resources.Load<Sprite>("VisualNovel/Images/AlphaOnly");

		lastBodySprite = renderers.bodyRenderer.sprite;
		lastFacialSprite = renderers.expressionRenderer.sprite;

		TransitionBody(alphaSprite, speed, smooth);
		TransitionExpression(alphaSprite, speed, smooth);
	}

	Sprite lastBodySprite, lastFacialSprite = null;
	public void FadeIn(float speed = 3, bool smooth = false)
	{
		if (lastBodySprite != null)
		{
			TransitionBody(lastBodySprite, speed, smooth);
			TransitionExpression(lastFacialSprite, speed, smooth);
		}
	}

    /// <summary>
    /// membuat karakter
    /// </summary>
    /// <param name="_name"></param>
    public Character(string _name, bool enableOnStart = true)
    {
        CharacterManager cm = CharacterManager.instance;

        // lokasi prefabs
        GameObject prefabs = Resources.Load("VisualNovel/Character/Character[" + _name + "]") as GameObject;

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