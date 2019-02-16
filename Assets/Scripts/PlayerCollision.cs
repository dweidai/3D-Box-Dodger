//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement Movement;
    public GameManager gameManager;
    public Rigidbody rb;
    public float forwardForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Debug.Log("hitting " + collision.collider.name);
            Movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
           
        }
        if (collision.collider.tag == "Cube")
        {
            Debug.Log("hitting " + collision.collider.name);
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }

    }
}
