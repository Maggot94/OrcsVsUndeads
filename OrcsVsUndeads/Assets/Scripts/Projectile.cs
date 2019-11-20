using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject target;
    private Rigidbody rb;
    private float timeDestroy = 2f;
    [SerializeField]
    private float thrust = 5f;
    private bool moving = false;
    [SerializeField]
    private float timeToTarget;
    private float elapsedTime;
    private Vector3 origin;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        timeDestroy -= Time.deltaTime;
        if (timeDestroy <= 0)
        {
            Destroy(gameObject);
        }
	}
    private void FixedUpdate()
    {
        if (moving)
        {
            elapsedTime += Time.deltaTime;

            //rb.AddForce(transform.forward * thrust);
            transform.position =  Vector3.MoveTowards(origin, target.transform.position, elapsedTime / timeToTarget);
        }
        
    }
    public void StartMovement ()
    {
        
    }
    public void StartMovement(GameObject t)
    {
        origin = transform.position;
        moving = true;
        target = t;
    }
     private void OnTriggerEnter(Collider other) {
         if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
