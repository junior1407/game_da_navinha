using UnityEngine;
using System.Collections;

public class DanoMais : BaseIncremento
{

	public float incremento;
	public DanoMais(){
		incremento = 0.0f;
	}
	public DanoMais(int level){
		
		incremento = 0.0f;
		if (level == 1) {
			incremento = 0.5f	;
		}
		
		if (level == 2) {
			incremento = 1.0f;
		}
		if (level == 3) {
			incremento = 2.0f;
		}
		//Debug.Log ("construido balasmais do level " + level + " com incremento" + incremento);

	}



	public override void aplicar ()
	{
		PlayerController.dano =1.0f+ incremento;
		//Debug.Log ("EU TBM FUI APLICADO QUE DLC");
	}

}

