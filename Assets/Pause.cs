using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public Button pauseButton;

    public void PauseGame()
    {
        pauseButton = GetComponent<Button>();

        //public Button
        bool paused = GameController.Instance.paused;

        if (!paused)
        {
            // PAUSE
            Time.timeScale = 0;
            GameController.Instance.paused = true;
            pauseButton.GetComponentInChildren<Text>().text = "Resume";
        }
        else
        {
            //RESUME
            Time.timeScale = 1;
            GameController.Instance.paused = false;
            pauseButton.GetComponentInChildren<Text>().text = "Pause";
        }

    }
}
