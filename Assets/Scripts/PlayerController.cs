using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



	BoxCollider colisor;
	public  int vida;
	public float speed = 10.0f;
	public float tilt=3.2f;
	public Transform spawnTiro;
	public float fireRate;
	public float nextFire;
			
	void Awake(){
		colisor = GetComponent<BoxCollider> ();
	}
	void Start(){
		vida = 3;
		nextFire = 0.0f;

	}


	void OnTriggerEnter(Collider target){
		if (target.tag == "inimigo") {
			TomarDano ();Debug.Log ("dano");
		}




	}

	public void Atirar(){
	    if (Time.time > nextFire) {
			nextFire=Time.time+fireRate;
			Instantiate ((Resources.Load("TiroKawaii")),new Vector3(spawnTiro.position.x,0.0f), spawnTiro.rotation);
		}
	
	}

	void Update(){
		//Debug.Log (1 / Time.deltaTime);
	//	Debug.Log (Time.time);


		if ((Input.GetKeyDown (KeyCode.Space))&&(Time.time>nextFire)) {
			nextFire=Time.time+fireRate;
			Instantiate ((Resources.Load("TiroKawaii")),new Vector3(spawnTiro.position.x,0.0f), spawnTiro.rotation);
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

	public void TomarDano(){
		vida--;
		if (vida == 0) {	
			Destroy (gameObject);
		}

	}

	IEnumerator ficarInvencivel(){
		yield return 0;
	
	}




		}
	