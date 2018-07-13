using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAirplane : MonoBehaviour {

	public Transform target;
	public Transform hull;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		//Vector3 _offset = target.forward + target.up;
		//_offset.x *= offset.x;
		//_offset.y *= offset.y;
		//_offset.z *= offset.z;
		/*
		Vector3 _offset = hull.forward;
		_offset.y = 0;
		_offset = _offset.normalized;

		Vector3 direction = (target.position - _offset).normalized;

		transform.position = (target.position - _offset);
		transform.LookAt (target);

		transform.position += offset;
		transform.LookAt (target);
		*/

		Vector3 eulers = hull.eulerAngles;
		eulers.x = 0;
		eulers.z = 0;
		transform.eulerAngles = eulers;

		transform.position = target.position + transform.forward * offset.z + transform.up * offset.y + transform.right * offset.x;

		transform.LookAt (target);
	}
}
