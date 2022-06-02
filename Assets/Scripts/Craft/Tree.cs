using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
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
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1.5f, 0.5f), Random.Range(-1.5f, 0.5f), 0f), transform.rotation);
            }
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
