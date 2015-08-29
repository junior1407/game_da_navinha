using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	public float speed;
	public float tempovivo;
	void Awake(){
		tempovivo = 0.0f;
		transform.rotation = Quaternion.identity;
	}
	void Start () {


	
	}

	public void resetar(){
		tempovivo=0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 0, 1) * speed*Time.deltaTime);
		tempovivo += Time.deltaTime;

		if (tempovivo>3.0f){
			tempovivo=0.0f;
			PlayerController.pollTiros.reutilizar(gameObject);
		}
	}
}
