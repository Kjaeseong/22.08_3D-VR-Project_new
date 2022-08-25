using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : SingletonBehaviour<SceneChanger>
{
    void Awake()
    {
        base.Awake();
    }


    public void Scene_Title()
    {
        SceneManager.LoadScene(0);
    }

    public void Scene_InGame()
    {
        SceneManager.LoadScene(1);
    }

}
