using UnityEngine;
using System.Collections;

public class MeteoroQuebraHard : MeteoroBase
{
	 void Awake(){
		vida_max = 3;
	}
	public override void DestruirItSelf(){
		
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_hard.reutilizar (gameObject);
		
		
	}

}

