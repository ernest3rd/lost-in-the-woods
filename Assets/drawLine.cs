using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {
    private LineRenderer lr;
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

	// Use this for initialization
	void Start () {
        positions.Add(transform.position);
        positions.Add(transform.position);
	}

    void Update()
    {
        positions[positions.Count] = transform.position;
        lr.positionCount = positions.Count;
        lr.SetPositions(positions.ToArray());
        if (Vector3.Distance(positions[positions.Count], positions[positions.Count - 1]) > 1)
        {
            positions.Add(transform.position);
        }
    }
}
