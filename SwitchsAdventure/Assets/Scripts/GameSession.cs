using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = (3);
    [SerializeField] int score = (0);
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;


    private void Awake()
    {

        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
            //note DestroyObject() is deprecated
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {

        livesText.text = playerLives.ToString();
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) Destroy(gameObject);
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            playerLives--;
            livesText.text = playerLives.ToString();

            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        else
        {
            print("Dead");
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            
        }
    }
}
