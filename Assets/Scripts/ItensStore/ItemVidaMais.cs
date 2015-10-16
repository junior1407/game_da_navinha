using UnityEngine;
using System.Collections;

public class ItemVidaMais : BaseItem
{
	void Awake(){
		incremento = new VidaMais ();
		AttEstadoItem (1);
		
		//AttEstadoItem (0);
		
	}
	public override void AttEstadoItem (int level)
	{
		
		switch (level) {
			
			
			
		case 1:{
			preco = 1500;
			TextPreco.text=""+preco;
			incremento= new VidaMais(level);
			break;
			
		}
			
		case 2:{
			preco = 3000;
			TextPreco.text=""+preco;
			incremento= new VidaMais(level);
			break;
			
		}
		case 3:{
			preco = 4500;
			TextPreco.text=""+preco;
			incremento= new VidaMais(level);
			break;
			
		}
		default:
			break;
		}
	}



}

