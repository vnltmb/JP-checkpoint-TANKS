using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject tank;
    [SerializeField] int tanksToSpawn;
    [SerializeField] public static int tanksActive = 0;

    private void Start()
    {
        foreach (var sp in spawnPoints)
        {
            Instantiate(tank, sp);
            tanksActive++;
        }
    }

    private void Update()
    {
        if (tanksToSpawn > 0 && tanksActive < 2)
        {
            int spawn = Random.Range(0, spawnPoints.Length);

            Instantiate(tank, spawnPoints[spawn]);
            tanksActive++;
            tanksToSpawn--;
        }
    }


}
