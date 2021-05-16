using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public Text scoreText;
    public Text hiscoreText;
    public Button startButton;
    public Button pauseButton;
 
    public GameObject menu;
    public GameObject gameovermenu;
    public GameObject pauseObject;

    Vector3 ShipOrigin;

    bool isStarted = false;
    public bool isGameOver = false;
    public bool paused = false;

    public int score = 0;
    public int hiscore;

    public bool getIsStarted()
    {
        return isStarted;
    }


    public void IncreaseScore(int increment)
    {
        score += increment;
        scoreText.text = "Score : " + score;
        hiscoreText.text = "HiScore : " + hiscore;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        ShipOrigin = new Vector3(0f, 0f, -4f);

 
        startButton.onClick.AddListener(delegate { menu.SetActive(false); isStarted = true; });

        pauseButton = GetComponent<Button>();

        hiscore = PlayerPrefs.GetInt("hiscore");
        hiscoreText.text = "Hiscore : " + hiscore;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            pauseObject.SetActive(true);
        }

        if (paused)
        {
            //pauseButton.GetComponentInChildren<Text>().text = "Resume";
        }
        else
        {
            //pauseButton.GetComponentInChildren<Text>().text = "Pause";
        }

        if (isGameOver)
        {
            menu.SetActive(false);
            gameovermenu.SetActive(true);
        }
    }

}
