using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientTowardsCamera : MonoBehaviour {

	private Camera myCamera;

	// Use this for initialization
	void Start () {
		myCamera = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		//transform.rotation = myCamera.transform.rotation;
		transform.LookAt(myCamera.transform);
		Vector3 angles = transform.eulerAngles;
		angles.x = 0;
		angles.z = 0;
		transform.eulerAngles = angles;
	}
}
