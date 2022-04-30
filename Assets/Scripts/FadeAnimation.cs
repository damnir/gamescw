using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//modified version of:
//https://developpaper.com/unity-implements-fade-in-and-fade-out-effect-of-background-pictures/
public class FadeAnimation : MonoBehaviour
{
    public GameObject background;
    public GameObject background2;

    public SpriteRenderer bgimages;
    public SpriteRenderer bgimages2;
    public float ShowTimeTrigger = 0;
    public float fadeTime = 3;
    public float fadeTimeTrigger = 0;
    private bool show = true;

    public bool swap = false;
    // Use this for initialization
    void Start()
    {
        bgimages = background.GetComponent<SpriteRenderer>();
        bgimages2 = background2.GetComponent<SpriteRenderer>();
        // bgimages.color
    }
    // Update is called once per frame
    void Update()
    {
        ShowTimeTrigger += Time.deltaTime;
        if (swap)
        {
            if (fadeTimeTrigger >= 0 && fadeTimeTrigger < fadeTime)
            {
                fadeTimeTrigger += Time.deltaTime;
                if (show)
                {
                    bgimages.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));
                    bgimages2.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));

                }
                else
                {
                    bgimages.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));
                    bgimages2.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));
                }
            }
            else
            {
                fadeTimeTrigger = 0;
                ShowTimeTrigger = 0;
                if (show)
                {
                    show = false;
                    swap = false;
                }
                else
                {
                    show = true;
                    swap = false;
                }
            }
        }

    }

    public void swapBackgrounds()
    {
        swap = !swap;
    }
}