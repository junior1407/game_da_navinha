using UnityEngine;
using System.Collections;

public class ShopSlid : MonoBehaviour {


	public RectTransform marcadorBaixo;
	public Vector3 posMarcadorBaixo;
  

	public RectTransform marcadorCima;
	public Vector3 posMarcadorCima;
	
	public RectTransform topMarcador;
	public Vector3 posTopMarcador;
///	public RectTransform BaixoMarcador;
///	public Vector3 posBaixoMarcador;

	public Transform malhaItens;



	public bool downpressed;
	public bool uppressed;

	void Awake(){


		malhaItens = GetComponent<Transform> ();
	}
	void Update () {
		posTopMarcador = topMarcador.transform.position;
		posMarcadorBaixo = marcadorBaixo.transform.position;

	    posMarcadorCima = marcadorCima.transform.position;

		if (downpressed) {
			//PressKeyDown();
			PressUpDown();
		}
		if (uppressed) {
			PressKeyDown ();
		}

		if (Input.GetKey (KeyCode.DownArrow)){
			PressKeyDown();
		}


		if (Input.GetKey (KeyCode.UpArrow)){
			PressUpDown();
		}
	
	}

	
	public void holdKeyUp(){
		//Debug.Log ("apertando");
		uppressed = true;
	}
	public void releaseKeyUp(){
		//Debug.Log ("soltando");
		uppressed = false;
	}


	public void holdKeyDown(){
		//Debug.Log ("apertando");
		downpressed = true;
	}
	public void releaseKeyDown(){
		//Debug.Log ("soltando");
		downpressed = false;
	}
	public void PressKeyDown(){
		if (posMarcadorCima.y > posTopMarcador.y) {
			malhaItens.Translate(Vector3.down);
		}
	}
	public void PressUpDown(){
		if (posMarcadorBaixo.y < posTopMarcador.y) {
			malhaItens.Translate (Vector3.up);

		}

	}


}
