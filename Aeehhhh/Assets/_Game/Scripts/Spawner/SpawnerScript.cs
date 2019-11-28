using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.Editor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float timeTillStart;
    public List<GameObject> enemiesToSpawn;
    public float pauseBetweenSpawns;

    private float _timePassed = 0;
    private bool _hasStarted = false;
    
    // Update is called once per frame
    void Update()
    {
        if (timeTillStart < (_timePassed += Time.deltaTime) && !_hasStarted)
        {
            _hasStarted = true;
            StartCoroutine(StartSpawning());
        }
    }

    IEnumerator StartSpawning()
    {
        if (enemiesToSpawn == null) yield break;

        foreach (GameObject enemy in enemiesToSpawn)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(pauseBetweenSpawns);
        }
    }
}
