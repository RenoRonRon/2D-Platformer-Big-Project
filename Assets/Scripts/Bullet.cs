using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        StartCoroutine(WaitBeforeDelete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitBeforeDelete()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FlyingEnemy.health--;
            if (FlyingEnemy.health < 1)
            {
                FlyingEnemy.shouldMove = false;
                FlyingEnemy.shouldShoot = false;
            }
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
