using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public void reset()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quit()
    {
        Application.Quit();
    }
}
