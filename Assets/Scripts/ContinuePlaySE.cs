using UnityEngine;

public class ContinuePlaySE : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnButtonClicked()
    {
        audioSource.Play();
    }
}
