using UnityEngine;
using System.Collections;

public class MeteoroBase : MonoBehaviour {

	public float velocidade_base;
	public float velocidade_jogo;
	public int vida;
	void Start(){
		velocidade_jogo = GameController.velocidade_jogo;
		Debug.Log ("oi");

	}



	
	// Update is called once per frame

	public void DestruirItSelf(){
		Destroy (gameObject);

	}

	public void TomarDano(){
		vida--;
		if (vida == 0) {
			DestruirItSelf ();
		}	
	}
	void OnTriggerEnter(Collider target){
		if (target.tag == "tiro") {
			Destroy(target.gameObject);
			TomarDano();
		}


	}



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
