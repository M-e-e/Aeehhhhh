using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityAtoms;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private AnimationUnit[] _animationUnits;
    
    private void Start()
    {
        foreach (var unit in _animationUnits)
        {
            SetUpAnimationUnit(unit);
        }
    }

    private void OnDisable()
    {
        foreach (var unit in _animationUnits)
        {
            if (unit.atomEvent != null)
            {
                unit.atomEvent.Unregister(TriggerListener(unit.name));
            }
        }
    }

    Action TriggerListener(string name)
    {
        _animator.SetTrigger(name);
        _animator.ResetTrigger(name);
        
        return null;
    }

    private void AddToAnimationUnits(AnimationUnit newUnit)
    {
        _animationUnits.Append(newUnit);
    }

    public void CreateAnimationUnit(string name, AnimatorControllerParameterType type, BoolVariable boolVariable=null, IntVariable intVariable=null, FloatVariable floatVariable=null)
    {
        AnimationUnit unit = ScriptableObject.CreateInstance<AnimationUnit>();

        unit.name = name;

        if (boolVariable != null)
        {
            unit.boolVariable = boolVariable;
            BoolEvent boolEvent = ScriptableObject.CreateInstance<BoolEvent>();
            boolVariable.Changed = boolEvent;
        }
        else if (intVariable != null)
        {
            unit.intVariable = intVariable;
            IntEvent intEvent = ScriptableObject.CreateInstance<IntEvent>();
            intVariable.Changed = intEvent;
        }
        else if (floatVariable != null)
        {
            unit.floatVariable = floatVariable;
            FloatEvent floatEvent = ScriptableObject.CreateInstance<FloatEvent>();
            floatVariable.Changed = floatEvent;
        }

        AddToAnimationUnits(unit);
        SetUpAnimationUnit(unit);
    }

    private void SetUpAnimationUnit(AnimationUnit unit)
    {
        if (unit.boolVariable != null)
        {
            unit.boolVariable.ObserveChange().Subscribe(_ =>
            {
                _animator.SetBool(unit.name, unit.boolVariable.Value);
            });
        }
        else if (unit.intVariable != null)
        {
            unit.intVariable.ObserveChange().Subscribe(_ =>
            {
                _animator.SetInteger(unit.name, unit.intVariable.Value);
            });
        }
        else if (unit.floatVariable != null)
        {
            unit.floatVariable.ObserveChange().Subscribe(_ =>
            {
                _animator.SetFloat(unit.name, unit.floatVariable.Value);
            });
        }
        else if (unit.atomEvent != null)
        {
            unit.atomEvent.Register(TriggerListener(unit.name));
        }
    }
}
