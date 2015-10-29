using UnityEngine;
using System.Collections;

public class ControladorCanvasMenu : MonoBehaviour {

	public GameObject canvasCreditos;
	public PlayerPropriedades PlayerPropriedades;
	void Start () {
	
	}
	void Awake(){

		PlayerPropriedades.Load ();

	}
	

	public void StartGame(){
		Application.LoadLevel ("CenaLoading");

	}
	public void OpenShop(){

		Application.LoadLevel ("CenaShop");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void OpenCloseCredits(){



		if (canvasCreditos.activeSelf) {
			canvasCreditos.SetActive(false);
		} else {

			canvasCreditos.SetActive(true);
		}
	}



	void Update () {
	
	}
}
