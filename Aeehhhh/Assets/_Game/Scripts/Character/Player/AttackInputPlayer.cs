using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AttackInputPlayer : MonoBehaviour
{
    [SerializeField] private AttackAction _attackAction;

    [SerializeField] private FloatReference attackCooldown;
    
    [SerializeField] private VoidEvent punchEvent;

    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .ThrottleFirst(TimeSpan.FromSeconds(attackCooldown.Value))
            .Subscribe(_ =>
            {
                var pos = Input.mousePosition;
                pos.z = 10;
                pos = Camera.main.ScreenToWorldPoint(pos);

                _attackAction.Do(gameObject, pos - transform.position);
                punchEvent.Raise();
            });
    }
}
