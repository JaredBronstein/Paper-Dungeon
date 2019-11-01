using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject[] BossList = new GameObject[3];
    private int BossCount = 0;

    private void Update()
    {
        for(int i = 0; i < BossList.Length; i++)
        {
            if(BossList[i].activeSelf)
            {
                BossCount++;
            }
        }
        if(BossCount == 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
