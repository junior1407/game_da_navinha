using UnityEngine;
using System.Collections;

public class MeteoroQuebraHard : MeteoroBase
{

	public AudioSource impacto;
	 void Awake(){
		vida_max = 3;
	}
	public override void DestruirItSelf(){
		Debug.Log ("Mesh consertado");
		mesh.enabled = true;
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_hard.reutilizar (gameObject);
		
		
	}
 


	public override void TomarDano(){
		
		//Debug.Log ("gg");
		vida_atual-=PlayerController.dano;
		if (vida_atual <= 0) {
			GameController.addPontos(pontos);

		}	
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "tiro") {
			target.GetComponent<Tiro>().resetar();	
			PlayerController.pollTiros.reutilizar(target.gameObject);
			if (vida_atual-PlayerController.dano<=0){

				GameController.pollPartMeteoroC.AtivarGameObject(transform.position);
				StartCoroutine(destruidoPorTiro());
			}else{
				impacto.Play();
			}
			TomarDano();
			
		}
		
		
		
	}






	}









