using UnityEngine;
using System.Collections;

public class VelocidadeMais : BaseIncremento
{
	
	public float incremento;
	public VelocidadeMais(){
		incremento = 0.0f;
	}
	public VelocidadeMais(int level){
		
		incremento = 0.0f;
		if (level == 1) {
			incremento = 1.0f;
		}
		
		if (level == 2) {
			incremento = 2.0f;
		}
		if (level == 3) {
			incremento = 2.5f;
		}
		//Debug.Log ("construido balasmais do level " + level + " com incremento" + incremento);
		
		
	}
	
	public override void aplicar ()
	{
		PlayerController.speed =8.0f+ incremento;

	}
	
}



