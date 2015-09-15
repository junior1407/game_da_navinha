using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GerenciadorShop : MonoBehaviour {


	public List<GameObject> listinha;
	public static GameObject canvasAreYouSure;
	public static BaseItem selecionado;
	public Text Textogold;
	public int gold;
	public PlayerPropriedades p;


	public void LoadGame(){
		Application.LoadLevel ("scene1");
	}

	public void AttTextoGold(){

		Textogold.text = gold.ToString();
	}

	void Awake(){
		canvasAreYouSure = GameObject.Find ("CanvasAreYouSure");
		canvasAreYouSure.SetActive (false);
		listinha.AddRange(GameObject.FindGameObjectsWithTag ("item"));
		AttTextoGold ();

			

	
	}
	void Start(){
		p = GameObject.Find ("Player-Itens").GetComponent<PlayerPropriedades> ();
		gold = p.inventario.gold;
	}


	public void ComprarAtual(){
		Debug.Log (gold);
		Debug.Log (selecionado.name);
		if (gold >= selecionado.preco) {
			gold -=selecionado.preco;

			selecionado.btnComprar.interactable=false;
			FecharAreYouSure();
			p.inventario.addIncremento(selecionado.incremento);
			AttTextoGold();
		}
		else{

			// Sem grana vacilao
		}


	}

	public void FecharAreYouSure(){
		canvasAreYouSure.SetActive (false);
	}


		



}
