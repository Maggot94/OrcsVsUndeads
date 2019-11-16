using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawner : MonoBehaviour {

    private GameObject activeTile;
    //
    [SerializeField]
    private Material higlightSelection;
    [SerializeField]
    private Material unSelected;

    [SerializeField]
    private GameObject turretMelee;
    [SerializeField]
    private GameObject turretRange;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private float offsetYModel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void newActiveTile(GameObject g)
    {
        if (activeTile != null)
        {
            activeTile.GetComponent<Renderer>().material = unSelected;
        }
        
        activeTile = g;
        activeTile.GetComponent<Renderer>().material = higlightSelection;
        panel.SetActive(true);
    }
    public void createTurret(int x)
    {

        if (activeTile != null)
        {
            Tile activeTileScript = activeTile.GetComponent<Tile>();
            Transform atTransform = activeTile.transform;
            if (activeTileScript.GetisTaken() == false)
            {
                activeTileScript.TakeTile();
                if (x == 0)
                {
                    Instantiate(turretMelee, new Vector3 (atTransform.position.x, atTransform.position.y + offsetYModel , atTransform.position.z ), turretMelee.transform.rotation);
                }
                if (x == 1)
                {
                    Instantiate(turretRange, new Vector3(atTransform.position.x, atTransform.position.y + offsetYModel, atTransform.position.z), turretRange.transform.rotation);
                }

            }
            clearSelection();
        }
    }
    public void clearSelection()
    {
        activeTile.GetComponent<Renderer>().material = unSelected;
        activeTile = null;
        panel.SetActive(false);
    }
}
