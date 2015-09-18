using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaixaWave: MonoBehaviour {
	public CanvasGroup group;
	public Text texto;
	public Animator animador;

	public void Startar(){
		Debug.Log ("exibindo");
		animador.SetTrigger ("mostra");
		 

	}


	public void Atualizar(int numero){
		texto.text = ("Wave " + numero);
	}






}
