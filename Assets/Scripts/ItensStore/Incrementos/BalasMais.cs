using UnityEngine;
using System.Collections;

public class BalasMais: BaseIncremento
{


	public int incremento;
	public BalasMais(int level){

		incremento = 0;
		if (level == 1) {
			incremento = 15;
		}

		if (level == 2) {
			incremento = 35;
		}
		if (level == 3) {
			incremento = 50;
		}
		//Debug.Log ("construido balasmais do level " + level + " com incremento" + incremento);


	}

	public BalasMais(){
		//Debug.Log ("Balas Mais Construido Incremento 0");
		incremento = 0;

	}

	
	public override void aplicar ()
	{
		PlayerController.balas += incremento;
	//	Debug.Log ("KRL EU FUI APLICADO");


	}
	




}

