using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public AudioSource soundPlayer;

    public AudioClip keyGet;

    [Range(0f, 1f)]
    public float keyVolume;
    public ParticleSystem keyPickupParticles;
    private void OnTriggerEnter(Collider objectCollided)
    {
        if(objectCollided.gameObject.tag == "Key")
        {
            PlayerInventory.keyCount++;
            keyPickupParticles.Play();
            soundPlayer.PlayOneShot(keyGet, keyVolume);
            print("I have " + PlayerInventory.keyCount + " Keys!");
            Destroy(objectCollided.gameObject);
        }
    }
}
