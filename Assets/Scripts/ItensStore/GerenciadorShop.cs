using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GerenciadorShop : MonoBehaviour {


	public List<GameObject> listinha;

	public static GameObject canvasAreYouSure;
	public static GameObject canvasPOBRE;
	public static BaseItem selecionado;
	public Text Textogold;
	public static int gold;
	public PlayerPropriedades p;
	SaveGame save;


	public void LoadGame(){
		p.Salvar ();

		Application.LoadLevel ("CenaLoading");
	}

	public void Quit(){
		p.Salvar ();
		Application.Quit ();

	}
    


	public void AttTextoGold(){

		Textogold.text = gold.ToString();
	}



	void Awake(){
		try{
		
		canvasAreYouSure = GameObject.Find ("CanvasAreYouSure");
			canvasAreYouSure.SetActive (false);

		}
		catch(NullReferenceException){
			Debug.Log("Canvas 'are you sure' nao existente ou desativado. Corriga isso programador fdp");
		}

		try{

			canvasPOBRE = GameObject.Find ("CanvasPobre");
			canvasPOBRE.SetActive(false);}
		catch(NullReferenceException){
			Debug.Log("sem dinehrio vacilao nao encontrada");
		}
			
		listinha.AddRange(GameObject.FindGameObjectsWithTag ("item"));
		AttTextoGold ();

			

	
	}
	void Start(){

		try{

			p = GameObject.Find ("Player-Itens").GetComponent<PlayerPropriedades> ();
		    
		}
		catch(NullReferenceException){
			Debug.Log ("'player-itens' nao encontrado. Erro no loading ou vc n passou pela scene main menu");
			try{
				p = GameObject.Find ("Player-Itens(Clone)").GetComponent<PlayerPropriedades> ();}
			catch(NullReferenceException){
				GameObject temp = Instantiate(Resources.Load ("Player-Itens")) as GameObject;
				p = temp.GetComponent<PlayerPropriedades>();
			}

		}
		p.Load ();



		save = p.save;
		gold = save.gold;
		AttTextoGold ();
		List<BaseItem> arrayItens = new List<BaseItem> ();
		foreach (GameObject atual in listinha) {
			//Debug.Log ("oi");
			BaseItem qualquer= atual.GetComponent<BaseItem>();
			arrayItens.Add(qualquer);
			if (qualquer.GetType()==typeof(ItemMaisBalas)){
				//Debug.Log ("entrei");
				qualquer.Inicializar(save.BalasMais);
				qualquer.AttEstadoItem(save.BalasMais+1);
			}
			if (qualquer.GetType()==typeof(ItemMaisDano)){
				//Debug.Log ("entrei");
				qualquer.Inicializar(save.DanoMais);
				qualquer.AttEstadoItem(save.DanoMais+1);
			}
			if (qualquer.GetType()==typeof(ItemMaisVelocidade)){
				//Debug.Log ("entrei");
				qualquer.Inicializar(save.SpeedMais);
				qualquer.AttEstadoItem(save.SpeedMais+1);
			}
			if (qualquer.GetType()==typeof(ItemVidaMais)){
				//Debug.Log ("entrei");
				qualquer.Inicializar(save.LifeMais);
				qualquer.AttEstadoItem(save.LifeMais+1);
			}

		}



	}



	public void ComprarAtual(){
		//Debug.Log (gold);
		//Debug.Log (selecionado.name);
		if (gold >= selecionado.preco) {
			p.save.gold-=selecionado.preco;
				
			gold -=selecionado.preco;

		//	selecionado.btnComprar.interactable=false;
			StartCoroutine(FecharComDelay());
			try{

				//p.inventario.addIncremento(selecionado.incremento);}
			}
			catch(NullReferenceException){
				Debug.Log ("'player-itens' nao encontrado. Erro no loading ou vc n passou pela scene main menu");
			}

			AttTextoGold();


			//selecionado.AttEstadoItem(selecionado.estado_item+1);
			selecionado.AttEstadoItem(selecionado.estado_item+1);
			selecionado.Inicializar(selecionado.estado_item+1);
			selecionado.AttEstadoItem(selecionado.estado_item+1);
		//	Debug.Log (selecionado.GetType());
			if (selecionado.GetType()==typeof(ItemMaisBalas)){

				p.save.BalasMais=selecionado.estado_item;
			}
			if (selecionado.GetType()==typeof(ItemMaisDano)){
				p.save.DanoMais=selecionado.estado_item;
			}
			if (selecionado.GetType()==typeof(ItemMaisVelocidade)){
				p.save.SpeedMais=selecionado.estado_item;
			}
			if (selecionado.GetType()==typeof(ItemVidaMais)){
				p.save.LifeMais=selecionado.estado_item;
			}

		}
		else{

			// Sem grana vacilao
		}


	}

	public void FecharAreYouSure(){

		canvasAreYouSure.SetActive (false);
	}

   IEnumerator FecharComDelay(){
		yield return new WaitForSeconds (0.3f);
		canvasAreYouSure.SetActive (false);
	}
	public void FecharPobre(){
		StartCoroutine (FecharPobreComDelay ());
	}
	IEnumerator FecharPobreComDelay(){
		yield return new WaitForSeconds (0.3f);
		canvasPOBRE.SetActive (false);
	}
	
	void Update(){

	}


	public void MexerPraBaixo(){


	}
		



}
