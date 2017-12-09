using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : Singleton<gameManager> {

    public float score = 0f;

    public Light sceneLight;

    public AudioSource musicAudioSource;

    public Text mainTimeDisplay;
    public Text mainScoreDisplay;
    public Text gameOverTime;

    public bool gameIsOver = false;

    public GameObject gameOverDisplay;
    public GameObject gameOverTimeDisplay;
    public GameObject playAgainButton;
    public GameObject MenuButton;

    private float timer; 

    private void Start()
    {
        gameIsOver = false;

        score = 0;

        timer = 0;

        if (gameOverTimeDisplay)
        {
            gameOverTimeDisplay.SetActive(false);
        }

        if (gameOverDisplay)
            gameOverDisplay.SetActive(false);

        if (playAgainButton)
            playAgainButton.SetActive(false);

        if (MenuButton)
            MenuButton.SetActive(false);

        sceneLight.gameObject.SetActive(true);

        mainScoreDisplay.gameObject.SetActive(true);
        mainTimeDisplay.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            endGame();
        }

        else
        {
            timer += Time.deltaTime;
            score += Time.deltaTime;
            mainScoreDisplay.text = score.ToString("0.00");
            mainTimeDisplay.text = timer.ToString("0.0");
        }
    }

    public void endGame()
    {
        gameIsOver = true; 

        if(sceneLight)
            sceneLight.gameObject.SetActive(false);

        if(mainScoreDisplay)
            mainScoreDisplay.gameObject.SetActive(false); 

        if(gameOverTime)
            gameOverTime.text = timer.ToString("0"); 

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverTimeDisplay)
            gameOverTimeDisplay.SetActive(true);
        

        if (gameOverDisplay)
            gameOverDisplay.SetActive(true);

        // activate the playAgainButtons gameObject, if it is set 
        if (playAgainButton)
            playAgainButton.SetActive(true);

        if (MenuButton)
            MenuButton.SetActive(true);

        if (musicAudioSource)
            musicAudioSource.enabled = false; // turn off the music
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
