using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);
	//private Animator animator;


	// Use this for initialization
	void Start () {

		//animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		var absVelX = Mathf.Abs (rigidbody2D.velocity.x); //establecer la velocidad (velocidad absoluta de eje X)
		var forceX = 0f;
		var forceY = 0f; //fuerza que le doy al personaje

		//Calcular velocityX
		if (Input.GetKey ("right")) {
						if (absVelX < maxVelocity.x)
								forceX = speed;
						this.transform.localScale = new Vector3 (1, 1, 1);
				} else if (Input.GetKey ("left")) {
						if (absVelX < maxVelocity.x)
								forceX = -speed;
						this.transform.localScale = new Vector3 (-1, 1, 1);//para que gire el personaje
				}
		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	
	}
}
