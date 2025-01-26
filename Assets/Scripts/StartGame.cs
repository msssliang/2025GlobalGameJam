using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public void OnStartButtonClicked()
    {
        CrossScene.Instance.PlayCrossSceneAnimation(() =>
        {
            SceneManager.LoadSceneAsync("GameScene");
        });
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
