	using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour {




	public GameObject canvasPause;
	public static float velocidade_jogo;
	bool pausado;
	bool waveRodando;
	float incrementoGold;

	public ControladorSkyboxes controlsky;
	static Text wave;
	public Text textoScore;
	CaixaWave caixaWave;
    public static float score;
	public GameObject partExplosao;
	public GameObject partMeteoroComum;
	public GameObject meteoroComum;	
	public GameObject meteoroHard;
	public GameObject meteoroExplosivo;
	public GameObject meteoroIndestruct;
	public GameObject meteoroFast;

	public static GerenciadorPool pollMeteoros_comuns;
	public static GerenciadorPool pollMeteoros_hard;
	public static GerenciadorPool pollMeteoros_explosivo;
	public static GerenciadorPool pollMeteoros_indestruct;
	public static GerenciadorPool pollMeteoros_aceleradores;
	public static GerenciadorParticula pollPartMeteoroC;
	public static GerenciadorParticula pollPartMeteoroE;


	/*
	public void salvar(){
		#if UNITY_WINRT

		byte[] bytes = UnityPluginForWindowsPhone.FileIO.SerializeObject<GameProgress>(this);
		File.WriteAllBytes(getSaveFile(), bytes);
		#else
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = File.Create(getSaveFile());
		bf.Serialize(fs, this);
		fs.Close();
		#endif
	}


	public void load(){
		byte[] bytes = File.ReadAllBytes(saveFile);        
		GameProgress gp = UnityWindowsPhonePlugin.FileIO.DeserializeObject<GameProgress>(bytes);
	}	*/



	public static void addPontos(float pontos){
		score += pontos;	

	}

	public void atualizaPontos(){
		textoScore.text = "Score: " + (int)score;
	}

	void Awake(){
		Time.timeScale = 1.0f;
		incrementoGold = 0.5f;
		waveRodando = false;
		pausado = false;
		velocidade_jogo = 1.0f;
		caixaWave = GameObject.FindGameObjectWithTag ("caixa-wave").GetComponent<CaixaWave> ();

		//Debug.Log (z.GetType ());

	}
	

	IEnumerator StartJogo(){

		int wave = 4;

		yield return new WaitForSeconds (4);
		float time=0;
		while (wave<50) {

			if (wave <5){
				time=Random.Range(20,40);
			}
			if (wave>=5){
				time=Random.Range (35,50);}

			if (wave%7==0){
				controlsky.MudarSkybox();
			}
			caixaWave.Atualizar(wave);

			caixaWave.Startar ();
			yield return new WaitForSeconds(1);
			//	StartCoroutine (caixaWave.des());
			//controlsky.MudarSkybox();

			waveRodando=true;
			switch (wave) {
					
			
			case 1:
				{
					yield return StartCoroutine (WaveGenerator (time, 1.0f, 1, 0, 0));
					break;}
			case 2:
				{
					yield return StartCoroutine (WaveGenerator (time, 1.0f, 1, 2));
					break;}
			case 3:
				{
					yield return StartCoroutine (WaveGenerator (time, 1.0f, 2, 3));
					break;}
			case 4:
				{
				yield return StartCoroutine (WaveGenerator (time, 1.0f, 2, 3));
					break;}
			case 5:
				{
					yield return StartCoroutine (WaveGenerator (time, 1.0f, 3, 0, 0));  
					break;}
			case 6:
				{
				yield return StartCoroutine (WaveGenerator (time, 1.0f, 4, 0, 0)); // ADD SEPARANTE.
					break;}
		
			//7 : Separante e quebraHARD

			case 8:
			{
				yield return StartCoroutine (WaveGenerator (time, 1.0f, 2, 3)); 
				break;}

			case 9:{

				yield return StartCoroutine(WaveGenerator(time,1.0f,5,0,0));
				                            break;}
			//Separantes e acelerantes

			case 11:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,1,5));
				break;}	                           

			case 12:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,3,5));
				break;}

				//  13: Quebra Hard, Acelerante	 e Separante
			case 14:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,2,3));
				break;}

			case 15:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,5,4,0));
				break;}

			case 16:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,6,4,0));
				break;}
			case 17:{
				yield return StartCoroutine(WaveGenerator(time,1.0f,1,6));
				break;}


		

			default :
				yield return StartCoroutine (WaveGenerator (time, 1.0f, 4, 0, 0));
				break;

			}
			waveRodando = false;
				
			yield return new WaitForSeconds (7);
			wave++;
			if (wave <= 5)
				velocidade_jogo += 0.2f;
			if (wave > 5)
				velocidade_jogo += 0.05f;
			


			
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


	IEnumerator WaveGenerator(float duracao,float intervalo, int TiposMeteoro, int excluido, int diferencial){

		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< duracao) {
			tempo_passado+=Time.deltaTime;
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);



			int atual = Random.Range(1,TiposMeteoro+1);
			if (atual!=excluido){

			if (atual==1){
				pollMeteoros_comuns.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo);tempo_passado+=intervalo;
			}

			if (atual==2){
				pollMeteoros_explosivo.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				
			}

			if (atual==3){
				pollMeteoros_hard.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;

			}

				if (atual==4){
					//Separante.
				}
				if (atual==5){
					pollMeteoros_aceleradores.AtivarGameObject(posicaospawn);
					yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				}


			if (atual==6){
				pollMeteoros_indestruct.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;

				}
			
			}

			
			
			
			
			
		}

		yield return 0;
		
	}

	IEnumerator WaveGenerator(float duracao,float intervalo, int TiposMeteoro1, int tipoMeteoro2){
		
		Vector3 posicaospawn;
		float tempo_passado = 0.0f;
		while (tempo_passado< duracao) {
			tempo_passado+=Time.deltaTime;
			posicaospawn = new Vector3 (Random.Range (-1.5f, 1.5f), 0, 12);
			
			
			
			int atual = Random.Range(1,7);
			
			if ((atual==1)&&(   (atual==TiposMeteoro1)||(atual==tipoMeteoro2)   )){
				pollMeteoros_comuns.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo);tempo_passado+=intervalo;
			}

			if ((atual==2)&&(   (atual==TiposMeteoro1)||(atual==tipoMeteoro2)   )){
				pollMeteoros_explosivo.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				
			}

			if ((atual==3)&&(   (atual==TiposMeteoro1)||(atual==tipoMeteoro2)   )){
				pollMeteoros_hard.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				
			}
		
			// 4 SEPARANTE

			if ((atual==5)&&(   (atual==TiposMeteoro1)||(atual==tipoMeteoro2)   )){


				pollMeteoros_aceleradores.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f+2.0f);tempo_passado+=intervalo+0.2f;
			}

			
				if ((atual==6)&&(   (atual==TiposMeteoro1)||(atual==tipoMeteoro2)   )){
				pollMeteoros_indestruct.AtivarGameObject(posicaospawn);
				yield return new WaitForSeconds(intervalo+0.2f);tempo_passado+=intervalo+0.2f;
				
			}
			
			
			
			
		}
		yield return 0;
		
	}




	void Start () {
	
	
		 pollMeteoros_comuns = new GerenciadorPool (meteoroComum, 6);
		pollMeteoros_hard = new GerenciadorPool (meteoroHard, 4);
		pollMeteoros_explosivo = new GerenciadorPool (meteoroExplosivo, 4);
		pollMeteoros_indestruct = new GerenciadorPool (meteoroIndestruct, 4);
		pollMeteoros_aceleradores = new GerenciadorPool (meteoroFast, 2);
		pollPartMeteoroC = new GerenciadorParticula (partMeteoroComum, 4);
		pollPartMeteoroE = new GerenciadorParticula (partExplosao, 3);
		StartCoroutine (StartJogo ());
		 
		//pollMeteoros_comuns.FirstRunSpawn ();





	}
	public void AbrirShop(){
		Time.timeScale = 1.0f;
		Application.LoadLevel ("CenaShop");

	}
	public void QuitToMenu(){
		Application.LoadLevel (0);
	}

	public static void Resetar(){
		score = 0;
	}

	public void reiniciarJogo(){
		score = 0;
		pausar_despausar ();
		Application.LoadLevel (Application.loadedLevel);
	
	}


	public void pausar_despausar(){
		if (pausado == true) {
			pausado = false;
			Time.timeScale = 1.0f;
			canvasPause.SetActive(false);
		} else {
			pausado=true;
			Time.timeScale=0.0f;
			canvasPause.SetActive(true);
		
		}


	}


	
	// Update is called once per frame
	void Update () {
	if (waveRodando) {
			score += Time.deltaTime*incrementoGold;
		}

	//	Debug.Log (PlayerController.dano);
		if (Input.GetKeyDown (KeyCode.P)) {
			pausar_despausar();
		}
	



	
		atualizaPontos ();



	
	}
}
