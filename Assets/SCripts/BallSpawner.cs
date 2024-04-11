using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField] private GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }


    void SpawnBall()
    {
        Instantiate(Ball , transform);
        Invoke("SpawnBall", 15);
    }
}
