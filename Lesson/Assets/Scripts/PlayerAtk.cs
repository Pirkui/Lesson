using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] float cd;

    public bool canAttack = true;

    float cdDelta;

    [SerializeField] GameObject bullet;
    Rigidbody2D rb;

    public bool isAttacking = false;

    Animator animator;

    void GetAnimationInfo()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && isAttacking == true)
        {
            isAttacking = false;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Attack();
        GetAnimationInfo();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {

            GameObject _Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            _Bullet.GetComponent<BulletBehavior>().direction = rb.velocity;
            isAttacking = true;
            canAttack = false;
            cdDelta = cd;
        }

        if (canAttack == false)
        {
            cdDelta -= Time.deltaTime;

            if (cdDelta <= 0)
            {
                canAttack = true;
            }
        }
    }
}
