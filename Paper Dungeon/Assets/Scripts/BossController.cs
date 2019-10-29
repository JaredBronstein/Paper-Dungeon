using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private Sprite BossSprite, Background;

    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        InvokeRepeating("Blink", 3,3);
    }

    private void Blink()
    {
        animator.SetBool("CanBlink", true);
        animator.SetBool("CanBlink", false);
    }
    public Sprite SetBattleSprite()
    {
        return BossSprite;
    }

    public Sprite SetBackground()
    {
        return Background;
    }
}
