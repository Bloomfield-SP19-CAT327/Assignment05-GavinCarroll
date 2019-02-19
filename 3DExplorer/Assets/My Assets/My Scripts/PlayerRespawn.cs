using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {
    public Vector3 respawnPoint;

	// Use this for initialization
	void Start ()
    {
        respawnPoint = transform.position;
	}
	
	// Update is called once per frame
	private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            respawnPoint = gameObject.transform.position;
        }
        if (other.gameObject.tag == "Kill Box")
        {
            transform.position = respawnPoint;
        }
        if (other.gameObject.tag == "Enenmy")
        {
            transform.position = respawnPoint;
        }
    }
}
