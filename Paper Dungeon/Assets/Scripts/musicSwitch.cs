using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    AudioSource overworld, combat;

    AudioSource footsteps;
    PlayerController2 playerInCombat;

    // Start is called before the first frame update
    void Start()
    {
        playerInCombat = Player.GetComponent<PlayerController2>();
        footsteps = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInCombat.InCombat == true)
        {
            combat.volume = .2f;
            overworld.volume = 0;
            footsteps.volume = 0;
        }
        else
        {
            overworld.volume = .1f;
            combat.volume = 0;
        }
    }
}
