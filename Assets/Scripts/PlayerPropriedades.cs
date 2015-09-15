using UnityEngine;
using System.Collections;

public class PlayerPropriedades : MonoBehaviour
{
	public ItensPlayer inventario;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		inventario = new ItensPlayer ();
	}



}

