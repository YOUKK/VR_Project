using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            if(animator.GetBool("IsGrab"))
                animator.SetBool("IsGrab", false);
            else
                animator.SetBool("IsGrab", true);
        }
    }
}
