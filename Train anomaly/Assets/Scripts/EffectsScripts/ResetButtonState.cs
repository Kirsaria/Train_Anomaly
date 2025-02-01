using UnityEngine;

public class ResetButtonsState : MonoBehaviour
{
    public void FixAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.CrossFade("Normal", 0f);
        animator.Update(0f);
    }
}