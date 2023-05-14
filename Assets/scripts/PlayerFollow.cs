using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private float limitedValue;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float followForce = 100f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform[] fireballSpawnPoints;
    [SerializeField] private float fireballSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButtonDown(0))
        //{
        //    ShootFireballs();
        //}
        Vector2 position = rb.position;

        float mouseX = Input.mousePosition.x;
        float targetX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, 0)).x;

        float xDiff = targetX - position.x;
        float xForce = Mathf.Clamp(xDiff * followForce, -speed, speed);

        rb.AddForce(Vector2.right * xForce);

        Vector2 newPosition = rb.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -limitedValue, limitedValue);

        rb.MovePosition(newPosition);
    }
    void ShootFireballs()
    {
        Debug.Log("shots fired");
        foreach (Transform spawnPoint in fireballSpawnPoints)
        {
            GameObject fireball = Instantiate(fireballPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
            fireballRb.velocity = spawnPoint.up * fireballSpeed;
        }
    }
}
