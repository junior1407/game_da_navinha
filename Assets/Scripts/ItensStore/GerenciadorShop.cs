using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GerenciadorShop : MonoBehaviour {

	public BaseItem item1;
	public List<GameObject> listinha;



	void Awake(){
		listinha.AddRange(GameObject.FindGameObjectsWithTag ("item"));

		Debug.Log ("oi");

	}
		



}
