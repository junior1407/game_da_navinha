using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour
{
	public GameObject Descricao;
	public bool ocultado;
	//public GameObject anterior;
	public Transform transform_filho;
	public Vector2 teste;

	void Start(){
	//	ocultado = true;
		transform_filho = Descricao.GetComponent<Transform> ();


	}

	public void OcultarDescolutar(){ 
		if (ocultado == false) {

			ocultado=true;
			transform_filho.Translate(new Vector3(0,60));
			///Descricao.transform.position= new Vector3(tran
			//ocultado=true;

		}
		else { // Se ele tiver oculto.
			ocultado=false;
			transform_filho.Translate(new Vector3(0,-60));
			//rectTransform.position= new Vector3
			//Descricao.transform.Translate(0,transform.position.y-GetComponent<RectTransform>().sizeDelta.y,0);
		//	rectTransform.position= new Vector3(transformz.position.x,transformz.position.y+50);
		}
	}

	public void mover (){}

	void Update(){
		Debug.Log (transform.position.y -transform_filho.position.y);
	}

}

