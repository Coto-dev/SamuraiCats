using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class For_button : MonoBehaviour
{
   public void Scenes(int number){
         SceneManager.LoadScene(number);
   }
}