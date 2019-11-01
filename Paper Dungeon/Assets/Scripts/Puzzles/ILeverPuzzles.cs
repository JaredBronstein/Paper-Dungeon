using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// made by jonathan way
// template code for a majority of the puzzles (ones that only use levers, not ink)
//since every lever will need an on and off the holders for those are here instead of in each puzzles code
public class ILeverPuzzles : MonoBehaviour
{
    [SerializeField]
    protected Sprite leverOn, leverOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void SwitchStates()
    {

    }

    protected virtual void LeversOnOff()
    {

    }

    protected virtual void SwitchThisLever()
    {

    }

}
