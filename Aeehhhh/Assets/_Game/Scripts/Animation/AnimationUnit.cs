using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityAtoms;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Aeehhhh/AnimationUnit")]
public class AnimationUnit : ScriptableObject
{
    public new string name;
    public AnimatorControllerParameterType type;

    public BoolVariable boolVariable;
    public IntVariable intVariable;
    public FloatVariable floatVariable;

    public AtomEvent atomEvent;
}

