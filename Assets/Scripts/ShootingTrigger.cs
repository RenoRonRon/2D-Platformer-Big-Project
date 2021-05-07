using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrigger : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D bullet;
    public Transform gunPoint;
    public float fireRate = 1;
    public Transform player;
    Vector3 PlayerPos;
    private Rigidbody2D clone;
    float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fireRate = Random.Range(0.5f, 3f);
            elapsedTime += Time.deltaTime;

            if (elapsedTime > fireRate - 0.2f)
            {
                FlyingEnemy.anim.Play("Idle");
            }

            if (elapsedTime > fireRate && FlyingEnemy.shouldShoot)
            {
                elapsedTime = 0.0f;
                clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
                if (FlyingEnemy.moveLeft)
                {
                    Flip();
                }
                clone.velocity = transform.right * speed;
            }
        }
    }

    void Flip()
    {
        clone.transform.Rotate(0, 180f, 0);
    }
}
