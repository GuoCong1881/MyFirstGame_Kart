using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public float timer;
    public int totalMark;
    public bool gameStarted = false;
    public GameObject startButton;
    public GameObject resetButton;

    public Text timerText;
    public Text markText;
    public Text finalScoreText;
    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        startButton.SetActive(true);
        resetButton.SetActive(false);
    }

    // startButton controls this method, once the button is clicked, StartGame() is called 
    public void StartGame()
    {
        gameStarted = true;

        // reset timer
        timer = timeLimit;

        // reset mark
        totalMark = 0;

        // start game
        Time.timeScale = 1.0f;
        startButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            markText.text = "Score: " + totalMark.ToString();
            timer -= Time.deltaTime;
            timerText.text = "Time Remain: " + Mathf.Ceil(timer).ToString();
            if (timer < 0)
            {
                EndGame();
            }
        }   
        
    }

    public void EndGame()
    {
        gameStarted = false;
        Time.timeScale = 0f;
        resetButton.SetActive(true);
        finalScoreText.text = "Your final score is " + totalMark.ToString() + "\n Continue?";
        //string name = SceneManager.GetActiveScene().name;
        //Debug.Log(name);
    }

    public void ResetGame()
    {
        startButton.SetActive(true);
        resetButton.SetActive(false);
        SceneManager.LoadScene("Game");
    }


    public void AddMark()
    {
        totalMark = totalMark + 10;
    }

    public void DeductMark()
    {
        totalMark = totalMark - 2;    
    }

    public void Collide()
    {
        totalMark = totalMark - 10;
    }


    


}
