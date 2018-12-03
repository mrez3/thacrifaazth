using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Text t, btn;
    public Button button;
    
    public static int numOfLevels = 5;

    public void Lose()
    {

        t.text = "You Thacrifaazthed All of Uth!";
        btn.text = "Again";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(RestartLevel);

    }

    public void Win()
    {

        t.text = "Thacrifaazth Muth Be Made";
        btn.text = "Next Level";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(GotoNextLevel);

    }

    public void RestartLevel ()
    {
        button.onClick.RemoveAllListeners();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoNextLevel()
    {
        button.onClick.RemoveAllListeners();
        if (SceneManager.GetActiveScene().buildIndex + 1 < numOfLevels)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            t.text = "How many levels did you think I could make in 48 hours?! :|";

    }

}
