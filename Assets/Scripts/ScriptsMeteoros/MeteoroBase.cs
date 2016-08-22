

using UnityEngine;
using System.Collections;

public class MeteoroBase : MonoBehaviour {
	


	public float pontos;
	public AudioSource destroiAudio;

	public float velocidade_base;
	public float velocidade_jogo;
	public float vida_atual;
	public int vida_max;
	public MeshRenderer mesh;

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

		//Debug.Log ("rodei?");
		mesh.enabled = true;
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_comuns.reutilizar (gameObject);


	}

	public virtual IEnumerator destruidoPorTiro(){

		destroiAudio.Play();
		transform.position = new Vector3 (0, 30, 20);
		mesh.enabled = false;

		yield return new WaitForSeconds(destroiAudio.clip.length);
		//Debug.Log ("audio tocado. mesh desabilitado");
		DestruirItSelf ();
		yield return 1;
	}

	public virtual void TomarDano(){
	
		//Debug.Log ("gg");
		vida_atual-=PlayerController.dano;
		if (vida_atual <= 0) {
		//	Debug.Log ("Destruido1");
			StartCoroutine(destruidoPorTiro());
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
	public virtual void EDestruido(){

		if (transform.position.z < -1f) {
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
