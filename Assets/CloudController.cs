using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 scale = Vector3.zero;
		scale.x = Random.Range (0.5f, 20f);
		scale.y = scale.x * Random.Range(0.5f, 1.2f);
		scale.z = scale.x * Random.Range(0.8f, 1.2f);

		transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
