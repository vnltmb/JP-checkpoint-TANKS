using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Projectiles projectile;

    private float prevFireTime;

    // Start is called before the first frame update
    void Start()
    {
        prevFireTime = -projectile.delay;
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = Time.time;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // check, if you can fire next shot
            if (curTime - prevFireTime > projectile.delay)
            {
                projectile.SpawnProj(gameObject.transform);
                prevFireTime = curTime;
            }
            else
                print("reloading");
        }
    }
}
