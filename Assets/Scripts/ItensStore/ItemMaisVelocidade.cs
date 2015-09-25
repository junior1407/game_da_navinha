using UnityEngine;
using System.Collections;

public class ItemMaisVelocidade : BaseItem {


	void Awake(){
		incremento = new VelocidadeMais ();
	}


	#region implemented abstract members of BaseItem
	public override void AttEstadoItem (int level)
	{
		throw new System.NotImplementedException ();
	}
	#endregion
	}


