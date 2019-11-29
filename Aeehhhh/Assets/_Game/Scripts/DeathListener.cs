using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class DeathListener : MonoBehaviour
{
    [SerializeField] private GameObjectEvent deathEvent;
    [SerializeField] private GameObjectAction deathAction;

    private void Awake()
    {
        deathEvent.Register(AnswerTheCall);
    }

    private void OnDisable()
    {
        deathEvent.Unregister(AnswerTheCall);
    }

    private void AnswerTheCall()
    {
        deathAction.Do(gameObject);
    }
}
