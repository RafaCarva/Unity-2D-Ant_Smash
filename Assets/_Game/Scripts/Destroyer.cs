using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D target) 
   {
        if(target.gameObject.CompareTag("Enemy"))
        {
            Destroy(target.gameObject);
        }
   }
}
