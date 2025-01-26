using UnityEngine;

public class ContinuePlaySE : MonoBehaviour
{
    public AudioClip audioClip;

    public void OnButtonClicked()
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }
}
