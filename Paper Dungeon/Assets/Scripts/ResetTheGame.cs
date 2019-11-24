using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTheGame : MonoBehaviour
{
    [SerializeField]
    int SceneIndex;

    // Update is called once per frame
    void Update()
    {
        Reset();
    }

    private void Reset()
    {
        if (Input.GetButton("Reset"))
        {
            SceneManager.LoadScene(SceneIndex);
        }


    }
}
