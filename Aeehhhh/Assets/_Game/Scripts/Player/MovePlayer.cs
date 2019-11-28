using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private FloatReference speed;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}
