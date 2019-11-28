using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityAtoms;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public AnimatorControllerParameter parameter;
    
    [Header("Animation Variables")] 
    [SerializeField] private BoolVariable isMoving;

    private void Start()
    {
        isMoving.ObserveChange().Subscribe(_ =>
        {
            _animator.SetBool("Moving", isMoving.Value);
        });
    }
}
