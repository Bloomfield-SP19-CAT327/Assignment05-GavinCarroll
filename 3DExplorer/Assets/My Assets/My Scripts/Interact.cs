using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour {

    public float rayLength;
    private RaycastHit objectHit;
    private GameObject curObj;
    public Material HighlightMaterial;
    private Material savedMaterial;
    public LayerMask layerMask;
    public int keysNeeded;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * rayLength,Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, rayLength, layerMask))
        {
            if(curObj != null && curObj != objectHit.collider.gameObject)
            {
                NullifyCurObj();
            }
            objInteraction(objectHit.collider.gameObject);
            //print("I hit: " + objectHit.transform.name);
            if(curObj == null)
            {
                curObj = objectHit.collider.gameObject;
                savedMaterial = curObj.GetComponent<Renderer>().material;
                curObj.GetComponent<Renderer>().material = HighlightMaterial;
            }
        }
        else
        {
            if(curObj != null)
            {
                NullifyCurObj();
            }
            
            //print("I hit Nothing");
        }
       
	}
    void NullifyCurObj()
        {
        curObj.GetComponent<Renderer>().material = savedMaterial;
            curObj = null;
        }
    void objInteraction(GameObject objFromRaycast)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objFromRaycast.tag == "Door")
            {
                if(PlayerInventory.keyCount >= keysNeeded)
                {
                    SceneManager.LoadScene("Scene_1");
                }
                else
                {
                    print("I need " + keysNeeded + " keys!");
                }
            }
        }
    }
}
