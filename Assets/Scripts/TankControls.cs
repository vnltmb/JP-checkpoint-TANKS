using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float horInput, vertInput;

    Rigidbody rb;

    public Transform origin;
    public Projectiles projectile;

    private float prevFireTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // so I don't have to wait at the start of the game
        prevFireTime = -projectile.delay;
    }
    // Update is called once per frame
    private void Update()
    {
        float curTime = Time.time;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // check, if you can fire next shot
            if (curTime - prevFireTime > projectile.delay)
            {
                projectile.SpawnProj();
                prevFireTime = curTime;
            }
            else
                print("reloading");
        }
            
    }

    void FixedUpdate()
    {
        vertInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        // vertical movement gets higher priority, maybe fix it?
        if (vertInput != 0)
        {
            HandleMovementVert(vertInput);
        }
        else if (horInput != 0)
        {
            HandleMovementHor(horInput);
        }

    }

    private void HandleMovementVert(float vertInput)
    {
        // rotate first, then check if we are touching something
        if (Input.GetButton("Up"))
        {
            // set rotation
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetButton("Down"))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // Sign() returns either 1 or -1, so you get the direction
        rb.MovePosition(rb.transform.position + Vector3.forward * Mathf.Sign(vertInput) * speed * Time.deltaTime);
      
    }

    private void HandleMovementHor(float horInput)
    {
        
        if (Input.GetButton("Left"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetButton("Right"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Sign() returns either 1 or -1, so you get the direction
        rb.MovePosition(rb.transform.position + Vector3.right * Mathf.Sign(horInput) * speed * Time.deltaTime);
                
    }

}
