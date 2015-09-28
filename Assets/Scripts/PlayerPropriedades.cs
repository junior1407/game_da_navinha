using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPropriedades : MonoBehaviour
{
	public ItensPlayer inventario;
	public SaveGame save;
	public int BalasMais;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		inventario = new ItensPlayer ();
		save = new SaveGame ();


	}

	public void FornecerIncrementos(){

		if (save.BalasMais > 0) {

			inventario.addIncremento (new BalasMais (save.BalasMais));
		}
	

	}

	void Update(){
		BalasMais = save.BalasMais;
	
	}







}

