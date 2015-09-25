using UnityEngine;
using System.Collections;

public class ItemMaisDano : BaseItem  {

	void Awake(){
		incremento = new DanoMais ();

	}



	#region implemented abstract members of BaseItem
	public override void AttEstadoItem (int level)
	{
		throw new System.NotImplementedException ();
	}
	#endregion
}
