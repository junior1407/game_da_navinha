using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaixaWave: MonoBehaviour {
	public CanvasGroup group;
	public Text texto;


	public void Startar(){
		group=GetComponent<CanvasGroup> ();
		StartCoroutine (Aparecer ());

	}
	IEnumerator Aparecer(){
		float tempopassado = 0;
		while (tempopassado<5.0f) {

			Debug.Log (group.alpha);
			group.alpha = Mathf.Lerp (group.alpha, 1.0f, (tempopassado / 5.0f));
			tempopassado += Time.deltaTime;
			yield return 0;
		}
	}
	IEnumerator Desaparecer(){
		float tempopassado = 0;
		while (tempopassado<5.0f) {
			
			Debug.Log (group.alpha);
			group.alpha = Mathf.Lerp (group.alpha, 0.0f, (tempopassado / 5.0f));
			tempopassado += Time.deltaTime;
			yield return 0;
		}
	}

	public IEnumerator Atualizar(int numero){
		texto.text = ("Wave" + numero);
		yield return StartCoroutine (Aparecer ());

		yield return StartCoroutine (Desaparecer ());
		yield return 0;



	
	}


	public IEnumerator Atualizar(){
		yield return new WaitForSeconds (2);
		group.alpha = 0.0f;
		yield return 0;

	}/*
	public static void setWave(int n){
		
		wave.text = ("Wave " + n);
	}*/

}
