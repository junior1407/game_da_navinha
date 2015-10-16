using UnityEngine;
using System.Collections;

public class VidaMais : BaseIncremento
{
	public int incremento;
	public VidaMais(){
		incremento = 0;
	}
	public VidaMais(int level){
		
		incremento = 0;
		if (level == 1) {
			incremento = 1;
		}
		
		if (level == 2) {
			incremento = 2;
		}
		if (level == 3) {
			incremento = 3;
		}
		//Debug.Log ("construido balasmais do level " + level + " com incremento" + incremento);
		
		
	}


	public override void aplicar ()
	{
		PlayerController.vida =3+ incremento;

	}

}

