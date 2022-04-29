using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flashlight : MonoBehaviour
{
    private ContactPoint2D[] contants = new ContactPoint2D[5];
    public GameObject gridGo;
    public GameObject levelManagerGo;
        private Player player;


    private LevelManager levelManager;

    int spikesMask = 9;


    private Grid grid;

    void Start()
    {
        grid = gridGo.GetComponent<Grid>();
        levelManager = levelManagerGo.GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelManager.levels.Contains(other.gameObject))
        {
            Debug.Log("hit: " + other.gameObject.name + " mask:" + other.gameObject.layer);
            other.gameObject.GetComponent<TilemapRenderer>().enabled = true;
            other.gameObject.GetComponent<TilemapCollider2D>().isTrigger = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (levelManager.levels.Contains(other.gameObject))
        {
            other.gameObject.GetComponent<TilemapRenderer>().enabled = false;
            other.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;
        }
    }

}
