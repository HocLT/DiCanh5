using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int playerLives = 3;

    [SerializeField]
    TextMeshProUGUI livesText;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    int score = 0;

    private void Awake()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = $"{playerLives}";
        scoreText.text = $"{score}";
    }

    // playerLives = 0
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // load lại scene
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = $"{playerLives}";
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = $"{score}";
    }
}
