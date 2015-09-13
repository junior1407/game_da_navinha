using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour
{
	public GameObject Descricao;
	public bool ocultado;
	//public GameObject anterior;
	public Transform transform_filho;
	public Vector3 posicaoEu;
	public Vector3 posicaoinvi;
	public Vector2 teste;
	public float distancia;

	void Start(){
	//	ocultado = true;
		transform_filho = Descricao.GetComponent<Transform> ();
		posicaoEu = transform.position;
		posicaoinvi = Descricao.transform.position;
		distancia = -posicaoEu.y + posicaoinvi.y + 12;
		Descricao.transform.localPosition = new Vector3 (0, 0, 0);

	}

	public void OcultarDescolutar(){ 
		if (ocultado == false) {

			ocultado=true;
			transform_filho.Translate(new Vector3(0,distancia));
			///Descricao.transform.position= new Vector3(tran
			//ocultado=true;

		}
		else { // Se ele tiver oculto.
			ocultado=false;
			transform_filho.Translate(new Vector3(0,-distancia));
			//rectTransform.position= new Vector3
			//Descricao.transform.Translate(0,transform.position.y-GetComponent<RectTransform>().sizeDelta.y,0);
		//	rectTransform.position= new Vector3(transformz.position.x,transformz.position.y+50);
		}
	}

	public void mover (){}

	void Update(){
		posicaoEu = transform.position;
		posicaoinvi = Descricao.transform.localPosition;

	}

}

