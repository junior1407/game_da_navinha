using UnityEngine;
using System.Collections;

public class BalasMais: BaseIncremento
{


	public int incremento;
	public BalasMais(int level){

		incremento = 0;
		if (level == 1) {
			incremento = 50;
		}

		if (level == 2) {
			incremento = 100;
		}
		if (level == 3) {
			incremento = 150;
		}
		//Debug.Log ("construido balasmais do level " + level + " com incremento" + incremento);


	}

	public BalasMais(){
		//Debug.Log ("Balas Mais Construido Incremento 0");
		incremento = 0;

	}

	
	public override void aplicar ()
	{
		PlayerController.balas =50+ incremento;
	//	Debug.Log ("KRL EU FUI APLICADO");


	}
	




}

