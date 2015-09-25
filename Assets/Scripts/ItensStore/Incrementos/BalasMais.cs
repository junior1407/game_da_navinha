using UnityEngine;
using System.Collections;

public class BalasMais: BaseIncremento
{


	public int incremento;
	public BalasMais(int level){
		incremento = 0;
		if (level == 1) {
			incremento += 15;
		}

		if (level == 2) {
			incremento += 35;
		}
		if (level == 3) {
			incremento += 50;
		}


	}

	public BalasMais(){
		Debug.Log ("construido2  "+incremento);
		incremento = 10;

	}

	
	public override void aplicar ()
	{
		PlayerController.balas += incremento;
		Debug.Log ("KRL EU FUI APLICADO");
		Debug.Log (incremento);

	}
	




}

