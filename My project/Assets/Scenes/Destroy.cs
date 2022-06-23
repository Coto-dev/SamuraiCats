using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  void OnTriggerStay2D(Collider2D other) {
    if (other.CompareTag("Player") ){
        Destroy(other.gameObject);
    }
      Debug.Log("hello");

  }


}
