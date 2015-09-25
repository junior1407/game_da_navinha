using UnityEngine;
using System.Collections;

public class ItemVidaMais : BaseItem
{
	#region implemented abstract members of BaseItem
	public override void AttEstadoItem (int level)
	{
		throw new System.NotImplementedException ();
	}
	#endregion

	void Awake(){
		incremento = new VidaMais ();
	}
}

