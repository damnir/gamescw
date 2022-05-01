using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public bool movingY = false;
    public bool movingX = false;
    public int animFrames = 2;
    private Vector2 originalPosition;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().respawn();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }
    public AnimationCurve curve;
    // Update is called once per frame
    void Update()
    {
        if (movingY)
        {
            transform.position = new Vector2(originalPosition.x,
            curve.Evaluate((Time.time % animFrames)) + originalPosition.y);
        }
        if (movingX)
        {
            transform.position = new Vector2(curve.Evaluate((Time.time % animFrames)) + originalPosition.x,
            originalPosition.y);
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

}
