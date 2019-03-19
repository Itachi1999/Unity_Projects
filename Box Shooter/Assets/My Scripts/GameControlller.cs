using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlller : MonoBehaviour {

    public static GameControlller gam;

    public int score = 0;

    public bool canBeatLevel = false;
    public int scoreToBeatLevel = 15;

    public float startTime = 15.0f;

    public Text mainScoretext;
    public Text timeDisplay;

    public GameObject gameOverScoreOutline;

    public AudioSource myAudioSource;

    public bool gameIsOver;

    public GameObject playAgainButton;
    public string playAgainLevelToLoad;

    public GameObject nextLevelButton;
    public string nextLevelToLoad;

    private float currentTime;




	// Use this for initialization
	void Start () {
        currentTime = startTime;
        
        if(gam == null)
        {
            gam = this.gameObject.GetComponent<GameControlller>();
        }

        mainScoretext.text = "0";
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(false);

        if (playAgainButton)
            playAgainButton.SetActive(false);

        if (nextLevelButton)
            nextLevelButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameIsOver)
        {
            if(canBeatLevel && score >= scoreToBeatLevel)
            {
                NextLevel();
            }
            else if(currentTime < 0)
            {
                EndGame();
            }
            else
            {
                currentTime -= Time.deltaTime;
                timeDisplay.text = currentTime.ToString("0.00");
            }
        }
		
	}
    void NextLevel()
    {
        timeDisplay.text = "Next Level";

        if (nextLevelButton)
            nextLevelButton.SetActive(true);

        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        if (myAudioSource)
            myAudioSource.pitch = 0.5f;
    }

    void EndGame()
    {
        timeDisplay.text = "Game Over";

        if (playAgainButton)
            playAgainButton.SetActive(true);

        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        if (myAudioSource)
            myAudioSource.pitch = 0.5f;
    }

    public void TargetHit(int scoreAmount, float timeAmount)
    {
        score += scoreAmount;
        mainScoretext.text = score.ToString();

        currentTime += timeAmount;

        if (currentTime < 0)
            currentTime = 0.0f;

        timeDisplay.text = currentTime.ToString("0.00");
    }

    public void Restart()
    {
        SceneManager.LoadScene(playAgainLevelToLoad);
        
    }

    public void LevelJump()
    {
        SceneManager.LoadScene(nextLevelToLoad);
    }
}
