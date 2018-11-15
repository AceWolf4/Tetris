using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] TetrisShapes;
    

	// Use this for initialization
	void Start () {
        spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void spawnNext()
    {
        Instantiate(TetrisShapes[Random.Range(0, TetrisShapes.Length)], transform.position + new Vector3(0, -2.4f, 0), Quaternion.identity);
    }
}
