using UnityEngine;

public class UIBase : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        // 게임 오브젝트에 연결된 Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        // 만약 Animator 컴포넌트가 있으면 "Show" 트리거를 발동하여 애니메이션 재생
        if (animator != null)
        {
            animator.SetTrigger("Show");
        }
        else
        {
            // Animator 컴포넌트가 없는 경우, 기본적으로 게임 오브젝트를 활성화
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        // 만약 Animator 컴포넌트가 있으면 "Hide" 트리거를 발동하여 애니메이션 재생
        if (animator != null)
        {
            animator.SetTrigger("Hide");
        }
        else
        {
            // Animator 컴포넌트가 없는 경우, 기본적으로 게임 오브젝트를 비활성화
            gameObject.SetActive(false);
        }
    }
}




