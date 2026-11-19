using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string sceneName = "Level";
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject youtWin;
    [SerializeField] GameObject disableText;
    [SerializeField] TMP_Text enemiesLeft;

    const string ENEMY_GATE = "GATE LEFTS : ";
    const string mainMenu = "MainMenu";
    int enemyGate = 0;
    StarterAssetsInputs starterAssets;
    private void Awake()
    {
        starterAssets = FindFirstObjectByType<StarterAssetsInputs>();
    }
    public void AdjustEnemyGate(int amount)
    {
        enemyGate += amount;

        enemiesLeft.text = ENEMY_GATE + enemyGate.ToString();
        if (enemyGate <= 0 )
        {
            DestroyRemainingEnemies();
            youtWin.SetActive(true);
            starterAssets.SetCursorState(false);
            gameOver.SetActive(false);
            disableText.SetActive(false);
            crosshair.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        crosshair.SetActive(false);
        disableText.SetActive(false);

    }

    private void DestroyRemainingEnemies()
    {
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in remainingEnemies)
        {
            Destroy(enemy);
        }
    }
}
