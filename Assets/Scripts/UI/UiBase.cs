using UnityEngine;

public class UIBase : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        if (animator != null)
        {
            animator.SetTrigger("Show");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hide");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}









