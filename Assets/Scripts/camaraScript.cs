using UnityEngine;
using System.Collections;

public class camaraScript : MonoBehaviour {

	public Transform target; //transformar la posicion de la camara con respecto a target
	public float damping = 1;
	public float lookAheadFactor = 3; //la camara se adelanta un poco al jugador
	public float lookAheadReturnSpeed = 0.5f; //cuando player deja de moverse, la camara regresa a la posicion del player
	public float lookAheadMoveThreshold = 0.1f; //retardo de movimiento de la camara con respecto a movimiento de player
	public float yPosRestiction = -1; 

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	// Use this for initialization
	void Start () {
		lastTargetPosition = target.position; //colocarse en la misma posicion que target
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x; //comprobar la posicion en x de target
		
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold; //Cuando xMoveDelta es mayor que lookAheadMoveThreshold la camara se desplaza
		
		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	//el tiempo que tarda en regresar al jugador
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
		
		newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y,yPosRestiction,Mathf.Infinity), newPos.z);
		transform.position = newPos;
		
		lastTargetPosition = target.position;		
	}
}