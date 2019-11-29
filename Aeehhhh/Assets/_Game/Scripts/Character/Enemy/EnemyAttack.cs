using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityAtoms;
using UnityAtoms.Tags;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private StringConstant playerTag;

    [SerializeField] private AttackAction _attackAction;

    [SerializeField] private AnimationHandler _animationHandler;
    private VoidEvent attackEvent;
    
    [Header("Attack Stats")] 
    [SerializeField] private FloatReference eachXSeconds;
    [SerializeField] private FloatReference attackAtThisDistance;
    
    void Start()
    {
        attackEvent = new VoidEvent();
        _animationHandler.CreateAnimationUnit("Punch", AnimatorControllerParameterType.Trigger, atomEvent: attackEvent);
        
        Transform player = AtomTags.FindByTag(playerTag.Value).transform;

        Observable.EveryUpdate().Buffer(TimeSpan.FromSeconds(eachXSeconds))
            .Where(_ => attackAtThisDistance.Value >= Vector2.Distance(player.position, transform.position))
            .Subscribe(_ =>
            {
                _attackAction.Do(gameObject, player.position - transform.position);
                attackEvent.Raise();
            });
    }
}
