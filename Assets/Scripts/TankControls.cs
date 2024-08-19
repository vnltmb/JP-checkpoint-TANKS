using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float horInput, vertInput;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
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
