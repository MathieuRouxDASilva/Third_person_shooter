using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetManger : MonoBehaviour
{
    //all panels
   public int numberOfBrokenThing = 0;
   [SerializeField] private TargetScript target1;
   [SerializeField] private TargetScript target2;
   [SerializeField] private TargetScript target3;
   [SerializeField] private TargetScript target4;
   [SerializeField] private TargetScript target5;
   [SerializeField] private TargetScript target6;
   [SerializeField] private TargetScript target7;
   
   private void Update()
   {
       //best way i found and understood to set them all active
      if (numberOfBrokenThing == 7)
      {
          target1.gameObject.SetActive(true);
          target2.gameObject.SetActive(true);
          target3.gameObject.SetActive(true);
          target4.gameObject.SetActive(true);
          target5.gameObject.SetActive(true);
          target6.gameObject.SetActive(true); 
          target7.gameObject.SetActive(true);
          
        numberOfBrokenThing = 0;
      }
   }
}
