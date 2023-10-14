using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_control : MonoBehaviour
{
    public int animationNumber;

    private int _previousAnimationNumber;
    private Animator animator;

    void Start()
    {
        _previousAnimationNumber = animationNumber;
        this.animator = this.GetComponent<Animator>();
        this.animator.SetBool("animation_" + animationNumber, true);
    }

    private void OnEnable()
    {
        _previousAnimationNumber = animationNumber;
        this.animator = this.GetComponent<Animator>();
        this.animator.SetBool("animation_" + animationNumber, true);
    }

    public void StartAnimation()
    {
        this.animator.SetBool("animation_" + _previousAnimationNumber, false);
        this.animator.SetBool("animation_" + animationNumber, true);
        _previousAnimationNumber = animationNumber;
    }

    void Update()
    {

    }
}
