using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour {
    [SerializeField]
    private float x;

    private List<Tile> tiles;




	// Use this for initialization
	void Start () {
        
        tiles = new List<Tile>();
     Collider[] tilesColider  = Physics.OverlapSphere(transform.position, x);
     for (int i = 0; i < tilesColider.Length; i++)
        {
            if (tilesColider[i].gameObject.GetComponent<Tile>() != null)
            {
                tiles.Add(tilesColider[i].gameObject.GetComponent<Tile>());
            }
        }
        
        foreach (Tile t in tiles)
        {
            t.gameObject.GetComponent<Tile>().OnDetection += Attack;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Attack()
    {
        Debug.Log("Bum");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, x);
    }
}
