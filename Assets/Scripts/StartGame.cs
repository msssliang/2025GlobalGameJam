using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
