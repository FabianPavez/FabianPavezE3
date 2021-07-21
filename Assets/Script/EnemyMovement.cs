using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private IEnumerator coroutine;
    public float speed = 20f;
    public Rigidbody2D rb;
    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
        rb.velocity = Vector2.up * speed;
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("naveblanca"))
        {
            Debug.Log("100 puntos blancos");
            Score.scorevalor +=100;
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("navenegra"))
        {
            Debug.Log("100 puntos negros");
            Score.scorevalor +=100;
            Destroy(collision.gameObject);
        }
    }
    
}
