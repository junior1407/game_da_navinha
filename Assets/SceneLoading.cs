using UnityEngine;
using System.Collections;
using System;

public class SceneLoading : MonoBehaviour {

	void Start(){

		StartCoroutine (Starto ());
	}

	IEnumerator Starto() {
		GameObject o;
		try{
			o = GameObject.Find ("Player-Itens") as GameObject;}
		catch(NullReferenceException){
			o = GameObject.Find ("Player-Itens(Clone)") as GameObject;

		}

		PlayerPropriedades p = o.GetComponent<PlayerPropriedades> ();
		p.FornecerIncrementos ();
	
		AsyncOperation async = Application.LoadLevelAsync("scene1");
		yield return async;

	}




}
