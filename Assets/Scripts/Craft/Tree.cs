using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Animator animator;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnHit()
    {
        health -= 1;

        animator.SetTrigger("isHit");
        if (health <= 0)
        {
            animator.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Axe")
        {
            OnHit();
        }
    }
}
