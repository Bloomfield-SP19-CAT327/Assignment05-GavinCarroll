using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttacher : MonoBehaviour {
    public GameObject thePlatform;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	private void OnTriggerEnter(Collider objectCollided) {
		if(objectCollided.gameObject.tag == "Player")
        {
            thePlayer.transform.parent = thePlatform.transform;
        }
	}
    private void OnTriggerExit(Collider objectCollided)
    {
        if(objectCollided.gameObject.tag == "Player")
        {
            thePlayer.transform.parent = null;
        }
    }
}
