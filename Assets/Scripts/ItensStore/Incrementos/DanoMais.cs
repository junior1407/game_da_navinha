using UnityEngine;
using System.Collections;

public class DanoMais : BaseIncremento
{

	public float incremento;
	public DanoMais(){
		incremento = 0.5f;
	}


	public override void aplicar ()
	{
		PlayerController.dano += incremento;
		//Debug.Log ("EU TBM FUI APLICADO QUE DLC");
	}

}

