using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GerenciadorPool{
	//http://blog.ashwanik.in/2013/11/objects-pool-manager-in-unity3d.html
	GameObject prefab;
	Stack<GameObject> stackLivres;
	Stack<GameObject> stackBusy;
	//List <GameObject> stackBusy;

	public GerenciadorPool(GameObject _meteoro,int quantidade){
		_meteoro.gameObject.SetActive (false);
		prefab = _meteoro;
		//stackBusy = new List<GameObject> ();
		stackBusy = new Stack<GameObject> ();
		stackLivres = new Stack<GameObject> ();
		for (int i=0; i<quantidade; i++) {
			stackLivres.Push(GameObject.Instantiate(prefab));

		}
	}



	public void AtivarGameObject(Vector3 posicao){
	

		if (stackLivres.Count == 0) {
			stackLivres.Push(GameObject.Instantiate(prefab));

		}

		GameObject atual = stackLivres.Pop ();

		atual.transform.position = posicao;
		atual.SetActive (true);
		stackBusy.Push (atual);
		if (prefab.tag != "tiro") {

Debug.Log ("Busy: " + stackBusy.Count + " Livre:" + stackLivres.Count); 
		}
	}





	public void reutilizar(GameObject a){
	

	

		stackBusy.Pop ();
		a.SetActive (false);
		stackLivres.Push (a);
	
		
	}
	
	
	
	
	
	
	
	
	
}
