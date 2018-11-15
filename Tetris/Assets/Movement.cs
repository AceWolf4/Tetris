using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    float lastFall = 0;

	// Use this for initialization
	void Start () {
        if (!isValidGridPos())
        {
            Debug.Log("game over");
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.2f, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(0.2f, 0, 0);
        }

        //move right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.2f, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-0.2f, 0, 0);
        }

        //rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            if (isValidGridPos())
                updateGrid();
            else
                transform.Rotate(0, 0, 90);
        }

        //fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time -lastFall>=1)
        {
            transform.position += new Vector3(0, -0.2f, 0);

            if (isValidGridPos())
                updateGrid();
            else
            {
                transform.position += new Vector3(0, 0.2f, 0);

                Grid.deleteFullRows();
                FindObjectOfType<Spawner>().spawnNext();

                enabled = false;
            }

            lastFall = Time.time;
        }
    }
    
    bool isValidGridPos()
    {
        foreach(Transform child in transform)
        {
            Vector2 v = child.position;

            if (!Grid.insideBorder(v))
            {
                Debug.Log("not inside: " + v);
                return false;
            }
            Debug.Log((int)(v.x / 0.2f));
            if(Grid.grid[(int)(v.x/0.2f),(int)(v.y/0.2f)]!=null && Grid.grid[(int)(v.x / 0.2f), (int)(v.y / 0.2f)].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        for(int y = 0; y < Grid.h; y++)
            for(int x = 0; x > Grid.w; x++)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;
        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
