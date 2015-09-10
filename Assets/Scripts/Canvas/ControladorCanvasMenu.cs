using UnityEngine;
using System.Collections;

public class ControladorCanvasMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	public void StartGame(){
		Application.LoadLevel ("scene1");
	}
	public void ExitGame(){
		Application.Quit ();
	}


	void Update () {
	
	}
}
