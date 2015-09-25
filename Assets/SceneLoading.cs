using UnityEngine;
using System.Collections;

public class SceneLoading : MonoBehaviour {

	void Awake(){
		Debug.Log ("rodei");
		StartCoroutine (Start ());
	}

	IEnumerator Start() {
		GameObject o = GameObject.Find ("Player-Itens") as GameObject;
		PlayerPropriedades p = o.GetComponent<PlayerPropriedades> ();
		p.FornecerIncrementos ();
		Debug.Log ("rodei");
		AsyncOperation async = Application.LoadLevelAsync("scene1");
		yield return async;
		Debug.Log("Loading complete");
	}




}
