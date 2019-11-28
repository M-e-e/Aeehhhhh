using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private FloatReference speed;

    [SerializeField] private BoolVariable playerIsMoving;
    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;

        playerIsMoving.Value = move.magnitude >= .1f;
    }
}
