using UnityEngine;
using System.Collections;

public class MeteoroInfinito : MeteoroBase
{
	public override void DestruirItSelf ()
	{
		vida_atual = vida_max;
		atualizar_velocidadejogo ();
		GameController.pollMeteoros_indestruct.reutilizar (gameObject);
	}

	void Awake(){
		vida_max = 10;
	}
}

