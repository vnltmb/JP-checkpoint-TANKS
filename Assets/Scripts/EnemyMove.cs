using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Quaternion direction;
    public float speed;
    private float prevThink;
    [SerializeField] float thinkDelay;
    [SerializeField] float maxThink = 4.0f, minThink = 1.0f;

    private Rigidbody rbEnemy;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        prevThink = 0;
        thinkDelay = Random.Range(minThink, maxThink);
    }

    private void Update()
    {
        float curTime = Time.time;
        if (curTime - prevThink > thinkDelay)
        {
            ChangeDirection();
            prevThink = curTime;
            thinkDelay = Random.Range(minThink, maxThink);
        }
    }

    void FixedUpdate()
    {
        rbEnemy.MovePosition(rbEnemy.transform.position + rbEnemy.transform.TransformDirection(Vector3.right) * speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        float rand;
        Quaternion prevDirection = transform.rotation;

        do
        {
            rand = Random.Range(1, 5);
            switch (rand)
            {
                case 1:
                    direction = Quaternion.Euler(0, 0, 0);
                    break;
                case 2:
                    direction = Quaternion.Euler(0, 90, 0);
                    break;
                case 3:
                    direction = Quaternion.Euler(0, 180, 0);
                    break;
                case 4:
                    direction = Quaternion.Euler(0, -90, 0);
                    break;
            }
        }
        while (direction == prevDirection);

        transform.rotation = direction;
        //print("changed direction");
    }

}
