using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class ZombieManager : MonoBehaviour
{
    public bool seenHeardPlayer = false;
    //private bool seenFirstTime = true;
    public int maxHealth = 100;
    public float bodyDissapear = 10f;

    private int health;
    public bool alive = true;

    private Animator animator;
    public GameObject objectToFollow;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 1f;

        health = maxHealth;
    }

    private void Update()
    {
        if (seenHeardPlayer && alive)
        {
            animator.SetBool("isRunning", true);
            agent.SetDestination(objectToFollow.transform.position);
            //seenFirstTime = false;
        }
    }
    public void takeDamage(int damage) { 
    
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    
    }
    
    private void Die()
    {
        animator.SetBool("Dead", true);
        alive = false;
        DisableAllScripts(gameObject);
        agent.isStopped = true;

        Destroy(gameObject, bodyDissapear);

    }

    public void DisableAllScripts(GameObject obj)
    {
        MonoBehaviour[] scripts = obj.GetComponentsInChildren<MonoBehaviour>();
        foreach(MonoBehaviour sc in scripts)
        {
            sc.enabled = false;
        }
    }
}
