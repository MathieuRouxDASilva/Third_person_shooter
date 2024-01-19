using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private TargetManger _targetManager; 
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            _targetManager.numberOfBrokenThing++;
        }
    }

    private void Start()
    {
        _targetManager = GetComponentInParent<TargetManger>();
    }
}
