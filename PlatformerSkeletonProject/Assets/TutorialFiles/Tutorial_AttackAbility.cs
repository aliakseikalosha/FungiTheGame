using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_AttackAbility : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask attackLayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attacking");

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, 1, attackLayers);

        foreach (var hit in hits)
        {
            Destroy(hit.gameObject);
        }

    }
}
