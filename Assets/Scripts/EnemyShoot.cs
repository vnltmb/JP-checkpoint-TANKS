using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Projectiles projectile;

    float prevShoot;
    // Start is called before the first frame update
    void Awake()
    {
        prevShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = Time.time;

        if (curTime - prevShoot > projectile.delay + Random.Range(1.0f, 2.5f))
        {
            projectile.SpawnProj(gameObject.transform);
            prevShoot = curTime;
        }
        
    }
}
