using UnityEngine;
using System.Collections;

	public class MeteoroAcelerador : MeteoroBase {
	public AudioSource carregandoAudio;
	public AudioSource RapidoAudio;


	public override IEnumerator destruidoPorTiro(){
		RapidoAudio.enabled = false;
		carregandoAudio.Stop ();
		//Debug.Log ("DestruirByTIro");
		StopCoroutine (Action ());
		destroiAudio.Play();
		transform.position = new Vector3 (0, 30, 20);
		mesh.enabled = false;



		yield return new WaitForSeconds(destroiAudio.clip.length);
		RapidoAudio.Stop ();
		//Debug.Log ("pausei");

		this.DestruirItSelf ();
		yield return 1;
	}




	public override void DestruirItSelf ()
	{
		RapidoAudio.enabled = false;
		//Debug.Log ("DestruirItself");
			vida_atual = vida_max;
			atualizar_velocidadejogo ();
			GameController.pollMeteoros_aceleradores.reutilizar (gameObject);
			destroiAudio.Stop ();
			RapidoAudio.Stop ();
			carregandoAudio.Stop ();	
			velocidade_base = 0.8f;
		}


	

	

	IEnumerator Action(){
		velocidade_jogo = velocidade_jogo / 4;
		velocidade_base = 0.0f;

		carregandoAudio.Play ();
		yield return new WaitForSeconds (carregandoAudio.clip.length);
		atualizar_velocidadejogo ();
		velocidade_base = 0.8f;
		carregandoAudio.Stop ();
		velocidade_base = velocidade_base * 20;
	if (RapidoAudio.enabled==true){

			RapidoAudio.Play ();}
		
	
	}
	void OnEnable(){
		atualizar_velocidadejogo ();
		StartCoroutine (Action ());
		mesh.enabled = true;

	}
	void OnDisable(){
		RapidoAudio.enabled = true;

	}

}
