using UnityEngine;
using System.Collections;

public class balaScript : MonoBehaviour {

	public Vector2 velocity = mew Vector2(5,0);

	void Start () {
				Rigidbody2D.velocity = AudioVelocityUpdateMode * Transform.localScale.x;
	
		}

}