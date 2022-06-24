using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Destroy : MonoBehaviour
{
    private PlayControl player1;
    void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player") ){
            player1 = FindObjectOfType<PlayControl>();
            player1.TakeDamage(1000);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      Debug.Log("hello");

  }


}
