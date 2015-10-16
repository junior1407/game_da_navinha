using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPropriedades : MonoBehaviour
{
	public ItensPlayer inventario;
	public SaveGame save;
	public int BalasMais;
	public int DanoMais;
	public int gold;
	public int vidaMais;
	public int SpeedMais;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		inventario = new ItensPlayer ();
		save = new SaveGame ();


	}

	public void FornecerIncrementos(){

		if (save.BalasMais > 0) {
			Debug.Log ("addando mais balas");
			inventario.addIncremento (new BalasMais (save.BalasMais));
		}
		if (save.DanoMais > 0) {
			Debug.Log ("addando mais dano");
			inventario.addIncremento (new DanoMais (save.DanoMais));
		}
		if (save.SpeedMais > 0) {
			Debug.Log ("addando mais speed");
			inventario.addIncremento (new VelocidadeMais (save.SpeedMais));
		}
		if (save.LifeMais > 0) {
			Debug.Log ("addando mais vida");
			inventario.addIncremento (new VidaMais (save.LifeMais));
		}

	

	}

	void Update(){
		BalasMais = save.BalasMais;
		DanoMais = save.DanoMais;
		gold = save.gold;
		SpeedMais = save.SpeedMais;
		vidaMais = save.LifeMais;

	}







}

