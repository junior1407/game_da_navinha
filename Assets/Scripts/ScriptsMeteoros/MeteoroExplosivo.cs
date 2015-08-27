using UnityEngine;
using System.Collections;

public class MeteoroExplosivo : MeteoroBase
{

	public void Explodir(){
		Vector3 pos_atual = transform.position;
		Collider[] hitados = Physics.OverlapSphere (pos_atual, 2);
		int i = 0;
		while (i<hitados.Length) {
			//Debug.Log (hitados[i].gameObject.name);
		}

	}
}

