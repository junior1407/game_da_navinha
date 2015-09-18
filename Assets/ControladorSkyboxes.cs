using UnityEngine;
using System.Collections;

public class ControladorSkyboxes : MonoBehaviour {


	public Material[] lista;

	public int atual;
	public int maximo;

	public void Awake(){

		atual = 0;
		maximo = 9;
		RenderSettings.skybox= lista [atual];
	}
	public void MudarSkybox(){
		atual++;
		if (atual == 10) {
			atual = 0;
		}
		RenderSettings.skybox= lista [atual];



	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.T)) {
			MudarSkybox();
		}
		  
	}
}
