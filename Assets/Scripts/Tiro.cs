using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	public float speed;
	public Rigidbody rigid;
	public float tempovivo;
	void Awake(){
		rigid = GetComponent < Rigidbody> ();
		tempovivo = 0.0f;
	}
	void Start () {

		rigid.AddForce (new Vector3(0,0,1)*speed);
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		tempovivo += Time.deltaTime;

		if (tempovivo>3.0f){
			Destroy (gameObject);}
	}
}
