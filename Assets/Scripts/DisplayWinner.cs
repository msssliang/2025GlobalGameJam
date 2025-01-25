using UnityEngine;

public class DisplayWinner : MonoBehaviour
{
    public void ShowWinner(int a)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("winner", a);
    }
}
