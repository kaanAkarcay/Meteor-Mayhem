using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallLogic : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float destroyHeight = 10f;
    //[SerializeField] private float shrinkSize = 0.2f;
    [SerializeField] private float shrinkSpeed = 0.05f;
    [SerializeField] private float waitTime = 0.05f;
    private bool check = false;
    private Vector3 shrinkStep;

    // Start is called before the first frame update
    void Start()
    {
        shrinkStep = new Vector3(shrinkSpeed, shrinkSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if ((transform.position.y > destroyHeight || !gameObject.activeInHierarchy) && !check)
        {
            StartCoroutine(ShrinkAnimation());
            check = true;
            Debug.Log("checked");
        }
    }

    private IEnumerator ShrinkAnimation()
    {
        Vector3 initialScale = transform.localScale;
        Vector3 shrinkSize = new Vector3(0.1f, 0.1f, 0f);
        //float shrinkSpeed = 0.05f;
        //float waitTime = 0.1f;

        while (transform.localScale.x > 0.1f && transform.localScale.y > 0.1f)
        {
            transform.localScale -= shrinkSize * shrinkSpeed;
            yield return new WaitForSeconds(waitTime);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShrinkAnimation());
        }
    }
}
