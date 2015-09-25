using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GerenciadorShop : MonoBehaviour {


	public List<GameObject> listinha;

	public static GameObject canvasAreYouSure;
	public static BaseItem selecionado;
	public Text Textogold;
	public int gold;
	public PlayerPropriedades p;
	SaveGame save;


	public void LoadGame(){
		p.inventario.AmostrarIncremento ();
		Debug.Log ("dando incrementos");
	
		p.FornecerIncrementos ();
		Application.LoadLevel ("scene1");
	}

	public void AttTextoGold(){

		Textogold.text = gold.ToString();
	}

	void Awake(){
		try{
		canvasAreYouSure = GameObject.Find ("CanvasAreYouSure");
			canvasAreYouSure.SetActive (false);}
		catch(NullReferenceException e){
			Debug.Log("Canvas 'are you sure' nao existente ou desativado. Corriga isso programador fdp");
		}

		listinha.AddRange(GameObject.FindGameObjectsWithTag ("item"));
		AttTextoGold ();

			

	
	}
	void Start(){

		try{

			p = GameObject.Find ("Player-Itens").GetComponent<PlayerPropriedades> ();
		    
		}catch(NullReferenceException e){
			Debug.Log ("'player-itens' nao encontrado. Erro no loading ou vc n passou pela scene main menu");
			GameObject temp = Instantiate(Resources.Load ("Player-Itens")) as GameObject;
			p = temp.GetComponent<PlayerPropriedades>();
		}
		gold = p.inventario.gold;
		save = p.save;
		List<BaseItem> arrayItens = new List<BaseItem> ();
		foreach (GameObject atual in listinha) {
			Debug.Log ("oi");
			BaseItem qualquer= atual.GetComponent<BaseItem>();
			arrayItens.Add(qualquer);
			if (qualquer.GetType()==typeof(ItemMaisBalas)){
				Debug.Log ("entrei");
				qualquer.Inicializar(save.BalasMais);
			}

		}



	}



	public void ComprarAtual(){
		//Debug.Log (gold);
		//Debug.Log (selecionado.name);
		if (gold >= selecionado.preco) {
			gold -=selecionado.preco;

		//	selecionado.btnComprar.interactable=false;
			FecharAreYouSure();
			try{

				//p.inventario.addIncremento(selecionado.incremento);}
			}
			catch(NullReferenceException e){
				Debug.Log ("'player-itens' nao encontrado. Erro no loading ou vc n passou pela scene main menu");
			}

			AttTextoGold();
	
			//selecionado.AttEstadoItem(selecionado.estado_item+1);
			selecionado.Inicializar(selecionado.estado_item);
		}
		else{

			// Sem grana vacilao
		}


	}

	public void FecharAreYouSure(){
		canvasAreYouSure.SetActive (false);
	}


	void Update(){

	}
		



}
