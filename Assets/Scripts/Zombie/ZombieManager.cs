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
    private GameObject objectToFollow;
    private NavMeshAgent agent;
    private ZombieSounds zombieSounds;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        zombieSounds = GetComponent<ZombieSounds>();
        objectToFollow = GameObject.FindGameObjectWithTag("Player");

        health = maxHealth;
    }

    private bool playSoundOnce = true;
    private void Update()
    {

        if (!seenHeardPlayer && agent.velocity.magnitude > 0.1f)
        {
            agent.speed = 1f;
            agent.angularSpeed = 100;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (seenHeardPlayer && alive)
        {
            agent.speed = 4f;
            agent.angularSpeed = 200;

            animator.SetBool("isRunning", true);
            agent.SetDestination(objectToFollow.transform.position);
            if (playSoundOnce)
            {
                zombieSounds.PlayAngrySound();
                playSoundOnce = false;
            }
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
        zombieSounds.PlayDeathSound();

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
