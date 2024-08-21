using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBall : Projectiles
{
    private void Update()
    {
        Move();
        //transform.Rotate(Vector3.forward, 1, Space.World);
    }
}
