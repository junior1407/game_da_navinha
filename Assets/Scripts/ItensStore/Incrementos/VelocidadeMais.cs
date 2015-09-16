using UnityEngine;
using System.Collections;

public class VelocidadeMais : BaseIncremento
{
	
	public float incremento;
	public VelocidadeMais(){
		incremento = 1.0f;
	}
	
	
	public override void aplicar ()
	{
		PlayerController.speed += incremento;

	}
	
}



