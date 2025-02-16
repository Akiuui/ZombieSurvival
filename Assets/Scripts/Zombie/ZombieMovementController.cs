using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class ZombieController : MonoBehaviour
{
    public float detectionRange = 15f;
    public float fieldOfView = 130f;
    public LayerMask obstacleMask;

    private GameObject objectToFollow;
    //public NavMeshAgent agent;
    private ZombieManager zombie;

    //public Animator animator;

    private bool isCheckingVision = false;
    //private bool alreadySeen = false;


    private void Start()
    {
        objectToFollow = GameObject.Find("Player");
        zombie = GetComponentInParent<ZombieManager>();
        print("Zombie: "+zombie);
        //agent.stoppingDistance = 1f;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (zombie.seenHeardPlayer) return;

            StartCoroutine(CheckVision());
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (alreadySeen) return;

        if (other.CompareTag("Player"))
        {
            isCheckingVision = false;
        }
    }
    IEnumerator CheckVision()
    {
        if(zombie.seenHeardPlayer)
        {
            //isCheckingVision=false;
            yield break;
        }

        isCheckingVision = true;
        while (isCheckingVision)
        {
            yield return new WaitForSeconds(0.5f);
            if (CanSeePlayer())
            {
                zombie.seenHeardPlayer = true;
                isCheckingVision = false;
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (objectToFollow.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < fieldOfView / 2)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, objectToFollow.transform.position);
            if (distanceToPlayer <= detectionRange)
            {
                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    
                    return true;
                }
            }
        }

        return false;
    }
}
