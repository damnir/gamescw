using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flashlight : MonoBehaviour
{
    private ContactPoint2D[] contants = new ContactPoint2D[5];
    public GameObject gridGo;
    public GameObject levelManagerGo;

    private LevelManager levelManager;

    private Grid grid;

    void Start()
    {
        grid = gridGo.GetComponent<Grid>();
        levelManager = levelManagerGo.GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit " + other.gameObject.name);
        // Debug.Log(other.GetContacts(contants));

        if (levelManager.levels.Contains(other.gameObject))
        {
            Debug.Log("hit: " + other.gameObject.name);
            other.gameObject.GetComponent<TilemapRenderer>().enabled = true;
            other.gameObject.GetComponent<TilemapCollider2D>().isTrigger = false;

            // Tilemap tilemap = other.GetComponent<Tilemap>();
            // Vector3 cellPoistion = grid.CellToWorld(Vector3Int.FloorToInt(other.transform.position));

            // GameObject tile = tilemap.GetInstantiatedObject(Vector3Int.FloorToInt(cellPoistion));
            // tile.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (levelManager.levels.Contains(other.gameObject))
        {
            // Debug.Log("hit: " + other.gameObject.name);
            other.gameObject.GetComponent<TilemapRenderer>().enabled = false;
            other.gameObject.GetComponent<TilemapCollider2D>().isTrigger = true;

            // Tilemap tilemap = other.GetComponent<Tilemap>();
            // Vector3 cellPoistion = grid.CellToWorld(Vector3Int.FloorToInt(other.transform.position));

            // GameObject tile = tilemap.GetInstantiatedObject(Vector3Int.FloorToInt(cellPoistion));
            // tile.

        }



    }

}
