//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Death : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    Vector2 CPoint = new Vector2(55.8f, -1.9f);

//    //private void OnTriggerEnter2D(Collider2D cPoint)
//    //{
//    //    CPoint = body.position;
//    //    Debug.Log(body.position);
//    //}

//    private PlayControlPlatform player1;
//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        player1 = FindObjectOfType<PlayControlPlatform>();
//        player1.cPoint(1) = collision.position;
//    }
//}
