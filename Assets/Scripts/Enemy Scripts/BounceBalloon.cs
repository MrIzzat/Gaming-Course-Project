using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBalloon : MonoBehaviour
{
    private Rigidbody balloonRB;

    private float bounceForce=6f;
    // Start is called before the first frame update
    void Start()
    {
        balloonRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            balloonRB.AddForce(Vector3.up* bounceForce, ForceMode.Impulse);
        }
    }
}
