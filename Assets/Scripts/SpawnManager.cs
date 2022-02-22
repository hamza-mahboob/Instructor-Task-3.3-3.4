using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balls;
    Vector3[] force = new Vector3[2];
    float xPos;
    float yPos = 5.5f;
    float zPos = -0.75f;
    int random;
    float startDelay = 2;
    float IntervalDelay = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", startDelay, IntervalDelay);
        force[0] = Vector3.right * 5;
        force[1] = Vector3.left * 5;
    }

    // Update is called once per frame
    void Update()
    {
        //random position
        xPos = Random.Range(-12, 12);
        //random ball
        random = Random.Range(0, balls.Length);
    }

    void SpawnBall()
    {
        //instantiate
        GameObject newBall = Instantiate(balls[random], new Vector3(xPos, yPos, zPos), balls[random].transform.rotation);
        //add random force
        newBall.GetComponent<Rigidbody>().AddForce(force[Random.Range(0, force.Length)], ForceMode.Impulse);
    }
}
