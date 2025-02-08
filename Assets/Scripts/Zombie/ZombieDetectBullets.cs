using UnityEngine;

public class ZombieDetectBullets : MonoBehaviour
{
    private ZombieManager zombie;
    public int bulletDamage = 20;
    public int headshotDamage = 100;

    private void Start()
    {
        zombie = GetComponentInParent<ZombieManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        if (gameObject.name == "Body (collider)")
        {
            zombie.takeDamage(bulletDamage);
            print("Body");
        }

        if (gameObject.name == "Head (collider)")
        {
            zombie.takeDamage(headshotDamage);
            print("HeadShot");
        }


        print("Udarilo");
    }

}
