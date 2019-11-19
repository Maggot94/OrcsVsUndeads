using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTurret : MonoBehaviour {
    [SerializeField]
    private float Radius;

    private List<Tile> tiles;

	private List<GameObject> reportedTiles;

    private List<GameObject> targets;

    [SerializeField]
    private float rechargeTime;

    private bool attacking;

    private float elapsedTime;
    [SerializeField]
    private GameObject attackRange;

	private bool firstAttack;
    //
	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();
        tiles = new List<Tile>();
		reportedTiles = new List<GameObject>();
		firstAttack = true;
        Collider[] tilesColider  = Physics.OverlapSphere(transform.position, Radius);
         for (int i = 0; i < tilesColider.Length; i++)
            {
                if (tilesColider[i].gameObject.GetComponent<Tile>() != null)
                {
                    tiles.Add(tilesColider[i].gameObject.GetComponent<Tile>());
                }  
            }
        foreach (Tile t in tiles)
        {
            t.gameObject.GetComponent<Tile>().OnDetection += AddTarget;
            t.gameObject.GetComponent<Tile>().OnExit += removeTarget;
            if (t.gameObject.GetComponent<TileEdit>().GetisNotInteractable())
            {
                transform.LookAt(new Vector3(t.transform.position.x, transform.position.y, t.transform.position.z));
            }

        }

    }
	
	// Update is called once per frame
	void Update () {
        if (targets.Count > 0)
        {
            if (targets[0] == null)
            {
               targets.RemoveAt(0);
			   reportedTiles.RemoveAt(0);
               return;
            }
            attacking = true;
            if (targets[0] != null)
            {
                //transform.LookAt(new Vector3(targets[0].enemy.transform.position.x, transform.position.y, targets[0].enemy.transform.position.z));
            }
            if (attacking)
            {
                /*if (elapsedTime == rechargeTime)
                {
                }*/
                elapsedTime -= Time.deltaTime;
                if (elapsedTime <= 0)
                {
                    elapsedTime = rechargeTime;
					if (!firstAttack) {
                    	Swing();
					} else {
						firstAttack = false;
					}
                }
            }
        }
        else
        {
            attacking = false;
			firstAttack = true;
			elapsedTime = 0f;
        }
        
	}
    private void AddTarget(GameObject enemy, GameObject tile)
    {
        if (targets.Contains(enemy))
        {
           targets.Insert(targets.IndexOf(enemy),enemy);
		   reportedTiles.Insert(targets.IndexOf(enemy),tile);

        } else
        {
            targets.Add(enemy);
			reportedTiles.Add(tile);
        }
    }
    private void removeTarget (GameObject enemy, GameObject tile) {

        if (targets.Contains(enemy))
        {
			 if(targets.IndexOf(enemy) != targets.LastIndexOf(enemy))
			 {
				reportedTiles.RemoveAt(targets.LastIndexOf(enemy));
			 } else {
				reportedTiles.RemoveAt(targets.IndexOf(enemy));
			 } 
            targets.Remove(enemy);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, Radius);
    }

    private void Swing ()
    {
      transform.LookAt(new Vector3(reportedTiles[0].transform.position.x, transform.position.y, reportedTiles[0].transform.position.z));
	  Instantiate(attackRange, reportedTiles[0].transform.position, Quaternion.identity);
    }
}