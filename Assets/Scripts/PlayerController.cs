using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Gerenciador_UI gerente;
	public static int dano;
	public Animator animador;
	public static  int vida;
	public float speed = 10.0f;
	public float tilt=3.2f;
	public Transform spawnTiro;
	public float fireRate;
	public float nextFire;
	public static GerenciadorPool pollTiros;
	public static int balas;			
	public Text nBalas;
	void Awake(){
		GameObject vida4=GameObject.Find ("heart_4");
		GameObject vida3=GameObject.Find ("heart_3");
		GameObject vida2=GameObject.Find ("heart_2");
		GameObject vida1=GameObject.Find ("heart_1");
		vida4.SetActive (true);
		gerente = new Gerenciador_UI (vida4,vida3, vida2, vida1);
		pollTiros = new GerenciadorPool ((GameObject) Resources.Load ("TiroKawaii"), 2);
		vida = 4;
		nextFire = 0.0f;
		balas = 100;
		dano = 4;
	}

	public void AttNumeroBala(){
		nBalas.text = balas.ToString();
	}
	void Start(){
	  
		ConfereMostradorDeVida ();
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
		}
	
	}

	void Update(){
		//Debug.Log (1 / Time.deltaTime);
	//	Debug.Log (Time.time);


		if ((Input.GetKeyDown (KeyCode.Space))){
			Atirar ();
		
		}
	}

	

	void FixedUpdate ()
	{
		float moveHorizontal;
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

		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
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



	IEnumerator restartLevel(){
		Debug.Log ("chegou");
		yield return new WaitForSeconds(5);
		//Debug.Log ("passou");
		Application.LoadLevel(Application.loadedLevel);
	//	yield return 1;
	}

	public void TomarDano(){
		Debug.Log ("rolou");
		vida--;AttMostradorDeVida();
		StartCoroutine (animacaoDano ());

		if (vida == 0) {	
			//Destroy (gameObject);
			gameObject.transform.position=new Vector3(100,100);


			StartCoroutine(restartLevel());
		}

	}

	IEnumerator ficarInvencivel(){
		yield return 0;
	
	}




		}
	