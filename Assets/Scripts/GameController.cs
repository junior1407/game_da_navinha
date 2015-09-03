﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public static float velocidade_jogo;
	static Text wave;
	public GameObject partExplosao;
	public GameObject partMeteoroComum;
	public GameObject meteoroComum;	
	public GameObject meteoroHard;
	public GameObject meteoroExplosivo;
	public GameObject meteoroIndestruct;
	public int numero_de_inimigos;
	public static GerenciadorPool pollMeteoros_comuns;
	public static GerenciadorPool pollMeteoros_hard;
	public static GerenciadorPool pollMeteoros_explosivo;
	public static GerenciadorPool pollMeteoros_indestruct;
	public static GerenciadorParticula pollPartMeteoroC;
	public static GerenciadorParticula pollPartMeteoroE;



	void Awake(){
		velocidade_jogo = 1.0f;
		wave=GameObject.Find ("wave").GetComponent<Text> ();

	}

	public static void setWave(int n){

		wave.text = ("Wave " + n);
	}

	IEnumerator StartJogo(){
		int wave = 1;
		while (wave<50) {
			setWave(wave);
		   switch(wave){

			case 2: {yield return StartCoroutine(WaveGenerator(15.0f,1.0f,1));
				break;}
			case 1: {yield return StartCoroutine(WaveGenerator(15.0f,1.0f,2));
				break;}
			case 3: {yield return StartCoroutine(WaveGenerator(15.0f,1.0f,3));
				break;}

			default : Debug.Log ("wut");yield return StartCoroutine(WaveGenerator(Random.Range(15.0f, 20.0f),1.0f,3)); break;

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


	IEnumerator WaveGenerator(float duracao,float intervalo, int TiposMeteoro){

		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< duracao) {
			tempo_passado+=Time.deltaTime;
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);
			int atual = Random.Range(1,TiposMeteoro+1);

			if (atual==1){
				pollMeteoros_comuns.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo);tempo_passado+=intervalo;
			}
			if (atual==5){
				pollMeteoros_hard.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;

			}
			if (atual==2){
				pollMeteoros_explosivo.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				
			}
			if (atual==1){
				pollMeteoros_indestruct.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;

			}

			
			
			
			
			
		}
		yield return 0;
		
	}


	void Start () {
		numero_de_inimigos = 50;
	
		 pollMeteoros_comuns = new GerenciadorPool (meteoroComum, 4);
		pollMeteoros_hard = new GerenciadorPool (meteoroHard, 4);
		pollMeteoros_explosivo = new GerenciadorPool (meteoroExplosivo, 4);
		pollMeteoros_indestruct = new GerenciadorPool (meteoroIndestruct, 4);
		pollPartMeteoroC = new GerenciadorParticula (partMeteoroComum, 2);
		pollPartMeteoroE = new GerenciadorParticula (partExplosao, 2);
		StartCoroutine (StartJogo ());
		//pollMeteoros_comuns.FirstRunSpawn ();


	
	}
	
	// Update is called once per frame
	void Update () {

		velocidade_jogo = velocidade_jogo + (Time.deltaTime/90);




	
	}
}
