using UnityEngine;
using System.Collections;

public class GirarForeverXYZ : MonoBehaviour {

	public float velocidade_rotacao;
	void FixedUpdate () {
		transform.Rotate (new Vector3 (1.0f, 1.0f, 1.0f)*velocidade_rotacao);
	}
}
