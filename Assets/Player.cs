using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using RichTextExtention;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

	[SyncVar(hook="PlayerNameHook")]
	string pseudo=string.Empty;
	// Use this for initialization
	[SerializeField]
	Text PlayerNamePlate;


	public override void OnStartClient ()
	{
		PlayerNameHook(pseudo);
		string message = string.Format ("{0} : {1}( {2} )", name.Coloring ("red"), "OnStartClient", pseudo.Coloring("blue").Bold());
		Console.AddMessage(message);
	}
		
	public override void OnStartLocalPlayer ()
	{
		pseudo = GameManager.Instance.LocalPlayerName;

		// duplicate code with playernamehook ... but...
		PlayerNamePlate.text = pseudo;
		name = pseudo;

		string message = string.Format ("{0} : {1}( {2} )", name.Coloring ("red"), "OnStartLocalPlayer", pseudo.Coloring("blue").Bold());
		Console.AddMessage(message);
		CmdRenamePlayer (pseudo);
	}
	void Start () {
		Console.AddMessage (name.Coloring("red")+" :Start()");	
	}
	public override void PreStartClient ()
	{
		Console.AddMessage (name.Coloring("red")+" :PreStartClient()");	
	}
	public override void OnStartServer ()
	{
		Console.AddMessage (name.Coloring("red")+" :OnStartServer()");	
	}
	// Update is called once per frame
	void Update () {
	
	}

	void PlayerNameHook(string hook)
	{
		//Console.AddMessage (name.Coloring("red")+" :PlayerNameHook()");
		PlayerNamePlate.text = hook;
		name = hook;
		string message = string.Format ("{0} : {1}({2})", name.Coloring ("red"), "PlayerNameHook", hook.Coloring("blue").Bold());
		Console.AddMessage(message);
	}

	[Command]
	void CmdRenamePlayer(string _pseudo)
	{
		// using syncvar from the server to rename all clients
		pseudo = _pseudo;
		string message = string.Format ("{0} : {1}({2})", name.Coloring ("red"), "CmdRenamePlayer", _pseudo.Coloring("blue").Bold());
		Console.AddMessage(message);

	}
}
