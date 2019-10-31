using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever4 : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite lever_0;
    public Sprite lever_1;

    public bool leverActivated;

    public GameObject platform1;

    public GameObject inkborders;
    public SpriteRenderer leversprite;

    private float moveleft = .5f;
    private float moveright = -.5f;
    private float borderreturn = -100f;

    // Start is called before the first frame update
    void Start()
    {
        leversprite = GetComponent<SpriteRenderer>();
        leversprite.sprite = lever_0;
        leverActivated = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            if (Input.GetButtonDown("Activate"))
            {
                if (leverActivated == false)
                {
                    Debug.Log("Player activates lever");
                    leverActivated = true;
                    platform1.transform.Translate(0, moveleft, 0);

                }
                else
                {
                    Debug.Log("Player turns off lever");
                    leverActivated = false;
                    platform1.transform.Translate(0, moveright, 0);

                }
            }
        }
    }

    private void Update()
    {
        if (leverActivated == true)
        {
            leversprite.sprite = lever_1;


        }
        if (leverActivated == false)
        {
            leversprite.sprite = lever_0;
        }


    }
}
