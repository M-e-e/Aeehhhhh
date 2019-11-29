using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Aeehhhh/Actions/Death")]
public class DeathAction : GameObjectAction
{
    public override void Do(GameObject t1)
    {
        Destroy(t1);
    }
}
