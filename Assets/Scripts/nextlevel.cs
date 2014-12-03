using UnityEngine;
using System.Collections;

public class nextlevel : MonoBehaviour {

	public string nombreNivel; //nombre escena que vamos a cargar
	public float tiempoespera = 3f;
	bool cargando = false; //player esta dentro del trigger

	void OnTriggerStay2D (Collider2D target){
		if (target.transform.tag == "Player") {
			//Application.LoadLevel (nombreNivel);
			if(!cargando)
				StartCoroutine(cargaNivel());
		}
	}

	void OntriggerExit2D(Collider2D target) {
				cargando = false;
		}
	void OnTriggerEnter2D(Collider target) {
				cargando = true;
		}
	IEnumerator cargaNivel() {
				cargando = true;
				yield return new WaitForSeconds (tiempoespera);
				if (cargando)
						Application.LoadLevel (nombreNivel);
		}

}
