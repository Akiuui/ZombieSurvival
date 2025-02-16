using UnityEngine;

public class ZombieBecameVisible : MonoBehaviour
{
    private Animator animator;
    private ZombiePatrol zombiePatrol;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        zombiePatrol = GetComponentInParent<ZombiePatrol>();
    }
    private void OnBecameVisible()
    {
        animator.enabled = true;
        zombiePatrol.enabled = true;
    }
    private void OnBecameInvisible()
    {
        animator.enabled = false;
        zombiePatrol.enabled = false;

    }
}
