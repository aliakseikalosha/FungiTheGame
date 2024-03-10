using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class AttackAbility : MonoBehaviour
{
    public Animator Animator;
    public Transform AttackPoint;
    public LayerMask AttackLayers;

    public AudioSource MyFX;
    public AudioClip EmptySlashFX;
    public AudioClip HitSlashFX;

    private bool isDead = false;

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
        Animator.SetTrigger("Attacking");

        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, 1, AttackLayers);
        bool hitAnyone = false;
        foreach (var hit in hits)
        {
            hit.gameObject.GetComponent<EnemyPatrol>().Death();
            hitAnyone = true;
        }
        MyFX.PlayOneShot(hitAnyone ? HitSlashFX : EmptySlashFX);
    }
}
