using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPropriedades : MonoBehaviour
{
	public ItensPlayer inventario;
	public SaveGame save;


	void Awake(){
		DontDestroyOnLoad (gameObject);
		inventario = new ItensPlayer ();
	
		save = new SaveGame ();
		save.gold = 0;


	}

	public void Load(){
	//	UnityPluginForWindowsPhone.SaveGame savetemp = UnityPluginForWindowsPhone.Class1.Load ();
	//	save = converterSave (savetemp);

	}

	public void Salvar(){
	//	UnityPluginForWindowsPhone.Class1.Save (new UnityPluginForWindowsPhone.SaveGame (save.gold, save.BalasMais, save.DanoMais, save.SpeedMais, save.LifeMais));

	}

//	public SaveGame converterSave(UnityPluginForWindowsPhone.SaveGame save2){
	//	return new SaveGame (save2.BalasMais, save2.DanoMais, save2.SpeedMais, save2.LifeMais, save2.gold);
	//}
	
	public void FornecerIncrementos(){

		if (save.BalasMais > 0) {
		//	Debug.Log ("addando mais balas");
			inventario.addIncremento (new BalasMais (save.BalasMais));
		}
		if (save.DanoMais > 0) {
		//	Debug.Log ("addando mais dano");
			inventario.addIncremento (new DanoMais (save.DanoMais));
		}
		if (save.SpeedMais > 0) {
		//	Debug.Log ("addando mais speed");
			inventario.addIncremento (new VelocidadeMais (save.SpeedMais));
		}
		if (save.LifeMais > 0) {
			//Debug.Log ("addando mais vida");
			inventario.addIncremento (new VidaMais (save.LifeMais));
		}

	

	}

	void Update(){


	}







}

