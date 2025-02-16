using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
        StartCoroutine(CheckMovementState());
    }
    private IEnumerator CheckMovementState()
    {
        while (true)
        {
            if (!this.enabled)
            {
                yield return new WaitForSeconds(0.5f);
                continue;
            }

            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                print("Unutar ifa");
                MoveToNextWaypoint();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    void MoveToNextWaypoint() 
    {
        agent.SetDestination(waypoints[currentIndex].position);
        currentIndex = (currentIndex + 1) % waypoints.Length;
    }

}
