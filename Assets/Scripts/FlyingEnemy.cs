using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public static int health = 5;
    public Transform startPos;
    private bool lookRight = true;
    private bool rightEnd = false;
    public float TimeToMoveRight = 1f;
    public float TimeToMoveLeft = 1f;
    private Rigidbody2D enemyrb;
    public static Animator anim;
    public static bool shouldMove = true;
    public static bool shouldShoot = true;
    public GameObject character;
    public float speed = 5f;
    public static bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector3(transform.position.y, -5);
        anim = GetComponent<Animator>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Health", health);

        if (!rightEnd && shouldMove)
        {
            MoveRight();
        }
        else if (rightEnd && shouldMove)
        {
            MoveLeft();
        }

        if (!shouldMove)
        {
            StartCoroutine(WaitBeforeDelete());
        }
    }

    private void MoveRight() {
        moveLeft = false;
        enemyrb.transform.position = new Vector3(transform.position.x + 0.1f * speed, transform.position.y, transform.position.z);
    }

    private void MoveLeft()
    {
        moveLeft = true;
        enemyrb.transform.position = new Vector3(transform.position.x - 0.1f * speed, transform.position.y, transform.position.z);
    }

    private void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0, 180f, 0);
    }

    IEnumerator WaitBeforeDelete()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    IEnumerator Move()
    {

        if (shouldMove)
        {
            yield return new WaitForSeconds(TimeToMoveRight);
            rightEnd = true;
            moveLeft = false;
            Flip();
            yield return new WaitForSeconds(TimeToMoveLeft);
            rightEnd = false;
            moveLeft = true;
            Flip();
            StartCoroutine(Move());
        }
    }
}
