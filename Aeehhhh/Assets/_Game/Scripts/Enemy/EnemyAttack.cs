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
    private Transform player;
    [SerializeField] private AttackAction _attackAction;

    [Header("Attack Stats")] 
    [SerializeField] private FloatReference eachXSeconds;
    [SerializeField] private FloatReference attackAtThisDistance;
    
    void Start()
    {
        player = AtomTags.FindByTag(playerTag.Value).transform;
        
        Observable.EveryUpdate().Buffer(TimeSpan.FromSeconds(eachXSeconds))
            .Where(_ => attackAtThisDistance.Value >= Vector2.Distance(player.position, transform.position))
            .Subscribe(_ => _attackAction.Do(gameObject, player.position - transform.position));
    }
}
