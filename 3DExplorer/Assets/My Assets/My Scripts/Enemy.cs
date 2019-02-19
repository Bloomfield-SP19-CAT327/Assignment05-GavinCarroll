using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health;

    public NavMeshAgent enemyNavMeshAgent;

    private GameObject target;
    private Material savedMaterial;
    public Material flashMaterial;

    private void Update()
    {
        
        FollowPlayer();
    }
    private void Start()
    {
        savedMaterial = gameObject.GetComponent<Renderer>().material;
        target = GameObject.FindWithTag("Player");
    }

    public void TakeDamage(float damageAmount)
    {
        StartCoroutine("Flash");
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void FollowPlayer()
    {
        enemyNavMeshAgent.SetDestination(target.transform.position);
    }
    IEnumerator Flash()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        int flashCount = 3;
        float waitTime = 0.01f;
        for (int i = 0; i <flashCount; i++)
        {
            renderer.material = flashMaterial;
            yield return new WaitForSeconds(waitTime);
            renderer.material = savedMaterial;
            yield return new WaitForSeconds(waitTime);
            renderer.material = flashMaterial;
            yield return new WaitForSeconds(waitTime);
            renderer.material = savedMaterial;
        }
    }
}
