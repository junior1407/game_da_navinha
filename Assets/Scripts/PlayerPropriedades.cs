using UnityEngine;
using System.Collections;

public class PlayerPropriedades : MonoBehaviour
{
	public ItensPlayer inventario;
	public SaveGame save;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		inventario = new ItensPlayer ();
		save = new SaveGame ();
	}

	public void FornecerIncrementos(){

		if (save.BalasMais > 0) {

			inventario.addIncremento (new BalasMais (2));
		}
	

	}







}

