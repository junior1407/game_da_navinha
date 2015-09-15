using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItensPlayer {

	public int gold;
	public static List<BaseIncremento> incrementos;
	public ItensPlayer(){
		gold = 100;
		incrementos = new List<BaseIncremento>();

	}

	public  void addIncremento(BaseIncremento a){
		incrementos.Add (a);
		Debug.Log (incrementos [0]);
	}

	public void AplicarTodasParadas(){
		foreach (BaseIncremento atual in incrementos) {
			atual.aplicar();
		}


	}

}
