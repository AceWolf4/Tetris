using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] TetrisShapes;

    private bool canSpawn = false;

	// Use this for initialization
	void Start () {
        Instantiate(TetrisShapes[Random.Range(0, 6)],transform.position+new Vector3(0,-1,0),Quaternion.identity);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (canSpawn)
        {
            Instantiate(TetrisShapes[Random.Range(0, 6)], transform.position + new Vector3(0, -1, 0), Quaternion.identity);
        }
	}
}
