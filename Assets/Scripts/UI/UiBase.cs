using UnityEngine;

public class UIBase : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        // ���� ������Ʈ�� ����� Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        // ���� Animator ������Ʈ�� ������ "Show" Ʈ���Ÿ� �ߵ��Ͽ� �ִϸ��̼� ���
        if (animator != null)
        {
            animator.SetTrigger("Show");
        }
        else
        {
            // Animator ������Ʈ�� ���� ���, �⺻������ ���� ������Ʈ�� Ȱ��ȭ
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        // ���� Animator ������Ʈ�� ������ "Hide" Ʈ���Ÿ� �ߵ��Ͽ� �ִϸ��̼� ���
        if (animator != null)
        {
            animator.SetTrigger("Hide");
        }
        else
        {
            // Animator ������Ʈ�� ���� ���, �⺻������ ���� ������Ʈ�� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}




