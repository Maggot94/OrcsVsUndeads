using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    private TurretSpawner turretSpawner;

    private TileEdit tileEdit;

    private bool isTaken;

    public delegate void EnemyDetected(GameObject enemigo, GameObject tile);
    public event EnemyDetected OnDetection;
    //
    public delegate void EnemyLeft(GameObject enemigo, GameObject tile);
    public event EnemyLeft OnExit;
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && OnDetection != null)
        {
            
            OnDetection(other.gameObject, gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && OnExit != null)
        {

            OnExit(other.gameObject, gameObject);
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
