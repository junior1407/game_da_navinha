

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	bool vivo;
	AudioSource audioTiro;
	public GameObject canvasGameOver;
	public Text textGameOver;
	public GameObject explodir;
	float moveHorizontal;
	public GameObject corpo;
	Gerenciador_UI gerente;
	public static float dano;
	public Animator animador;
	public static  int vida;
	public static float speed;
	public float tilt=3.2f;
	public Transform spawnTiro;
	public float fireRate;
	public float nextFire;
	public static GerenciadorPool pollTiros;
	public static int balas;			
	public Text nBalas;
	public PlayerPropriedades p;
	void Awake(){

		audioTiro= GetComponent<AudioSource>();
		vivo = true;
		GameObject vida6=GameObject.Find ("heart_6");
		GameObject vida5=GameObject.Find ("heart_5");
		GameObject vida4=GameObject.Find ("heart_4");
		GameObject vida3=GameObject.Find ("heart_3");
		GameObject vida2=GameObject.Find ("heart_2");
		GameObject vida1=GameObject.Find ("heart_1");
		vida4.SetActive (true);
	    
		gerente = new Gerenciador_UI (vida6,vida5,vida4,vida3, vida2, vida1);
		pollTiros = new GerenciadorPool ((GameObject) Resources.Load ("TiroKawaii"), 2);

		vida = 10;
		nextFire = 0.0f;
		balas = 50;
		dano = 1;
		speed = 8.0f;
	}

	public void AttNumeroBala(){
		nBalas.text = balas.ToString();
	}
	void Start(){
		balas = 50;

		try{
			p = GameObject.Find ("Player-Itens").GetComponent<PlayerPropriedades> ();
			}
		catch(NullReferenceException){
			p = GameObject.Find ("Player-Itens(Clone)").GetComponent<PlayerPropriedades> ();
			Debug.Log ("player-itens n encontrado. FUCK");

		}

		p.inventario.AplicarTodasParadas ();
		ConfereMostradorDeVida ();
		AttNumeroBala ();

	}

	void AttMostradorDeVida(){
		gerente.att (vida);
	}
	void ConfereMostradorDeVida(){
		gerente.confere (vida);
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "inimigo") {
			TomarDano ();

		}
	}

	public void Atirar(){
	    if ((Time.time > nextFire)&&(balas>0)) {
			balas--;
			AttNumeroBala();
			nextFire=Time.time+fireRate;
			pollTiros.AtivarGameObject(new Vector3(spawnTiro.position.x,0.0f));

			audioTiro.Play ();
		}
	
	}

	void Update(){
		//Debug.Log (1 / Time.deltaTime);
	//	Debug.Log (Time.time);
      

		if ((Input.GetKeyDown (KeyCode.Space))){
			Atirar ();
		
		}
		//Debug.Log (Time.timeScale);
	}

	

	void FixedUpdate ()
	{
		if (vivo)
			Mover ();

	}

	public void Mover(){
		
		
		
		moveHorizontal = Input.GetAxis ("Horizontal");
		#if UNITY_WP8
		moveHorizontal = Input.acceleration.x;
		#endif
		
		#if UNITY_WP8_API
		moveHorizontal = Input.acceleration.x;
		#endif
		
		
		
		#if UNITY_EDITOR
		moveHorizontal = Input.GetAxis ("Horizontal");
		#endif
		
		
		
		GetComponent<Rigidbody>().velocity = new Vector3 (moveHorizontal, 0.0f, 0.0f) * speed;
		
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x,-1.5f, 1.5f), 
				0.0f, 
				0.0f
				);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

	}

	IEnumerator animacaoDano(){

		animador.SetTrigger ("tomar");
		yield return 0;
	}



	public void restartLevel(){
	
		GameController.Resetar ();

		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale=1.0f;

	}
	IEnumerator MostraGameOver(){
		int Score = (int) GameController.score;
		yield return new WaitForSeconds(2);
		Time.timeScale = 0.0f;
		textGameOver.text = "You got: " +Score +" COINS"; 
		canvasGameOver.SetActive (true);
		p.save.gold += Score;
		p.Salvar ();
	
		yield return 0;


	}
	public void TomarDano(){
		//Debug.Log ("rolou");
		vida--;AttMostradorDeVida();
		StartCoroutine (animacaoDano ());

		if (vida == 0) {	
			//Destroy (gameObject);
			corpo.SetActive(false);
			explodir.SetActive(true);
			vivo=false;
			//gameObject.transform.position=new Vector3(100,100);
			StartCoroutine(MostraGameOver ());
		
			//StartCoroutine(restartLevel());
		}

	}

	IEnumerator ficarInvencivel(){
		yield return 0;
	
	}




		}
	