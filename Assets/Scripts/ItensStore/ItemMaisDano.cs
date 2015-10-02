using UnityEngine;
using System.Collections;

public class ItemMaisDano : BaseItem  {

	void Awake(){
		incremento = new DanoMais ();
		AttEstadoItem (1);

	}



	public override void AttEstadoItem (int level)
	{
		
		
		switch (level) {
			
			
			
		case 1:{
			preco = 1000;
			TextPreco.text=""+preco;
			incremento= new DanoMais(level);
			break;
			
		}
			
		case 2:{
			preco = 2000;
			TextPreco.text=""+preco;
			incremento= new DanoMais(level);
			break;
			
		}
		case 3:{
			preco = 3000;
			TextPreco.text=""+preco;
			incremento= new DanoMais(level);
			break;
			
		}
		default:
			break;
		}
	}
}
