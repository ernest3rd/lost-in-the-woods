using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public GameObject mainCamera;

	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private GameObject closestObject;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float verticalMovement = Input.GetAxisRaw ("Vertical");
		float horizontalMovement = Input.GetAxisRaw ("Horizontal");

		Vector3 movement = mainCamera.transform.right * horizontalMovement +
                           mainCamera.transform.forward * verticalMovement;

		transform.position += movement.normalized * speed * Time.deltaTime;

		if (movement.magnitude > 0) {
			animator.Play ("PlayerWalking");
		} else {
			animator.Play ("PlayerStanding");
		}

		if (horizontalMovement > 0) {
			spriteRenderer.flipX = false;
		} else if (horizontalMovement < 0) {
			spriteRenderer.flipX = true;
		}

		if (closestObject && Input.GetButtonDown ("Fire1")) {
			if (closestObject.CompareTag("Tree")) {
				closestObject.GetComponent<PinetreeController> ().ToggleMarking ();
			}
		}
	}

	void OnCollision(Collision collision){
		//transform.position += collision.impulse;
	}

	void OnTriggerStay(Collider collider){
		closestObject = collider.gameObject;
	}

	void OnTriggerExit(Collider collider){
		closestObject = null;
	}
}
