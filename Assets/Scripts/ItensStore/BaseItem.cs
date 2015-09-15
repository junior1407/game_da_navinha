using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour
{
	public BaseIncremento incremento;

	public bool ocultado;
	public Animator animador;
	public int preco;
	public Button btnComprar;



	public void Comprar(){
		GerenciadorShop.canvasAreYouSure.SetActive (true);
		GerenciadorShop.selecionado = this;
	}


	void Start(){


	}

	public virtual void OcultarDescolutar(){ 
		Debug.Log (animador.enabled);

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


