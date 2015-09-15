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


	public IEnumerator Atualizar(int numero){
		texto.text = ("Wave " + numero);
	//	yield return StartCoroutine (Aparecer ());

//		yield return StartCoroutine (Desaparecer ());
		yield return 0;



	
	}





}
