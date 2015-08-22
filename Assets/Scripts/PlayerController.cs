using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 10.0f;
	public float tilt=3.2f;
			



	

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
		}
	