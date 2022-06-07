using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class For_button : MonoBehaviour
{
   public void Scenes(int number)
   {
        SceneManager.LoadScene(number);
   }
   public void ExitApplication()
   {
       Application.Quit();
   }
    
    public void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)){
        Application.Quit();
      }
    }
}