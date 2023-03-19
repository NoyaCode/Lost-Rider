using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{   
    private int maxLevelNumber = 3;
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel > maxLevelNumber)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(nextLevel);
    }
}
