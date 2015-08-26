using UnityEngine;
using System.Collections;

public class Gerenciador_UI {
	public  GameObject vida3;
		public  GameObject vida2;
	public  GameObject vida1;
	public Gerenciador_UI(GameObject v3,GameObject v2, GameObject v1){
		vida3 = v3;
		vida2 = v2;
		vida1 = v1;
	}




	public void att(int life){

		if (life < 3) {

			vida3.SetActive (false);
		}
			if (life < 2)
				vida2.SetActive (false);
		   if (life<1)
				vida1.SetActive (false);

			}
}

