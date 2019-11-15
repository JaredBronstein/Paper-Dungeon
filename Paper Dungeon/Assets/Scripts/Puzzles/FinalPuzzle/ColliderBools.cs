using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBools : MonoBehaviour
{

    [Header("Puzzle1")]
    public Level1 lv1 = new Level1();
    public Lever2 lv2 = new Lever2();

    public Level1 lv1_1 = new Level1();
    public Lever2 lv2_2 = new Lever2();

    public Lever2 lv2_3 = new Lever2();

    [SerializeField] GameObject Colliders1;

    [Header("Puzzle2")]

    public Level1 p2lv1 = new Level1();
    public Lever2 p2lv2 = new Lever2();

    public Level1 p2lv1_2 = new Level1();
    public Lever2 p2lv2_2 = new Lever2();

    public Level1 p2lv1_3 = new Level1();

    [SerializeField] GameObject Colliders2State1;
    [SerializeField] GameObject Colliders2State2;

    [Header("Puzzle3")]

    public Level1 p3lv1 = new Level1();
    public Lever2 p3lv2 = new Lever2();

    public Level1 p3lv1_2 = new Level1();

    public Level1 p3lv1_3 = new Level1();
    public Lever2 p3lv2_2 = new Lever2();

    [SerializeField] GameObject Colliders3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puzzle1();
        puzzle2();
        puzzle3();
    }

    void puzzle1()
    {
        if (lv1.leverActivated == false && lv2.leverActivated == false && lv1_1.leverActivated == true && lv2_2.leverActivated == true && lv2_3.leverActivated == true)
        {
            Colliders1.SetActive(false);
        }
        else
        {
            Colliders1.SetActive(true);
        }

    }

    void puzzle2()
    {
        if (p2lv1.leverActivated == true && p2lv1.leverActivated == true && p2lv1_2.leverActivated == false && p2lv2_2.leverActivated == false && p2lv1_3.leverActivated == true)
        {
            Colliders2State1.SetActive(false);
            Colliders2State2.SetActive(false);
        }

        else if (p2lv1.leverActivated == false && p2lv1.leverActivated == false && p2lv1_2.leverActivated == true && p2lv2_2.leverActivated == true && p2lv1_3.leverActivated == true)
        {
            Colliders2State1.SetActive(false);
            Colliders2State2.SetActive(true);
        }

        else if (p2lv1.leverActivated == false && p2lv1.leverActivated == false && p2lv1_2.leverActivated == false && p2lv2_2.leverActivated == false && p2lv1_3.leverActivated == true)
        {
            Colliders2State1.SetActive(false);
            Colliders2State2.SetActive(true);
        }

        else
        {
            Colliders2State1.SetActive(true);
        }
    }

    void puzzle3()
    {
        if (p3lv1.leverActivated == true && p3lv2.leverActivated == true && p3lv1_2.leverActivated == true && p3lv1_3.leverActivated == true && p3lv2_2.leverActivated == true)
        {
            Colliders3.SetActive(false);
        }
        else
        {
            Colliders3.SetActive(true);
        }
    }
}
