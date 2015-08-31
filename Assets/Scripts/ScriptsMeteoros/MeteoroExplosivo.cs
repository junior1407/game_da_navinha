using UnityEngine;
using System.Collections;

public class MeteoroExplosivo : MeteoroBase
{



	public override void DestruirItSelf ()
	{
		Explodir ();
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_explosivo.reutilizar (gameObject);
	}

	public void Explodir(){
		Vector3 pos_atual = transform.position;
		Collider[] hitados = Physics.OverlapSphere (pos_atual, 2);
		Debug.Log ("foram : "+ hitados.Length);


		for (int i=0; i<hitados.Length; i++) {
			if (hitados[i].tag=="inimigo"){
				//hitados[i].get

			}
		}

	}}







