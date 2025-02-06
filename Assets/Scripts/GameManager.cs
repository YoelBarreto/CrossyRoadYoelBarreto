using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Puntos: " + score;
    }

    // Función que detiene el juego y muestra el Game Over
    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        Time.timeScale = 1f;
    }

    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true); 
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartGame);
        Time.timeScale = 0f;
    }
}
