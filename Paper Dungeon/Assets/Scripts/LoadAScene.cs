using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void LoadTheScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
