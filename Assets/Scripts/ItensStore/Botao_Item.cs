using UnityEngine;
using System.Collections;

public class Botao_Item : MonoBehaviour {






	public GameObject parteInvisivel;
	//public Transform
	public bool revelado;
	// Update is called once per frame
	void Start(){
		revelado = false;
	}

	public void Revelar(){
		if (revelado) {
			revelado = true;
			parteInvisivel.transform.Translate (0.0f, -57.0f, 0.0f);
		} else {
			revelado = false;
			//parteInvisivel.transform.Translate(0.0
		}
	}
	void Update () {

	
	}
}
