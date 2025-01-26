using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        StartCoroutine(LoadScene());
    }
    public void OnExitButtonClicked()
    {
        StartCoroutine(Quit());
    }

    public IEnumerator LoadScene()
    {
        CrossScene.Instance.PlayCrossSceneAnimation(() =>
        {
            SceneManager.LoadSceneAsync("GameScene");
        });
        yield return null;
    }

    public IEnumerator Quit()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
