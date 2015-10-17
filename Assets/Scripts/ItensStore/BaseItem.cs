using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BaseItem : MonoBehaviour
{




	public BaseIncremento incremento;

	public GameObject[] interno;
	public int estado_item;
	public bool ocultado;
	public Animator animador;
	public int preco;
	public Button btnComprar;
	public Text TextPreco;



	public void Comprar(){

		if (GerenciadorShop.gold < preco) {
			GerenciadorShop.canvasPOBRE.SetActive (true);
		} else {

			GerenciadorShop.canvasAreYouSure.SetActive (true);
			GerenciadorShop.selecionado = this;
		}


	}
	public abstract void AttEstadoItem (int level);

	public void Inicializar (int dadoSave){
		estado_item = dadoSave;
			foreach(GameObject atual in interno){
				atual.SetActive(false);
			}
	

		if (dadoSave >= 1) {
			interno[0].SetActive(true);
		if (dadoSave>=2){
				interno[1].SetActive(true);
				if (dadoSave>=3){
					interno[2].SetActive(true);
					btnComprar.gameObject.SetActive(false);
				}
			}
		}
	




	}


	void Start(){


	}

	public virtual void OcultarDescolutar(){ 
	
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


