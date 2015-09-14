using UnityEngine;
using System.Collections;

public class DanoMais : BaseIncremento
{

	public int incremento;


	public override void aplicar ()
	{
		PlayerController.dano += 1;
	}

}

