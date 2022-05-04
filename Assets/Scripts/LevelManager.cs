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
        activeLevel = levels[0]; //set first level dimension as default
        fadeAnimation = this.GetComponent<FadeAnimation>();
    }

    //Light = level version 1 | Dark = level version 2 (the other dimension)
    //!!!!! - to make the flashlight work, first, make the other tilemap's collider a trigger only,
    //make the spirte mask interaction Visible Inside Mask and disable the rigidbody simulation for that tilemap 
    //+ change active layer to disable jumps on invisible level. + change inactive tilemap to a transparent colour...
    //Because the flashlight is a mask, this makes the other tilemap and all traps associated with it
    //visible inside the flashlight, but the collision is disabled so the player can only interact with
    //the active Tilemap and traps. Do the opposite for the other level type...
    //Toggle these settings for both Tilemaps and traps to switch between different level versions (light(1)/dark(2))
    //Also switches post processing effects and backgrounds to differentiate between worlds/versions
    public void switchLevels(bool light)
    {
        if (light && lightOn) return;
        Level.LevelType levelType;

        if (light)
        {
            levelType = Level.LevelType.Light;
            lightOn = true;
            activeType = Level.LevelType.Light;
            postProcessing1.SetActive(true);
            postProcessing2.SetActive(false);
        }
        else
        {
            levelType = Level.LevelType.Dark;
            lightOn = false;
            activeType = Level.LevelType.Dark;
            postProcessing1.SetActive(false);
            postProcessing2.SetActive(true);
        }

        //levels in a list in case I decide to make more than 2 versions of the levels. But for now there's only 2
        foreach (GameObject level in levels)
        {
            if (level.GetComponent<Level>().type == levelType)
            {
                level.GetComponent<TilemapCollider2D>().isTrigger = false;
                level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
                level.GetComponent<Tilemap>().color = colorFull;
                level.layer = 8;
                foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                {
                    trap.maskInteraction = SpriteMaskInteraction.None;
                    trap.color = colorFull;
                    trap.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            else
            {
                level.GetComponent<TilemapCollider2D>().isTrigger = true;
                level.GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                level.GetComponent<Tilemap>().color = colorTransparent;
                level.layer = 10;
                foreach (SpriteRenderer trap in level.GetComponent<Level>().traps)
                {
                    trap.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    trap.color = colorTransparent;
                    trap.gameObject.GetComponent<Rigidbody2D>().simulated = false;

                }
            }

        }

        fadeAnimation.swapBackgrounds();
    }

}
