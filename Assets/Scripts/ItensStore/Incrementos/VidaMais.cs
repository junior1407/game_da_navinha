using UnityEngine;
using System.Collections;

public class VidaMais : BaseIncremento
{
	public int incremento;



	public override void aplicar ()
	{
		PlayerController.vida += 1;

	}

}

