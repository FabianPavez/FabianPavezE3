using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 20f;
    PlayerMovement target;
    Vector2 moveDirection;
    private IEnumerator coroutine;
    public Rigidbody2D rb;
    public GameObject player;

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        if (rb = null)
        {
            Destroy(this.gameObject);
        }
    }
    
    
    void Start()
    {
        
            coroutine = WaitAndPrint(4.0f);
            StartCoroutine(coroutine);
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindObjectOfType<PlayerMovement>();
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.SetActive(false);
        }
    }
    
  
}
