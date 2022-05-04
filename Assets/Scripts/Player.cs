using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("For Animations")]
    public bool canJump = true;
    public bool isIdle = true;
    private int spikesMask = 9;
    [Header("Object References")]
    public GameObject levelManagerGo;
    private LevelManager levelManager;
    private int groundMask = 1 << 8;
    public GameObject flashlight;
    private float moveSpeed = 5f;
    private float jumpSpeed = 3f;
    private float acceleration = 15f;
    private float moveX;
    private float moveY;
    private int isIdleKey = Animator.StringToHash("isIdle");
    private int isJumpingKey = Animator.StringToHash("isJumping");

    Quaternion leftRotation = new Quaternion(0, 180, 0, 0);
    Quaternion rightRotation = new Quaternion(0, 0, 0, 0);


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

        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= 1;
            this.transform.rotation = leftRotation;
        }
        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += 1;
            this.transform.rotation = rightRotation;
        }
        //Reset jump when reached peak velocity
        if (canJump)
        {
            if (r.velocity.y >= 7)
            {
                canJump = false;

            }
        }

        //Check if player is back on the ground
        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, 0.6f, groundMask))
        {
            canJump = true;
        }

        //Check if the player is inside terrain, respawn if true
        //Give a little leeway (0.3f) - maybe a bit cruel?
        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, -0.3f, groundMask))
        {
            respawn();
        }

        //Add acceleration for smoother movement and stopping
        moveX = Mathf.MoveTowards(moveX, physicsVelocity.x * moveSpeed, Time.deltaTime * acceleration);

        r.velocity = new Vector2(moveX,
        r.velocity.y);

        //For animations...
        if (physicsVelocity.x == 0)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        //Flashlight follows the player, scale down if moving, then scale back up
        flashlight.transform.position = this.transform.position;
        Transform flashlightTransform = flashlight.transform.Find("Flashlight").transform;
        flashlightTransform.localScale = new Vector3(flashlightTransform.localScale.x, -Mathf.Abs(moveX) / 6 + 1, 0); //for smooth transition

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

        //Let player jump until peak velocity reached
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

    }

    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
