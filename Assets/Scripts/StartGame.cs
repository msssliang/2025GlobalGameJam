using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
        }
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
