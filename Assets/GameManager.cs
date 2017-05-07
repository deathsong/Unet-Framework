using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	InputField LocalPlayerNameInputField;
	public string LocalPlayerName="";

	public static GameManager Instance;

	void Awake()
	{
		Instance = this;
	}

	public void SetLocalPlayerName()
	{
		LocalPlayerName = LocalPlayerNameInputField.text;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
