using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	Gerenciador_UI gerente;
	public static  int vida;
	public float speed = 10.0f;
	public float tilt=3.2f;
	public Transform spawnTiro;
	public float fireRate;
	public float nextFire;
	public static GerenciadorPool pollTiros;
			
	void Awake(){
		GameObject vida3=GameObject.Find ("heart_3");
		GameObject vida2=GameObject.Find ("heart_2");
		GameObject vida1=GameObject.Find ("heart_1");
		gerente = new Gerenciador_UI (vida3, vida2, vida1);
		pollTiros = new GerenciadorPool ((GameObject) Resources.Load ("TiroKawaii"), 1);
	}
	void Start(){
		vida = 500;
		nextFire = 0.0f;
	}

	void AttMostradorDeVida(){
		gerente.att (vida);
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "inimigo") {
			TomarDano ();
			AttMostradorDeVida();
		}
	}

	public void Atirar(){
	    if (Time.time > nextFire) {
			nextFire=Time.time+fireRate;
			pollTiros.AtivarGameObject(new Vector3(spawnTiro.position.x,0.0f));
		}
	
	}

	void Update(){
		//Debug.Log (1 / Time.deltaTime);
	//	Debug.Log (Time.time);


		if ((Input.GetKeyDown (KeyCode.Space))&&(Time.time>nextFire)) {
			nextFire=Time.time+fireRate;
			//Instantiate ((Resources.Load("TiroKawaii")),new Vector3(spawnTiro.position.x,0.0f), spawnTiro.rotation);
			pollTiros.AtivarGameObject(new Vector3(spawnTiro.position.x,0.0f));
		//	pollTiros.StringsOP();
		}
	}

	

	void FixedUpdate ()
	{
		float moveHorizontal;
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

		yield return 0;
	}

	public void TomarDano(){
		Debug.Log ("DOR");
		vida--;
		StartCoroutine (animacaoDano ());
		if (vida == 0) {	
			Destroy (gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	IEnumerator ficarInvencivel(){
		yield return 0;
	
	}




		}
	