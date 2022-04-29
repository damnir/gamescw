using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canJump = true;
    int groundMask = 1 << 8;

    public GameObject levelManagerGo;

    private LevelManager levelManager;

    public GameObject flashlight;

    void Start()
    {
        levelManager = levelManagerGo.GetComponent<LevelManager>();
    }

    void FixedUpdate()
    {

        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();

        if (!levelManager.xRayOn)
        {
            if (Input.GetKey(KeyCode.A))
            {
                physicsVelocity.x -= 5;
            }
            if (Input.GetKey(KeyCode.D))
            {
                physicsVelocity.x += 5;
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (canJump)
                {
                    r.velocity = new Vector2(physicsVelocity.x, 8);
                    canJump = false;
                }
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                levelManager.changeLevel(0);
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                levelManager.changeLevel(1);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                levelManager.enableXray();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            levelManager.disableXray();
        }



        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, 0.6f, groundMask))
        {
            canJump = true;
        }

        flashlight.transform.position = this.transform.position;



        r.velocity = new Vector2(physicsVelocity.x,
        r.velocity.y);

        //flashlight stuff
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        flashlight.transform.eulerAngles = new Vector3 (0, 0, angle);


    }

    public void respawn()
    {
        this.gameObject.transform.position = new Vector3(-12.27f, -2.12f, 0f);
        levelManager.disableXray();
        levelManager.changeLevel(0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        if(other.gameObject.name == "Tilemap2")
        {
            Debug.Log("hit");
        }

    }
    
}
