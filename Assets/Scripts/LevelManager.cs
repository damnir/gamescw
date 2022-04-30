using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public GameObject postProcessing1;
    public GameObject postProcessing2;
    public List<GameObject> levels;
    private GameObject activeLevel;
    private ContactPoint2D[] contants = new ContactPoint2D[5];
    public GameObject flashlight;
    public bool lightOn = true;
    public Level.LevelType activeType = Level.LevelType.Light;
    private FadeAnimation fadeAnimation;
    private Color colorTransparent = new Color(1, 1, 1, 0.6f);
    private Color colorFull = new Color(1, 1, 1, 1.0f);

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
                    level.GetComponent<Tilemap>().color = colorFull;
                    level.layer = 8;
                    foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                    {
                        trap.maskInteraction = SpriteMaskInteraction.None;
                        trap.color = colorFull;
                    }
                }
                else
                {
                    // level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    level.GetComponent<Tilemap>().color = colorTransparent;
                    level.layer = 10;
                    foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                    {
                        trap.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                        trap.color = colorTransparent;
                    }
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
                    level.GetComponent<Tilemap>().color = colorFull;
                    foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                    {
                        trap.maskInteraction = SpriteMaskInteraction.None;
                        trap.color = colorFull;
                    }
                }
                else
                {
                    // level.GetComponent<TilemapRenderer>().enabled = false;
                    level.GetComponent<TilemapCollider2D>().isTrigger = true;
                    level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    level.GetComponent<Tilemap>().color = colorTransparent;
                    level.layer = 10;
                    foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                    {
                        trap.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                        trap.color = colorTransparent;
                    }
                }
            }
        }

        if (light)
        {
            lightOn = true;
            activeType = Level.LevelType.Light;
            postProcessing1.SetActive(true);
            postProcessing2.SetActive(false);
        }
        else
        {
            lightOn = false;
            activeType = Level.LevelType.Dark;
            postProcessing1.SetActive(false);
            postProcessing2.SetActive(true);
        }

        fadeAnimation.swapBackgrounds();
    }

}
