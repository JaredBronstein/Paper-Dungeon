using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAScene : MonoBehaviour
{
    public void LoadTheScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
