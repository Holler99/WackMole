using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Vector3 startPosition;

    public Quaternion startRotation;



    private void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.rotation;
    }


    private void OnTriggerEvent(Collider other)
    {
        if(other.CompareTag("mole"))
        {
            GameObject mole = other.gameObject;
            //GameController.instance.DestroyMole(mole);
        }
    }




}
