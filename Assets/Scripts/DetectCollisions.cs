using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // delete self after colliding with projectile
        if (collision.collider.gameObject.CompareTag("Projectiles"))
        {
            print("collided with projectiles");
            Destroy(gameObject);
        }
    }
}
