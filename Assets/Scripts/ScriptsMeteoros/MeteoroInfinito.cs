using UnityEngine;
using System.Collections;

public class MeteoroInfinito : MeteoroBase
{
	public override void DestruirItSelf ()
	{
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_indestruct.reutilizar (gameObject);
	}


	void OnTriggerEnter(Collider target){
		if (target.tag == "tiro") {
			destroiAudio.Play ();
			target.GetComponent<Tiro> ().resetar ();	
			PlayerController.pollTiros.reutilizar (target.gameObject);
			if (vida_atual - PlayerController.dano <= 0) {
				GameController.pollPartMeteoroC.AtivarGameObject (transform.position);
			}
			TomarDano ();
			
		}
	}
		
		



	void Awake(){
		vida_max = 10;
	}
}

