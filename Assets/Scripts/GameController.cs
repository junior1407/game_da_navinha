using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float velocidade_jogo;
	public GameObject meteoroComum;
	public int numero_de_inimigos;
	public static GerenciadorPool pollMeteoros_comuns;

	void Awake(){
		velocidade_jogo = 1.0f;
	}

	IEnumerator StartJogo(){
	
		yield return StartCoroutine (SpawnWaves ());
	
	
	}



	IEnumerator SpawnWaves(){
		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< 100000.0f) {
			tempo_passado+=Time.deltaTime;
			//Debug.Log (tempo_passado);
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);
			//Instantiate (meteoroComum, posicaospawn, Quaternion.identity);
			pollMeteoros_comuns.AtivarGameObject(posicaospawn);
			yield return new WaitForSeconds(1);tempo_passado+=1;




		
		}
		yield return 0;

	}
	void Start () {
		numero_de_inimigos = 50;
	
		 pollMeteoros_comuns = new GerenciadorPool (meteoroComum, 15);
		StartCoroutine (StartJogo ());
		//pollMeteoros_comuns.FirstRunSpawn ();


	
	}
	
	// Update is called once per frame
	void Update () {

		velocidade_jogo = velocidade_jogo + (Time.deltaTime/90);




	
	}
}
