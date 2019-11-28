using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniRx;
using UnityAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Aeehhhh/Actions/AttackAction")]
public class AttackAction : AtomAction<GameObject, Vector2>
{
    [Header("Attack Stats")]
    [SerializeField] private IntReference damageAmount;

    [SerializeField] private FloatReference attackRadius;

    [SerializeField] private FloatReference attackRange;
    
    [SerializeField] private FloatReference attackDuration;
    
    [SerializeField] private LayerMask targetLayer;

    [Header("Debug Mode")]
    [SerializeField] private BoolReference debugMode;

    [SerializeField] private GameObject debugPrefab;
    
    public override void Do(GameObject t1, Vector2 t2)
    {
       TryAttack(t1, t2);
    }

    private void TryAttack(GameObject attacker, Vector2 attackDirection)
    {
        Vector2 attackPosition = (Vector2)attacker.transform.position + attackDirection.normalized * attackRange;
        
        if (debugMode.Value)
        {
            DebugShow(attackPosition);
        }
        
        Collider2D[] attackArea = GetTargets(attackPosition);
        if (attackArea.Length == 0) return;
        GameObject target = attackArea[Random.Range(0, attackArea.Length)].gameObject;

        if (target != null)
        {
            //TODO: animation trigger
            
            Debug.Log("Attempting to hit! Target: " + target.name);

            Observable.EveryUpdate().Buffer(TimeSpan.FromSeconds(attackDuration)).Take(1).Subscribe(_ =>
            {
                attackArea = GetTargets(attackPosition);

                foreach (var t in attackArea)
                {
                    Debug.Log("Hit successful! Target: " + t.name); 
                    
                    DealDamage(target.gameObject);
                }
            });
        }
    }

    private void DealDamage(GameObject target)
    {
        target.GetComponent<IDamageAble>()?.GetDamage(damageAmount);
    }
    
    private Collider2D[] GetTargets(Vector2 position)
    {
        return  Physics2D.OverlapCircleAll(position, attackRadius, targetLayer);
    }

    private void DebugShow(Vector2 center)
    {
        var d = Instantiate(debugPrefab, center, Quaternion.identity);
        d.transform.localScale *= attackRadius;
        Destroy(d, attackDuration);
    }
}
