using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    public Animator Animator;
    private Transform currentPoint;
    public float Speed;
    private bool canMove = true;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
        Animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && !dead)
        {
            if (currentPoint == PointB.transform)
            {
                rb.velocity = new Vector2(Speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-Speed, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == PointB.transform)
            {
                currentPoint = PointA.transform;
                Flip();
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == PointA.transform)
            {
                currentPoint = PointB.transform;
                Flip();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Flip(Transform target = null)
    {
        if (target == null)
        {
            target = currentPoint;
        }
        canMove = true;

        Vector3 localScale = transform.localScale;
        localScale.x = target.position.x < transform.position.x ? -1 * Mathf.Abs(localScale.x) : Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        if (PointA && PointB)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(PointA.transform.position, 1f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(PointB.transform.position, 1f);
            Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead)
        {
            return;
        }
        if (collision.gameObject.name == "Player")
        {
            Flip(collision.transform);
            Animator.SetTrigger(Random.value > 0.5f ? "Attacking" : "Attacking2");
            canMove = false;
        }
    }

    public void Death()
    {
        if (dead)
        {
            return;
        }
        dead = true;
        GameEvents.AddScore(50);
        Animator.SetTrigger("Dying");
    }
}