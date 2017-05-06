using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using RichTextExtention;

public class Console : MonoBehaviour {

	GameObject textPrefab;
	[SerializeField]
	Transform content;

	public static Console Instance;
	List<GameObject> messages ;

	[SerializeField]
	Scrollbar scroll;

	// Use this for initialization
	void Awake () {
		messages = new List<GameObject> ();
		Instance = this;
		textPrefab = Resources.Load<GameObject> ("TextPrefab");
	}
	
	// Update is called once per frame
	void Start()
	{	
		Console.AddMessage("Console ".Coloring("red")+"Start...".Coloring("green"));
	}

	public static void AddMessage(string _text)
	{
		Instance._AddMessage(_text); 
	}

	public void _AddMessage(string _text)
	{
		GameObject go = Instantiate (textPrefab);
		go.transform.SetParent (content);
		Text text = go.GetComponent<Text> ();
		text.text = _text;
		messages.Add (go);
		if (messages.Count>50){
			Destroy (messages[0]);
			messages.RemoveAt (0);
		}
		scroll.value = 0;
	}

	void Update () {
	
	}
}
