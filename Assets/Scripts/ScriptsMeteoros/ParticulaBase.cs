using UnityEngine;
using System.Collections;

public class ParticulaBase : MonoBehaviour
{

	public float tempovivo;

	void Awake(){
		tempovivo = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		tempovivo += Time.deltaTime;
	if (tempovivo > 3.0f) {
			tempovivo=0.0f;
			GameController.pollPartMeteoroC.reutilizar(gameObject);
		}
	}
}

