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

	void Awake(){


		malhaItens = GetComponent<Transform> ();
	}
	void Update () {
		posTopMarcador = topMarcador.transform.position;
		posMarcadorBaixo = marcadorBaixo.transform.position;

	    posMarcadorCima = marcadorCima.transform.position;



		if (Input.GetKey (KeyCode.DownArrow)&&(posMarcadorCima.y>posTopMarcador.y)) {
			malhaItens.Translate(Vector3.down);
		}


		if (Input.GetKey (KeyCode.UpArrow)&&(posMarcadorBaixo.y<posTopMarcador.y)){
			malhaItens.Translate(Vector3.up);
		}
	
	}
}
