using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject mole;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mole" && wc.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }


}
