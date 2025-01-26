using System;
using System.Collections;
using UnityEngine;

public class CrossScene : MonoBehaviour
{
    public static CrossScene Instance { get; private set; }
    [field: SerializeField]
    public Animator animator { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlayCrossSceneAnimation(Action callback)
    {
        animator.Rebind();
        animator.Play("Fade");
        StartCoroutine(WaitForAnimation(callback));
    }
    IEnumerator WaitForAnimation(Action callback)
    {
        yield return new WaitForSeconds(2.5f);
        callback?.Invoke();
    }
}
