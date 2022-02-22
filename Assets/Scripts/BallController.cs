using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject mediumBall;
    public GameObject smallBall;
    GameManager gameManager;
    Vector3[] force = new Vector3[2];
    float time;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        force[0] = Vector3.right * 5;
        force[1] = Vector3.left * 5;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //destory ball after 10 seconds to reduce lag
        if(time > 10)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Small"))
            {
                Destroy(gameObject);
                //add score
                gameManager.AddScore();
            }
            else if (gameObject.CompareTag("Medium"))
            {
                GameObject newObj;
                Destroy(gameObject);

                //instantiate two new objects
                newObj = Instantiate(smallBall, gameObject.transform.position, gameObject.transform.rotation);
                newObj.GetComponent<Rigidbody>().AddForce(RandomForce(), ForceMode.Impulse);

                newObj = Instantiate(smallBall, gameObject.transform.position, gameObject.transform.rotation);
                newObj.GetComponent<Rigidbody>().AddForce(RandomForce(), ForceMode.Impulse);
            }
            else if (gameObject.CompareTag("Large"))
            {
                GameObject newObj;
                Destroy(gameObject);

                //instantiate two new objects
                newObj = Instantiate(mediumBall, gameObject.transform.position, gameObject.transform.rotation);
                newObj.GetComponent<Rigidbody>().AddForce(RandomForce(), ForceMode.Impulse);

                newObj = Instantiate(mediumBall, gameObject.transform.position, gameObject.transform.rotation);
                newObj.GetComponent<Rigidbody>().AddForce(RandomForce(), ForceMode.Impulse);
            }
        }
    }

    Vector3 RandomForce()
    {
        return force[Random.Range(0, force.Length)];
    }
}
