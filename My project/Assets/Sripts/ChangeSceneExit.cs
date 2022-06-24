using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneExit : MonoBehaviour
{
    public int sceneid;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneid);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadScene();
    }
}
