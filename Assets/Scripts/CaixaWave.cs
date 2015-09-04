using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaixaWave: MonoBehaviour {
	public CanvasGroup group;
	public Text texto;


	public void Startar(){



	}
	IEnumerator Aparecer(){
		float tempopassado = 0;
		while (tempopassado<5.0f) {


			group.alpha = Mathf.Lerp (group.alpha, 1.0f, (tempopassado / 5.0f));
			tempopassado += Time.deltaTime;
			yield return 0;
		}
	}
	IEnumerator Desaparecer(){
		float tempopassado = 0;
		while (tempopassado<5.0f) {
			

			group.alpha = Mathf.Lerp (group.alpha, 0.0f, (tempopassado / 5.0f));
			tempopassado += Time.deltaTime;
			yield return 0;
		}
	}

	public IEnumerator Atualizar(int numero){
		texto.text = ("Wave" + numero);
	//	yield return StartCoroutine (Aparecer ());

//		yield return StartCoroutine (Desaparecer ());
		yield return 0;



	
	}





}
