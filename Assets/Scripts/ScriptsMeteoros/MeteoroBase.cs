using UnityEngine;
using System.Collections;

public class MeteoroBase : MonoBehaviour {
	


	public float pontos;

	public float velocidade_base;
	public float velocidade_jogo;
	public int vida_atual;
	public int vida_max;

	void OnEnable(){
		atualizar_velocidadejogo ();
	}
	 void Awake(){
		vida_max = 1;



	}
	public void atualizar_velocidadejogo(){
		velocidade_jogo = GameController.velocidade_jogo;
	}

	void Start(){
		atualizar_velocidadejogo ();
	
		vida_atual = vida_max;

	}




	
	// Update is called once per frame

	public virtual void DestruirItSelf(){
	
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_comuns.reutilizar (gameObject);


	}

	public void TomarDano(){
		//Debug.Log ("gg");
		vida_atual-=PlayerController.dano;
		if (vida_atual <= 0) {
			DestruirItSelf ();
			GameController.addPontos(pontos);

		}	
	}
	void OnTriggerEnter(Collider target){
		if (target.tag == "tiro") {
			target.GetComponent<Tiro>().resetar();	
			PlayerController.pollTiros.reutilizar(target.gameObject);
			if (vida_atual-PlayerController.dano<=0){
				GameController.pollPartMeteoroC.AtivarGameObject(transform.position);
			}
			TomarDano();

		}



	}




	void Mover(){
		transform.Translate (new Vector3 (0, 0, -1) * (velocidade_base + velocidade_jogo) * Time.deltaTime);
	}
	void EDestruido(){
		if (transform.position.z < -1) {
			DestruirItSelf();
		}
	}
	void Update () {
		//particulasystem.play ();
		Mover ();
		EDestruido ();

	}



	public virtual  void DestruirEfeitos(){}


}
