using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool canJump = true;

    public bool isIdle = true;
    int groundMask = 1 << 8;
    int spikesMask = 9;

    public GameObject levelManagerGo;

    private LevelManager levelManager;

    public GameObject flashlight;

    private float moveSpeed = 5f;
    private float jumpSpeed = 3f;
    private float acceleration = 15f;

    private float moveX;
    private float moveY;

    private int isIdleKey = Animator.StringToHash("isIdle");
    private int isJumpingKey = Animator.StringToHash("isJumping");

    void Start()
    {
        levelManager = levelManagerGo.GetComponent<LevelManager>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += 1;
        }

        if (canJump)
        {
            if (r.velocity.y >= 7)
            {
                canJump = false;

            }
        }

        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, 0.6f, groundMask))
        {
            canJump = true;
        }

        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, -0.3f, groundMask))
        {
            respawn();
        }

        moveX = Mathf.MoveTowards(moveX, physicsVelocity.x * moveSpeed, Time.deltaTime * acceleration);

        r.velocity = new Vector2(moveX,
        r.velocity.y);

        if (physicsVelocity.x == 0)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        //flashlight stuff
        flashlight.transform.position = this.transform.position;
        flashlight.transform.Find("Flashlight").transform.localScale = new Vector3(1, -Mathf.Abs(moveX) / 6 + 1, 0);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        flashlight.transform.eulerAngles = new Vector3(0, 0, angle);

    }

    void Update()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(isIdleKey, isIdle);
        animator.SetBool(isJumpingKey, !canJump);

        Rigidbody2D r = GetComponent<Rigidbody2D>();


        if (Input.GetMouseButtonDown(0))
        {
            flashlight.SetActive(!flashlight.active);
        }

        if (Input.GetMouseButtonDown(1))
        {
            levelManager.switchLevels(!levelManager.lightOn);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (canJump)
            {
                if (r.velocity.y < 7)
                {
                    r.AddForce(new Vector2(0, 70));
                }
            }
        }
    }

    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
