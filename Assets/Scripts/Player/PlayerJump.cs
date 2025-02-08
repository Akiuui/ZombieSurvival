using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rb;
    private PlayerManager playerManager;

    public LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = FindFirstObjectByType<PlayerManager>();
    }

    void Update()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && playerManager.getStamina()>=20)
        {
            playerManager.LessenStamina(20f);
            print("Jumped");
            Jump();
        }

    }
    private bool IsGrounded()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.3f, groundLayer);
        return hitColliders.Length > 0;
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
