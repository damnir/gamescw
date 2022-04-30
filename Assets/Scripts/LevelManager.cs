using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    private GameObject activeLevel;
    private ContactPoint2D[] contants = new ContactPoint2D[5];
    public GameObject flashlight;
    public bool lightOn = true;
    public Level.LevelType activeType = Level.LevelType.Light;
    private FadeAnimation fadeAnimation;

    void Start()
    {
        activeLevel = levels[0];
        fadeAnimation = this.GetComponent<FadeAnimation>();
    }
    public void switchLevels(bool light)
    {
        foreach (GameObject level in levels)
        {
            if (light)
            {
                if (level.GetComponent<Level>().type == Level.LevelType.Light)
                {
                    // level.GetComponent<TilemapRenderer>().enabled = true;
                    level.GetComponent<TilemapCollider2D>().isTrigger = false;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
                    level.layer = 8;
                }
                else
                {
                    // level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    level.layer = 10;
                }
            }
            else
            {
                if (level.GetComponent<Level>().type == Level.LevelType.Dark)
                {
                    // level.GetComponent<TilemapRenderer>().enabled = true;
                    level.GetComponent<TilemapCollider2D>().isTrigger = false;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
                    level.layer = 8;
                }
                else
                {
                    // level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    level.layer = 10;
                }
            }
        }

        if (light)
        {
            lightOn = true;
            activeType = Level.LevelType.Light;
        }
        else
        {

            lightOn = false;
            activeType = Level.LevelType.Dark;
        }

        fadeAnimation.swapBackgrounds();
    }

}
