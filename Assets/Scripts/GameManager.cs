using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text gasText;
    public CarController carController;

    private int gas = 100;

    void Start()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        gas = 100;
        UpdateGasUI();
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ConsumeGas(int amount)
    {
        gas -= amount;
        if (gas <= 0)
        {
            gas = 0;
            GameOver();
        }
        UpdateGasUI();
    }

    public void AddGas(int amount)
    {
        gas += amount;
        UpdateGasUI();
    }

    private void UpdateGasUI()
    {
        gasText.text = gas.ToString();
    }
}