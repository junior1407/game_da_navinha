using UnityEngine;
using System.Collections;
using System;

public class MeteoroExplosivo : MeteoroBase
{



	public override void DestruirItSelf ()
	{
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_explosivo.reutilizar (gameObject);
	}
	public override void DestruirEfeitos ()
	{

		Explodir ();
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "tiro") {
			target.GetComponent<Tiro>().resetar();	
			PlayerController.pollTiros.reutilizar(target.gameObject);
			if (vida_atual==1){
				DestruirEfeitos();
			}

	

		}


		
		
		
	}




	public void Explodir(){
	

		Vector3 pos_atual = transform.position;
		//GameController.pollPartMeteoroE.AtivarGameObject (pos_atual);
		Collider[] hitados = Physics.OverlapSphere (pos_atual, 5);
		Debug.Log ("foram : "+ hitados.Length);
		foreach (Collider hitado in hitados) {

			if (hitado.tag=="Player"){
	
				hitado.GetComponent<PlayerController>().TomarDano();
			}

			if (hitado.tag=="inimigo"){

				if (hitado.name.Contains("comum")){

					hitado.GetComponent<MeteoroBase>().TomarDano();
					}

				if (hitado.name.Contains("explosivo")){
					hitado.GetComponent<MeteoroExplosivo>().TomarDano();
				}
				if (hitado.name.Contains("quebra")){
					hitado.GetComponent<MeteoroQuebraHard>().TomarDano();
				}

				
				


			}
		}

		/*
		for (int i=0; i<hitados.Length; i++) {
			if (hitados[i].tag=="inimigo"){
				var atual = hitados[i].GetComponent<MeteoroBase>();
				atual.DestruirItSelf();
			}


				//hitados[i].get

			}*/
		}

	}







