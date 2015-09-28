using UnityEngine;
using System.Collections;

public class ItemMaisBalas : BaseItem
{






	public override void AttEstadoItem (int level)
	{


		switch (level) {

		

		case 1:{
			preco = 1;
			TextPreco.text=""+preco;
			incremento= new BalasMais(level);
			break;

		}
		
		case 2:{
			preco = 2;
			TextPreco.text=""+preco;
			incremento= new BalasMais(level);
			break;

		}
		case 3:{
			preco = 3;
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


	}


}

