using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        Invoke("LoadScene", 0.5f);
    }
    public void OnExitButtonClicked()
    {
        Invoke("Quit", 0.5f);       
    }
    
    public void LoadScene() 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
