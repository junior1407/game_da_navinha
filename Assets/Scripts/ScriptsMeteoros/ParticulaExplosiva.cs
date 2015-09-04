using UnityEngine;
using System.Collections;

public class ParticulaExplosiva : ParticulaBase
{

	void Update ()
	{
		tempovivo += Time.deltaTime;
		if (tempovivo > duracao) {
			tempovivo=0.0f;
			GameController.pollPartMeteoroE.reutilizar(gameObject);
		}
	}
}

