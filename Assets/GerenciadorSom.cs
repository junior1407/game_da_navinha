using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GerenciadorSom : MonoBehaviour {
	public Sprite mutado;
	public Sprite nMutado;
	public Image script;
	bool estaMutado=false;

	public void MutarDesmutar(){

		if (estaMutado == false) {
			estaMutado = true;
			AudioListener.pause = true;
			script.sprite=mutado;

		} else {
			estaMutado=false;
			AudioListener.pause=false;
			script.sprite=nMutado;
		}
	}


}
