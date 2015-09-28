using UnityEngine;
using System.Collections;
using System;

public class SceneLoading : MonoBehaviour {

	void Start(){

		StartCoroutine (Starto ());
	}

	IEnumerator Starto() {
		Debug.Log ("oi");
		PlayerPropriedades p;
		GameObject o;
		try{
			o = GameObject.Find ("Player-Itens") as GameObject;
	        p = o.GetComponent<PlayerPropriedades> ();
			p.FornecerIncrementos ();}
		catch(NullReferenceException){
			Debug.Log ("erro lancado");
			o = GameObject.FindGameObjectWithTag("save") as GameObject;
			p = o.GetComponent<PlayerPropriedades> ();
			p.FornecerIncrementos ();

		}

	

	
		AsyncOperation async = Application.LoadLevelAsync("scene1");
		yield return async;

	}




}
