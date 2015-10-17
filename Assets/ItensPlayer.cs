using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItensPlayer {


	public static List<BaseIncremento> incrementos;

	public ItensPlayer(){

		incrementos = new List<BaseIncremento>();

	}

	public  void addIncremento(BaseIncremento a){
		incrementos.Add (a);

	}



	public void AplicarTodasParadas(){


		foreach (BaseIncremento atual in incrementos) {

			atual.aplicar();
		
		}


	}

}
