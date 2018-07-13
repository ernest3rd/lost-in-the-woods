using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomSizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 scale = Vector3.zero;
		scale.x = Random.Range (0.5f, 4f);
		scale.y = scale.x * Random.Range (0.5f, 1.5f);
		scale.z = 1;

		transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
