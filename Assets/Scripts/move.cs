using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public float speed = 10.0f;
	public float tilt=1.1f;
				
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		
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
		}
	