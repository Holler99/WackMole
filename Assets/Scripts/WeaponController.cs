using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Hammer;
    public bool CanAttack = true;
    public float AttackCooldown = 0.5f;
    public bool isAttacking = false;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                HammerAttack();
            }
        }
    }


    public void HammerAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = Hammer.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }



    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }


    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }


}
