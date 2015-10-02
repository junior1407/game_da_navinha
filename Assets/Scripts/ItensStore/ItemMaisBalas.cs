	using UnityEngine;
using System.Collections;

public class ItemMaisBalas : BaseItem
{






	public override void AttEstadoItem (int level)
	{


		switch (level) {

		

		case 1:{
			preco = 500;
			TextPreco.text=""+preco;
			incremento= new BalasMais(level);
			break;

		}
		
		case 2:{
			preco = 1000;
			TextPreco.text=""+preco;
			incremento= new BalasMais(level);
			break;

		}
		case 3:{
			preco = 1500;
			TextPreco.text=""+preco;
			incremento= new BalasMais(level);
			break;
			
		}
		default:
			break;
		}
	}


	void Awake(){
		incremento = new BalasMais ();
		AttEstadoItem (1);

		//AttEstadoItem (0);

	}


}

