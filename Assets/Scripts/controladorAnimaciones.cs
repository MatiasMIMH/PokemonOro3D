using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controladorAnimaciones : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }


    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
        }

        if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
