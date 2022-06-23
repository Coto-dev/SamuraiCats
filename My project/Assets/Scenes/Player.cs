using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  void OnTriggerStay(Collider other) {
    if (other.tag =="Player")
        Destroy(other.gameObject);
        
    }

}
