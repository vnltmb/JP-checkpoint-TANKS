using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public float delay;

    public Transform origin;


    private void Start()
    {
        /*
        // find the origin transform
        origin = GameObject.Find("origin").GetComponent<Transform>();
        // set the position and rotation of the projectile, so it knows where to spawn
        transform.position = origin.position;
        transform.rotation = origin.rotation;
        */
    }

    public void SpawnProj(Transform origin)
    {
        transform.position = origin.position;
        transform.rotation = origin.rotation;
        Instantiate(gameObject);
    }

    protected void Move()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.body.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.body.gameObject);
            print("destroyed enemy tank");
        }
        */
        //print("destroyed");
        Destroy(gameObject);
    }
}
