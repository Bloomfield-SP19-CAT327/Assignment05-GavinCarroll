using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float rayLength;
    private RaycastHit raycastHit;

    public float damage;
    public LayerMask layerMask;
    public GameObject impactParticles;
    public AudioSource audioSource;
    public AudioClip gunClip;

    [Range(0.0f, 1.0f)]
    public float gunshotVolume;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.blue);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        audioSource.PlayOneShot(gunClip, gunshotVolume);
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, rayLength, layerMask))
        {
            GameObject particleRef = Instantiate(impactParticles, raycastHit.point, transform.rotation);
            Destroy(particleRef, 1f);
            if(raycastHit.collider.gameObject.tag == "Enemy")
            {
                Enemy enemyRef = raycastHit.collider.gameObject.GetComponent<Enemy>();
                enemyRef.TakeDamage(damage);
            }
            //print("I hit " + raycastHit.collider.gameObject.name);
        }
        else
        {
            print("Miss!");
        }
    }
}
