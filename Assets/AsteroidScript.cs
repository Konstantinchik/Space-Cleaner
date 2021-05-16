using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    public GameObject restartMenu;


    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public float size;
    public float minSize, maxSize;

    int Score; 
    int Hiscore;

    public bool gameover = false;

    public AsteroidScript(int score)
    {
        Score = score;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = GameController.Instance.score;
        Hiscore = GameController.Instance.hiscore;

        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        float speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);

        size = Random.Range(minSize, maxSize);
        asteroid.transform.localScale *= size;

     
    }

    private void OnTriggerEnter(Collider other) // 
    {
        if(other.tag == "Asteroid" || other.tag == "GameBoundary" ) { return; }

        Destroy(gameObject); // destroy asteroid
        Destroy(other.gameObject); // destroy target object

        GameObject explosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        explosion.transform.localScale *= size;


        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity); // Player die

            Score = GameController.Instance.score;

            if (Score > Hiscore)
            {
                Hiscore = Score;
                PlayerPrefs.SetInt("hiscore", Score);
                PlayerPrefs.Save();
                GameController.Instance.hiscore = PlayerPrefs.GetInt("hiscore");
            
            }

            gameover = true;
            GameController.Instance.isGameOver = true;
            GameController.Instance.hiscoreText.text = "HiScore : " + PlayerPrefs.GetInt("hiscore").ToString();

        }
        else
        {
            GameController.Instance.IncreaseScore(10);
        }
    }
   
}
