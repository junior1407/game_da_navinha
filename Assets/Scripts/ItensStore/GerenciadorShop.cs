using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GerenciadorShop : MonoBehaviour {

	public BaseItem item1;
	public List<BaseItem> listinha;




	void Start(){
		listinha.Add (item1);

	}

	public void mover(BaseItem atual){

		atual.mover ();
	}
}
