using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private int column;
    [SerializeField]
    private int row;
    [SerializeField]
    private bool createMap;
    [SerializeField]
    private bool once = false;

    [SerializeField]
    private float horizontalX = 1.74f;
    [SerializeField]
    private float verticalX = 0.866f;
    [SerializeField]
    private float verticalZ = 0.54f;
    // Use this for initialization
    // Window
 
    private void CreateMap()
    {
        float x = 0;
        float z = 0;
        float aux = verticalX;
        for(int j = 0; j < row; j++)
        {
            for (int i = 0; i < column; i++)
            {
                Instantiate(tile, new Vector3(x, 0, z), tile.transform.rotation, parent.transform);
                x += horizontalX;
            }
            z += verticalZ;
            if (j % 2 == 0)
            {
                x = aux;
            } else
            {
                x = 0;
            }
            
        }
        
    }
 

    void Update () {
		if (createMap && !once)
        {
            CreateMap();
            once = true;
        }
        if (!createMap && once )
        {
            once = false;
        }
	}
}
