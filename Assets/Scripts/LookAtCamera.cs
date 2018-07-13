using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	private Camera myCamera;

	// Use this for initialization
	void Start () {
		myCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = myCamera.transform.rotation;
	}
}
