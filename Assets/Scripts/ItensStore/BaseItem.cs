using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour
{

	public bool ocultado;
	public Animator animador;


	void Start(){


	}

	public void OcultarDescolutar(){ 

		if (ocultado == false) {
			ocultado=true;
			animador.SetTrigger("Ocultar");


		}
		else { 
			animador.SetTrigger("Mostrar");
			ocultado=false;

		}
	}
	}


