using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GerenciadorPool{
	//http://blog.ashwanik.in/2013/11/objects-pool-manager-in-unity3d.html
	Stack<GameObject> stackLivres;
	Stack<GameObject> stackBusy;

	public GerenciadorPool(GameObject meteoro,int quantidade){
		meteoro.gameObject.SetActive (false);
		stackBusy = new Stack<GameObject> ();
		stackLivres = new Stack<GameObject> ();
		for (int i=0; i<quantidade; i++) {
			stackLivres.Push(GameObject.Instantiate(meteoro));

		}
	}


	public void AtivarGameObject(Vector3 posicao){
		if (stackLivres.Count == 0) {
			//We have a problem houston

		}
		GameObject atual = stackLivres.Pop ();
		atual.transform.position = posicao;
		atual.SetActive (true);
		stackBusy.Push (atual);


	}





	public void reutilizar(GameObject a){
		a.SetActive (false);
		stackLivres.Push (a);


	}









}
