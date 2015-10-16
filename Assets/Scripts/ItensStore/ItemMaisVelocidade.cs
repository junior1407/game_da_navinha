using UnityEngine;
using System.Collections;

public class ItemMaisVelocidade : BaseItem {


	
	void Awake(){
		incremento = new VelocidadeMais ();
		AttEstadoItem (1);
		
	}


	public override void AttEstadoItem (int level)
	{
		
		switch (level) {
			
			
			
		case 1:{
			preco = 500;
			TextPreco.text=""+preco;
			incremento= new VelocidadeMais(level);
			break;
			
		}
			
		case 2:{
			preco = 1000;
			TextPreco.text=""+preco;
			incremento= new VelocidadeMais(level);
			break;
			
		}
		case 3:{
			preco = 1500;
			TextPreco.text=""+preco;
			incremento= new VelocidadeMais(level);
			break;
			
		}
		default:
			break;
		}
	}

	}


