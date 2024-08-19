using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float horInput, vertInput;
    private bool isTouching = false;

    private Bumpers bumpersScript;
    public GameObject frontBumper, rearBumper, leftBumper, rightBumper;

    // Start is called before the first frame update
    void Start()
    {
        bumpersScript = GetComponent<Bumpers>();
        
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

        if (!isTouching)
        {
            // Sign() returns either 1 or -1, so you get the direction
            transform.Translate(Vector3.forward * Mathf.Sign(vertInput) * speed * Time.deltaTime, Space.World);
        }
        else
            Debug.Log("can't move");
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

        if (!isTouching)
        {
            // Sign() returns either 1 or -1, so you get the direction
            transform.Translate(Vector3.right * Mathf.Sign(horInput) * speed * Time.deltaTime, Space.World);
        }
        else
            Debug.Log("can't move");
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        isTouching = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("no obstacle ahead");
        isTouching = false;
    }
    
}
