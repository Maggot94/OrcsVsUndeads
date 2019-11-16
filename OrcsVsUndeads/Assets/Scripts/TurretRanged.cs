using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRanged : MonoBehaviour {
    [SerializeField]
    private float Radius;

    private List<Tile> tiles;

    private List<GameObject> targets;

    [SerializeField]
    private float rechargeTime;

    private bool attacking;

    private float elapsedTime;
    [SerializeField]
    private GameObject bullet;
    //
    private Transform bulletSpawner;

	// Use this for initialization
	void Start () {
        bulletSpawner = gameObject.transform.GetChild(1);
        targets = new List<GameObject>();
        tiles = new List<Tile>();
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
               return;
            }
            attacking = true;
            if (targets[0] != null)
            {
                transform.LookAt(new Vector3(targets[0].transform.position.x, transform.position.y, targets[0].transform.position.z));
            }
            if (attacking)
            {
                if (elapsedTime == rechargeTime)
                {
                    Shoot();
                }
                elapsedTime -= Time.deltaTime;
                if (elapsedTime <= 0)
                {
                    elapsedTime = rechargeTime;
                }
            }
        }
        else
        {
            attacking = false;
        }
        
	}
    private void AddTarget(GameObject enemy)
    {
        if (targets.Contains(enemy))
        {
           targets.Insert(targets.IndexOf(enemy),enemy);
        } else
        {
            targets.Add(enemy);

        }
    }
    private void removeTarget (GameObject enemy)
    {
        if (targets.Contains(enemy))
        {
            targets.Remove(enemy);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, Radius);
    }

    private void Shoot ()
    {
       Quaternion targetRotation = Quaternion.LookRotation(targets[0].transform.position - bulletSpawner.position);
       GameObject actualBullet = Instantiate(bullet, bulletSpawner.position, targetRotation);
       actualBullet.GetComponent<Projectile>().StartMovement(targets[0]);
    }
}
