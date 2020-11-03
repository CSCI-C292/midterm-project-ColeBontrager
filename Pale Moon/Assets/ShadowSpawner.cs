using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
    [SerializeField] GameObject _shadow;
    [SerializeField] RuntimeData _runtimeData;

    private bool spawning = false;
    
    void Update()
    {
        
        if(_runtimeData.spawnShadows && !spawning)
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
