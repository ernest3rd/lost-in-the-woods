using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    public Material mat;

	public GameObject tree;
	public GameObject cloud;

	public Vector3 worldSize = new Vector3 (100, 0, 100);
	public int numberOfTrees = 1000;
	public int numberOfClouds = 100;

	private GameObject worldElements;
    private Vector3 mousePos;

	void createElements(GameObject element, int amount, Vector3 center, Vector3 distance){
		
		for(int x=0; x<amount; x++){
			Vector3 pos = new Vector3(
				Random.Range(-distance.x, distance.x), 
				0,//Random.Range(-distance.y, distance.y), 
				Random.Range(-distance.z, distance.z)
			);
			//pos *= Random.Range(10f, distance.magnitude);
			//pos += center;
			GameObject newElement = Instantiate (element, pos, Quaternion.identity);
			newElement.transform.SetParent (worldElements.transform);
		}
	}

    // Use this for initialization
    void Start()
    {
        worldElements = new GameObject("World Elements");
        createElements(tree, numberOfTrees, Vector3.zero, worldSize);
        createElements(cloud, numberOfClouds, Vector3.up * 100f, worldSize + Vector3.up * 20f);

    }
}
