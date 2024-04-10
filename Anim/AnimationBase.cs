using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;

public class AnimationBase : Satebase
{
    Animator _animator;
    public override void UpdateAnimation(PlayerState playerState)
    {
        for (int i = 0; i <= (int)PlayerState.DIE; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if (playerState == ((PlayerState)i))
            {
                _animator.SetBool(stateName, true);
            }
            else
            {
                _animator.SetBool(stateName, false);
            }
        }

    }

    public override void _Start()
    {
        _animator = this.GetComponent<Animator>();
    }

}
