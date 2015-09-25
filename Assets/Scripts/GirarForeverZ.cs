using UnityEngine;
using System.Collections;

public class GirarForeverZ : MonoBehaviour
{

	public float velocidade_rotacao;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (0, 0,1.0f) * velocidade_rotacao);
		
	}
}

