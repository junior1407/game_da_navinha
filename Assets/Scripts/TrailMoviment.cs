using UnityEngine;
using System.Collections;

public class TrailMoviment : MonoBehaviour {
	float speed = 10f;
	TrailRenderer trail;
	void FixedUpdate () {
		trail = gameObject.GetComponent<TrailRenderer>();		

			trail.transform.Translate (new Vector3 (0, 0, -1) * speed * Time.deltaTime);
		}
	}


