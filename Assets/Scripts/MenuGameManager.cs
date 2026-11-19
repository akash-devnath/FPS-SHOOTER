using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    const string LEVEL = "Level";
    public void StartGame()
    {
        SceneManager.LoadScene(LEVEL);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
