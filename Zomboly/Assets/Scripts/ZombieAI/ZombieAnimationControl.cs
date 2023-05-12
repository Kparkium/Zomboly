using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationControl : MonoBehaviour
{
    public Animator animator;
    public int index = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimationIndex(int newIndex)
    {
        if (newIndex != index)
        {
            index = newIndex;
            animator.SetInteger("AnimIndex", newIndex);
        }
    }
}
