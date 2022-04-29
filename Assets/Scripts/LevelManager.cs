using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> levels;
    public GameObject xRayBnd;

    private GameObject activeLevel;

    private Color color_transparent = new Color(1, 1, 1, 0.5f);
    private Color color_full = new Color(1, 1, 1, 1.0f);

    public bool xRayOn = false;

    private ContactPoint2D[] contants = new ContactPoint2D[5];

    public GameObject flashlight;

    public GameObject lightBackground;
    public GameObject darkBackground;

    public bool lightOn = true;

    public Level.LevelType activeType = Level.LevelType.Light;

    void Start()
    {
        activeLevel = levels[0];
    }

    void FixedUpdate()
    {
        checkTiles();
    }

    public void switchLevels(bool light)
    {
        foreach (GameObject level in levels)
        {
            if (light)
            {
                if (level.GetComponent<Level>().type == Level.LevelType.Light)
                {
                    level.GetComponent<TilemapRenderer>().enabled = true;
                    level.GetComponent<TilemapCollider2D>().isTrigger = false;
                }
                else
                {
                    level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                }
            }
            else
            {
                if (level.GetComponent<Level>().type == Level.LevelType.Dark)
                {
                    level.GetComponent<TilemapRenderer>().enabled = true;
                    level.GetComponent<TilemapCollider2D>().isTrigger = false;
                }
                else
                {
                    level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                }
            }
        }

        if (light)
        {
            lightBackground.SetActive(true);
            darkBackground.SetActive(false);
            lightOn = true;
            activeType = Level.LevelType.Light;
        }
        else
        {
            lightBackground.SetActive(false);
            darkBackground.SetActive(true);
            lightOn = false;
            activeType = Level.LevelType.Dark;
        }
    }


    public void changeLevel(int index)
    {
        // activeLevel = levels[index];

        // if (xRayOn) disableXray();

        // foreach (GameObject level in levels)
        // {
        //     level.SetActive(false);
        // }

        // activeLevel.SetActive(true);

    }

    public void enableXray()
    {
        // foreach (GameObject level in levels)
        // {
        //     if (level != activeLevel)
        //     {
        //         level.SetActive(true);
        //         level.GetComponent<TilemapCollider2D>().enabled = false;
        //         level.GetComponent<Renderer>().material.color = color_transparent;
        //     }
        // }

        xRayOn = true;
        xRayBnd.SetActive(true);
    }

    public void disableXray()
    {
        // foreach (GameObject level in levels)
        // {
        //     level.SetActive(false);
        //     level.GetComponent<TilemapCollider2D>().enabled = true;
        //     level.GetComponent<Renderer>().material.color = color_full;
        // }

        // activeLevel.SetActive(true);

        xRayOn = false;
        xRayBnd.SetActive(false);
    }

    public void checkTiles()
    {
        // int colliders = levels[1].GetComponent<TilemapCollider2D>().GetContacts(contants);
        // // int colliders = flashlight.GetComponent<PolygonCollider2D>().GetContacts(contants);

        // // Transform worldToCell = levels[1].GetComponent<Tilemap>().Wor/ldToCell();
        // if (colliders > 0)
        // {
        //     for (int i = 0; i < colliders; i++)
        //     {
        //         // contact.collider.gameObject.SetActive(true);
        //         Debug.Log("hit: " + contants[i].collider.gameObject.name);
        //     }
        // }



    }

}
