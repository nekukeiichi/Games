using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RopperAnimator
{
    //Hold the animator
    private Animator myAnim;

    //Here are the Int states for the ropper
    /* 
    Right Middle = 0
    Left Middle = 1
    Left = 2
    Right = 3
    */

    public RopperAnimator(Animator _myAnim)
    {
        myAnim = _myAnim;
    }

    public void Animate(int _index)
    {
        myAnim.SetInteger("PlayerState", _index);

    }

    public void Animate(string _animName) 
    {
        myAnim.Play(_animName);
    }

}
