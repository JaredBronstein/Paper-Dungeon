using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAScene : MonoBehaviour
{
    // this is all thats needed to load the next scene, takes in the scene index which can be found in the build settings
    public void LoadTheScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
