using UnityEngine;

public class ZombieHearingBullets : MonoBehaviour
{
    private ZombieManager zombie;
    private void Start()
    {
        zombie = GetComponentInParent<ZombieManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;

        if (zombie.seenHeardPlayer == false)
        {
            zombie.seenHeardPlayer = true;

        }

    }
}
