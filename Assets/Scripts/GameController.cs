using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static float velocidade_jogo;
	public GameObject meteoroComum;	
	public GameObject meteoroHard;
	public int numero_de_inimigos;
	public static GerenciadorPool pollMeteoros_comuns;
	public static GerenciadorPool pollMeteoros_hard;

	void Awake(){
		velocidade_jogo = 1.0f;
	}

	IEnumerator StartJogo(){
		int wave = 1;
		while (wave<50) {
		   switch(wave){

			case 1: {yield return StartCoroutine(WaveGenerator(15.0f,1.0f,1,wave));
				break;}
			default : Debug.Log ("wut");yield return StartCoroutine(WaveGenerator(Random.Range(15.0f, 20.0f),1.0f,2,wave)); break;

			}
				
			yield return new WaitForSeconds(7);
			wave++;

			}
			


			
			}

	
	



	/*
	IEnumerator SpawnWaves(){
		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< 15) {
			tempo_passado+=Time.deltaTime;
			//Debug.Log (tempo_passado);
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);
			//Instantiate (meteoroComum, posicaospawn, Quaternion.identity);
			pollMeteoros_comuns.AtivarGameObject(posicaospawn);
			yield return new WaitForSeconds(1);tempo_passado+=1;




		
		}
		yield return 0;

	}*/


	IEnumerator WaveGenerator(float duracao,float intervalo, int TiposMeteoro,int num){
		Debug.Log (num);
		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< duracao) {
			tempo_passado+=Time.deltaTime;
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);
			int atual = Random.Range(1,TiposMeteoro);
			Debug.Log("atual e "+atual);
			if (atual==1){
				pollMeteoros_comuns.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo);tempo_passado+=intervalo;
			}
			if (atual==2){
				pollMeteoros_hard.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;

			}

			
			
			
			
			
		}
		yield return 0;
		
	}


	void Start () {
		numero_de_inimigos = 50;
	
		 pollMeteoros_comuns = new GerenciadorPool (meteoroComum, 15);
		pollMeteoros_hard = new GerenciadorPool (meteoroHard, 10);
		StartCoroutine (StartJogo ());
		//pollMeteoros_comuns.FirstRunSpawn ();


	
	}
	
	// Update is called once per frame
	void Update () {

		velocidade_jogo = velocidade_jogo + (Time.deltaTime/90);




	
	}
}
