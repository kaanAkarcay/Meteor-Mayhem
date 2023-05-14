using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 4.5f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform[] fireballSpawnPoints;
    [SerializeField] private float fireballSpeed = 10f;
    [SerializeField] private GameManegar gameManegar;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (gameManegar.ammo >= 2) )
        {
            ShootFireballs();
            FindAnyObjectByType<GameManegar>().SpendAmmo();
        }
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("FireBall") && !collision.gameObject.CompareTag("Ammo")) {
            Debug.Log("collided");
            FindAnyObjectByType<GameManegar>().EndGame();
        }
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("got ammo");
            FindAnyObjectByType<GameManegar>().addAmmo();
        }

    }
    void ShootFireballs()
    {
        foreach (Transform spawnPoint in fireballSpawnPoints)
        {
            GameObject fireball = Instantiate(fireballPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
            fireballRb.velocity = spawnPoint.up * fireballSpeed;
        }
    }
}
