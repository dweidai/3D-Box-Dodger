//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public float forwardForce = 10f;
    public float sideForce = 10f;
    int count = 0;
    private void Start()
    {
        if (Input.GetKey("s"))
        {
            FixedUpdate();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey("w"))
        //{
        if(count == 600)
        {
            forwardForce = forwardForce + 10f;
            sideForce = sideForce + 1f;
            count = 0;
        }
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, +forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        count++;
    }
}
