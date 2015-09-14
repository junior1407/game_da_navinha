using UnityEngine;
using System.Collections;

public class BalasMais: BaseIncremento
{


	public int incremento;
	public BalasMais(){
		incremento = 10;
	}

	
	public override void aplicar ()
	{
		PlayerController.balas += incremento;

	}
	




}

