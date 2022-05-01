using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;

    private bool collided = false;
    private bool collidedLeft = false;

    private GameObject player;
    private Rigidbody2D playerRigid;

    void Start()
    {
        player = GameObject.Find("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            if (collision.otherCollider == leftCollider)
            {
                collidedLeft = true;
                Debug.Log("Collided Left");
            }
            if (collision.otherCollider == rightCollider)
            {
                collidedLeft = false;
                Debug.Log("Collided Right");
            }
            collided = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            collided = false;
        }
    }

    void Update()
    {
        if (collided)
        {
            if (collidedLeft)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddTorque(-50);
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddTorque(50);
            }
        }
    }

}
