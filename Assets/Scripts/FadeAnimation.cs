using UnityEngine;

//modified version of:
//https://developpaper.com/unity-implements-fade-in-and-fade-out-effect-of-background-pictures/

public class FadeAnimation : MonoBehaviour
{
    public GameObject background1Go;
    public GameObject background2Go;
    private SpriteRenderer background1;
    private SpriteRenderer background2;
    private float ShowTimeTrigger = 0;
    private float fadeTime = 0.3f;
    private float fadeTimeTrigger = 0;
    public bool show = true;
    private bool swap = false;
    // Use this for initialization
    void Start()
    {
        background1 = background1Go.GetComponent<SpriteRenderer>();
        background2 = background2Go.GetComponent<SpriteRenderer>();
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
                    background1.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));
                    background2.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));

                }
                else
                {
                    background1.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));
                    background2.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));
                }
            }
            else
            {
                fadeTimeTrigger = 0;
                ShowTimeTrigger = 0;

                if (show) show = false;
                else show = true;
            
                swap = false;
            }
        }
    }

    public void swapBackgrounds()
    {
        swap = !swap;
    }
}