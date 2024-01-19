using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    private float _timer = 0f;
    private float _impactTimer = 0f;
    private float _timeToDestroyImpact = 3f;

    [SerializeField] private GameObject impact;
    
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _impactTimer += Time.deltaTime;
        
        if (_timer > timeToDestroy)
        {
            Destroy(this.gameObject);
        }

        if (_impactTimer >= _timeToDestroyImpact)
        {
            Destroy(impact);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
        Instantiate(impact, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
