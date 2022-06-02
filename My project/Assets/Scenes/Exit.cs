using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
   public void ExitApplication(){

    if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
    {
        Application.Quit();    // закрыть приложение
    }
   
    SceneManager.LoadScene(0);
   }
   
}