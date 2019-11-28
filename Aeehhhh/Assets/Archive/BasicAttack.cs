using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Tags;
using UnityEngine;

public abstract class BasicAttack : MonoBehaviour
{
    [SerializeField] protected IntReference damageAmount;

    [SerializeField] protected LayerMask targetLayer;

    [SerializeField] protected FloatReference attackRadius;

    [SerializeField] protected FloatReference attackDuration;
    
    public void TryAttack(Vector2 direction)
    {
        Vector2 attackPosition = (Vector2) transform.position + direction;
        
        Collider2D[] attackArea = GetTargets(attackPosition);
        if (attackArea.Length == 0) return;
        GameObject target = attackArea[Random.Range(0, attackArea.Length)].gameObject;

        if (target != null)
        {
            //TODO: animation trigger

            Debug.Log("Attempting to hit! Target: " + target.name);

            StartCoroutine(TryAttackCoroutine(attackPosition));
        }
    }

    IEnumerator TryAttackCoroutine(Vector2 attackPosition)
    {
        yield return new WaitForSeconds(attackDuration);
            
        Collider2D[] attackArea = GetTargets(attackPosition);

        foreach (var target in attackArea)
        {
            Debug.Log("Hit successful! Target: " + target.name); 
            //DealDamage(target.gameObject);
        }
        
    }

    protected void DealDamage(GameObject target)
    {
        target.GetComponent<IDamageAble>().GetDamage(damageAmount);
    }
    
    protected Collider2D[] GetTargets(Vector2 position)
    {
        return  Physics2D.OverlapCircleAll(position, attackRadius, targetLayer);
    }
}
