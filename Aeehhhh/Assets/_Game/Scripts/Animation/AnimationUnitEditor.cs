using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimationUnit))]
public class AnimationUnitEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var AnimationUnit = target as AnimationUnit;
        
        AnimationUnit.name = EditorGUILayout.TextField("Name", AnimationUnit.name);
        
        AnimationUnit.type = (AnimatorControllerParameterType)EditorGUILayout.EnumPopup("ParameterType", AnimationUnit.type);
        switch (AnimationUnit.type)
        {
            case AnimatorControllerParameterType.Bool:
                AnimationUnit.boolVariable = (BoolVariable)EditorGUILayout.ObjectField("BoolVariable", AnimationUnit.boolVariable, typeof(BoolVariable), true);
                break;
            case AnimatorControllerParameterType.Int:
                AnimationUnit.intVariable = (IntVariable)EditorGUILayout.ObjectField("IntVariable", AnimationUnit.intVariable, typeof(IntVariable), true);
                break;
            case AnimatorControllerParameterType.Float:
                AnimationUnit.floatVariable = (FloatVariable)EditorGUILayout.ObjectField("FloatVariable", AnimationUnit.floatVariable, typeof(FloatVariable), true);
                break;
            case AnimatorControllerParameterType.Trigger:
                AnimationUnit.atomEvent = (AtomEvent)EditorGUILayout.ObjectField("AtomEvent", AnimationUnit.atomEvent, typeof(AtomEvent), true);
                break;
        }
    }
}
