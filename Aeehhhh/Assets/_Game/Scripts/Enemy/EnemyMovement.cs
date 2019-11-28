using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Tags;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private AnimationHandler _animationHandler;
    private BoolVariable isMoving;
    
    [SerializeField] private StringConstant playerTag;
    private Transform player;
    public FloatReference moveSpeed;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = new BoolVariable();
        isMoving.Value = false;
        _animationHandler.CreateAnimationUnit("Moving", AnimatorControllerParameterType.Bool, isMoving);
        
        player = AtomTags.FindByTag(playerTag.Value).transform;
        
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        
        //animation
        isMoving.Value = direction.magnitude >= 1;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
        direction.Normalize();
        _movement = direction;
    }
    private void FixedUpdate() {
        MoveCharacter(_movement);
    }
    void MoveCharacter(Vector2 direction){
        _rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
