using UnityEngine;
using System.Collections;

public class GerenteSom : MonoBehaviour {

	public AudioSource comum;
	public AudioSource explosivo;

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)){
			comum.Play();
		}
	}

}
