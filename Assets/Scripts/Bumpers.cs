using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpers : MonoBehaviour
{
    public bool isTouching = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        isTouching = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("clear");
        isTouching = false;
    }
}
