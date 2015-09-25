using UnityEngine;
using System.Collections;

	public class MeteoroAcelerador : MeteoroBase {
	public AudioSource carregandoAudio;
	public AudioSource RapidoAudio;

	public override IEnumerator destruidoPorTiro(){
		
		destroiAudio.Play();
		transform.position = new Vector3 (0, 30, 20);
		mesh.enabled = false;
		carregandoAudio.Stop ();
		RapidoAudio.Stop ();
		yield return new WaitForSeconds(destroiAudio.clip.length);
		Debug.Log ("audio tocado. mesh desabilitado");
		DestruirItSelf ();
		yield return 1;
	}




	public override void DestruirItSelf ()
	{
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_aceleradores.reutilizar (gameObject);
		destroiAudio.Stop ();
		RapidoAudio.Stop ();
		carregandoAudio.Stop ();
		velocidade_base = 1.0f;
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
		mesh.enabled = true;

	}

}
