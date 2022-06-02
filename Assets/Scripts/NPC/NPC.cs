using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public float initialSpeed;
    private int index;
    private Animator animator;
    public List<Transform> paths = new List<Transform>();

    private void Start()
    {
        initialSpeed = speed;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (DialogueControl.instance.isOpen)
        {
            speed = 0f;
            animator.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            animator.SetBool("isWalking", true);
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            index = Random.Range(0, paths.Count);
            if (index >= paths.Count)
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
