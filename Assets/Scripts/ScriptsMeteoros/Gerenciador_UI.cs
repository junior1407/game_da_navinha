using UnityEngine;
using System.Collections;

public class Gerenciador_UI {
	public GameObject vida6;
	public GameObject vida5;
	public GameObject vida4;
	public  GameObject vida3;
		public  GameObject vida2;
	public  GameObject vida1;
	public Gerenciador_UI(GameObject v6,GameObject v5,GameObject v4,GameObject v3,GameObject v2, GameObject v1){
		vida6 = v6;
		vida5 = v5;
		vida4 = v4;
		vida3 = v3;
		vida2 = v2;
		vida1 = v1;
	}



	public void confere(int life){
		vida4.SetActive (false);
		vida5.SetActive (false);
		vida6.SetActive (false);

		Debug.Log ("recebi " + life);

		if (life > 3) {
			vida4.SetActive (true);
		
		}
		if (life > 4) {
			vida5.SetActive (true);
		}
		if (life > 5) {
		
			vida6.SetActive (true);
		}


	
	}
				
	public void att(int life){
		Debug.Log ("sera que rodei?");
		if (life == 5) {
			vida6.SetActive(false);
		}
		if (life < 5) {

			vida5.SetActive (false);
		}
		if (life < 4) {
			vida4.SetActive (false);
		}
        if (life < 3)
			vida3.SetActive (false);

			if (life < 2)
				vida2.SetActive (false);
		   if (life<1)
				vida1.SetActive (false);

			}
}

