using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
    [SerializeField] GameObject _shadow;
    [SerializeField] RuntimeData _runtimeData;

    private bool spawning = false;

    private float timeRemaining = 2;
    
    void Update()
    {
        timeRemaining = timeRemaining - Time.deltaTime;
        if((_runtimeData.spawnShadows || timeRemaining <= 0) && !spawning)
        {
            InvokeRepeating("SpawnShadow", 0, 3);
            spawning = true;
        }
    }

    void SpawnShadow()
    {
        Instantiate(_shadow, _runtimeData.playerMovements[0], Quaternion.identity);
    }
}
