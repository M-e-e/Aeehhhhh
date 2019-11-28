using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class AttackInputPlayer : MonoBehaviour
{
    [SerializeField] private AttackAction _attackAction;

    [SerializeField] private VoidEvent punchEvent;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Input.mousePosition;
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);

            _attackAction.Do(gameObject, pos - transform.position);
            punchEvent.Raise();
        }    
    }
}
