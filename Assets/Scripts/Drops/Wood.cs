using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;
    void Start()
    {

    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeMove)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
         if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerInventory>().totalWood += 1;
            Destroy(gameObject);
        }
    }
}
