using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextArchitext
{

	/// <summary>
	/// current text digunakan sebagai media menggunakan fungsi Text Architech
	/// </summary>
	private static Dictionary<TextMeshProUGUI, TextArchitext> activeArchitects = new Dictionary<TextMeshProUGUI, TextArchitext>();

	TextMeshProUGUI tmpro;

	private string preText;
	private string targetText;

	private int charactersPerFrame = 1;
	[Range(1f, 60f)]
	private float speed = 0.5f;
	private bool useEncapsulation = true;

	public bool skip = false;

	public bool isTextConstructing { get { return buildProcess != null; } }
	Coroutine buildProcess = null;

	public TextArchitext(TextMeshProUGUI tmpro, string targetText, string preText = "", int charactersPerFrame = 1, float speed = 2f)
	{
		this.tmpro = tmpro;
		this.targetText = targetText;
		this.preText = preText;
		this.charactersPerFrame = charactersPerFrame;
		this.speed = speed;

		Initiate();
	}

	public void Stop()
	{
		if (isTextConstructing)
		{
			DialogueSystem.instance.StopCoroutine(buildProcess);
		}
		buildProcess = null;
	}

	IEnumerator TextConstruction()
	{
		int runsThisFrame = 0;

		tmpro.text = "";
		tmpro.text += preText;

		tmpro.ForceMeshUpdate();
		TMP_TextInfo inf = tmpro.textInfo;
		int vis = inf.characterCount;

		tmpro.text += targetText;

		tmpro.ForceMeshUpdate();
		inf = tmpro.textInfo;
		int max = inf.characterCount;

		tmpro.maxVisibleCharacters = vis;

		while(vis < max)
		{
			//skip jalannya dialog
			if (skip)
			{
				speed = 1;
				charactersPerFrame = charactersPerFrame < 5 ? 5 : charactersPerFrame + 3;
			}

			//
			while(runsThisFrame < charactersPerFrame)
			{
				vis++;
				tmpro.maxVisibleCharacters = vis;
				runsThisFrame++;
			}

			//
			runsThisFrame = 0;
			yield return new WaitForSeconds(0.01f * speed);
		}

		//
		Terminate();
	}

	void Initiate()
	{
		//untuk mengecek apakah tecArchitext sudah jalan atau belum
		TextArchitext existingArchitect = null;
		if (activeArchitects.TryGetValue(tmpro, out existingArchitect))
			existingArchitect.Terminate();

		buildProcess = DialogueSystem.instance.StartCoroutine(TextConstruction());
		activeArchitects.Add(tmpro, this);
	}

	/// <summary>
	/// untuk menutup fungsi textarchitext
	/// </summary>
	public void Terminate()
	{
		activeArchitects.Remove(tmpro);
		if (isTextConstructing)
			DialogueSystem.instance.StopCoroutine(buildProcess);
		buildProcess = null;
	}
	
}