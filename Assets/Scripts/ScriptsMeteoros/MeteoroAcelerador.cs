using UnityEngine;
using System.Collections;

	public class MeteoroAcelerador : MeteoroBase {
	public AudioSource carregandoAudio;
	public AudioSource RapidoAudio;
	public override void DestruirItSelf ()
	{
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_aceleradores.reutilizar (gameObject);
		destroiAudio.Stop ();
		RapidoAudio.Stop ();
		carregandoAudio.Stop ();
	}

	IEnumerator Action(){

		carregandoAudio.Play ();
		yield return new WaitForSeconds (carregandoAudio.clip.length);
		carregandoAudio.Stop ();
		velocidade_base = velocidade_base * 10;
		RapidoAudio.Play ();
	}
	void OnEnable(){
		atualizar_velocidadejogo ();
		StartCoroutine (Action ());

	}

}
