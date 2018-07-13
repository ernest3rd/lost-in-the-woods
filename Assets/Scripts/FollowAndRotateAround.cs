using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRotateAround : MonoBehaviour {

	public Transform target;
    public float maxRotationSpeed = 10f;

	private Vector3 lastPosition;
	private float rotateDegrees;
    private float rotationSpeed;

    void Start()
    {
        lastPosition = target.position;
        Random.InitState((int)System.DateTime.UtcNow.Ticks);
        RandomizeRotation();
    }

	void LateUpdate ()
    {
        // Calculate the amount of rotation for this update cycle based on 
        // the amount of movement of the target
        float rotation = (target.position - lastPosition).magnitude *
                         rotationSpeed * Time.deltaTime;
        rotateDegrees -= Mathf.Abs(rotation);
        transform.Rotate(Vector3.up, rotation);
        if (rotateDegrees < 0f)
        {
            // When the rotation target has been reached randomize a new one
            RandomizeRotation();
        }

        // Keep track of the last position of the target
        lastPosition = target.position;
        transform.position = target.position;
	}

    void RandomizeRotation()
    {
        // Randomize how many degrees the camera should rotate in total
        rotateDegrees = Random.Range(0f, 20f);

        // Randomize rotation speed and direction
        rotationSpeed = 0;
        while (Mathf.Abs(rotationSpeed) < maxRotationSpeed * 0.2f)
        {
            rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        }
    }
}
