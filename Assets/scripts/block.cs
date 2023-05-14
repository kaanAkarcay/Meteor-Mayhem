using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2f)
        {
            FindAnyObjectByType<GameManegar>().IncreasePoints(1);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(gameObject);
        }
    }
}
