using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        SceneManager.LoadScene("Lab4_IntroToUnity");
    }
}
