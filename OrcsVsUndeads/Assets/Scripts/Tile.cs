using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    private TurretSpawner turretSpawner;

    private TileEdit tileEdit;

    private bool isTaken;
    //
  

    // Use this for initialization
    private void Awake()
    {
     
       turretSpawner =  GameObject.FindObjectOfType<TurretSpawner>();
        tileEdit = gameObject.GetComponent<TileEdit>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !tileEdit.isNotInteractable)
        {
          turretSpawner.newActiveTile(gameObject);
        }

    }

    public void TakeTile ()
    {
        isTaken = true;
    }
    
    public bool GetisTaken ()
    {
        return isTaken;
    }
    
   
}
