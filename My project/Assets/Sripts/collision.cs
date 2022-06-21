using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private PlayControl player1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        player1 = FindObjectOfType<PlayControl>();
        player1.TakeDamage(1);
    }
}
