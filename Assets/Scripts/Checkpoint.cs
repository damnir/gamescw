using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            string nextSceneNum = currentSceneName.Substring(currentSceneName.Length - 1, 1);
            int index = int.Parse(nextSceneNum);
            if (index == 6)
            {
                SceneManager.LoadScene("End");
                return;
            }
            string nextSceneName = string.Format("Level{0}", index + 1);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
