using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private PlayerManager player;
    private Animator animator;
    private ZombieManager zombie;
    private ZombieSounds zombieSounds;

    public float attackSpeedPerSecond = 1f;
    private float attackTimer = 0f;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerManager>();
        animator = GetComponentInParent<Animator>();
        zombie = GetComponentInParent<ZombieManager>();
        zombieSounds = GetComponentInParent<ZombieSounds>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        animator.SetBool("IsAttacking", true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        animator.SetBool("IsAttacking", false);

    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (zombie.alive == false) return;
        
        attackTimer -= Time.deltaTime;

        if (attackTimer < 0) { 
            player.TakeDamage(10);
            zombieSounds.PlayAttackSound();
            attackTimer = 1f / attackSpeedPerSecond; 
        }
    }


}
