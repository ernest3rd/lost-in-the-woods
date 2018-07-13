using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour {

	private Rigidbody rb;

	public Transform hull;
	public float speed = 10f;
	public float turnSpeed = 50f;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//float horizontalMovement = Input.GetAxis ("Horizontal");
		//float verticalMovement = Input.GetAxis ("Vertical");

		//transform.position += hull.forward * speed * Time.deltaTime;
		//hull.Rotate(verticalMovement * turnSpeed * Time.deltaTime, 0, -horizontalMovement * turnSpeed * Time.deltaTime);
	}

	void FixedUpdate(){
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		// Add rotation force
		rb.AddRelativeTorque(verticalMovement * turnSpeed, 0, -horizontalMovement * turnSpeed);

		// Add forward force
		rb.AddForce (hull.forward * speed, ForceMode.Acceleration);

		// Add turning force
		/*
		float rotZ = transform.localEulerAngles.z - 180f;
		float rotZAmount = (Mathf.Abs (rotZ) - 180f) / 180f;
		Debug.Log("Turning angle: " + rotZ);

		if (rotZAmount > 0.5f) {
			rotZAmount = -(rotZAmount - 1f);
		}
		if (rotZ > 0) {
			rotZAmount *= -1;
		}

		rb.AddTorque (0, rotZAmount * 500 * , 0);
		*/

		// Add lift
		float rotationOffset = 180f - Mathf.Abs(Vector3.Angle (Vector3.up, hull.up));
		//Debug.Log("Rotation offset: " + rotZAmount);
		Vector3 uplift = Vector3.up * Physics.gravity.magnitude * rb.mass * (rotationOffset / 180f);
		rb.AddForce (uplift);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("Hoop")) {
			Vector3 newPos = Vector3.zero;
			newPos.x = Random.Range (-100, 100);
			newPos.y = Random.Range (5, 20);
			newPos.z = Random.Range (-100, 100);
			collider.gameObject.transform.position = newPos;
			collider.gameObject.transform.Rotate (0, Random.Range (0, 360), 0);
		}
	}
}
