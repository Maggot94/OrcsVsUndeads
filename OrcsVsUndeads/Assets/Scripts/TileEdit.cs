using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileEdit : MonoBehaviour {

    private bool once;
    [SerializeField]
    public bool isNotInteractable;
    [SerializeField]
    private Material InteractableMaterial;
    [SerializeField]
    private Material isNotInteractableMaterial;

    // Use this for initialization
    void Start () {
		
	}
    public void NotInteractable()
    {
        isNotInteractable = true;
        gameObject.GetComponent<Renderer>().material = isNotInteractableMaterial;
    }
    public void Interactable()
    {
        gameObject.GetComponent<Renderer>().material = InteractableMaterial;
    }
    // Update is called once per frame
    void Update () {
		if (isNotInteractable && !once)
        {
            NotInteractable();
            once = true;
        }
        if (!isNotInteractable && once)
        {
            Debug.Log("Pene");
            Interactable();
            once = false;
        }
	}
    public bool GetisNotInteractable ()
    {
        return isNotInteractable;
    }
}
