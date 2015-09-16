using UnityEngine;
using System.Collections;

public class VidaMais : BaseIncremento
{
	public int incremento;
	public VidaMais(){
		incremento = 1;
	}



	public override void aplicar ()
	{
		PlayerController.vida += incremento;

	}

}

