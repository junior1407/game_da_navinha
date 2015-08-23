using UnityEngine;
using System.Collections;

public class MeteoroBase : MonoBehaviour {

	public float velocidade_base;
	public float velocidade_jogo;
	void Start(){
		velocidade_jogo = GameController.velocidade_jogo;
	}



	
	// Update is called once per frame


	void Mover(){
		transform.Translate (new Vector3 (0, 0, -1) * (velocidade_base + velocidade_jogo) * Time.deltaTime);
	}
	void EDestruido(){
		if (transform.position.z < -1) {
			Destroy (gameObject);
		}
	}
	void Update () {

		Mover ();
		EDestruido ();
	}
}
