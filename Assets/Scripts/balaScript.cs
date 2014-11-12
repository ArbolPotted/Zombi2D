using UnityEngine;
using System.Collections;

public class balaScript : MonoBehaviour {

	public Vector2 velocity = new Vector2(5,0);
	public GameObject particulas;
	//public GameObject blood;
	//public int damage = 5;

	void Start () {
				//rigidbody2D.velocity = velocity * transform.localScale.x;
				rigidbody2D.AddForce (velocity * transform.localScale.x, ForceMode2D.Impulse);
				//Invoke ("onDestroy", 0.2f);
		}
		void OnCollisionEnter2D(Collision2D target){
		Destroy (gameObject);
		//onDestroy();

		}
	void onDestroy(){
				var clone = Instantiate (particulas, transform.position, Quaternion.identity)
			as GameObject;
				Destroy (clone, 1);
				Destroy (gameObject);
		}
	
	}

