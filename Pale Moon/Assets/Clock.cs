using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    // Start is called before the first frame update
    void Start()
    {
        _runtimeData.ClocksRemaining++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" || collider.gameObject.name == "Pillow(Clone)")
        {
            _runtimeData.ClocksRemaining--;
            _runtimeData.spawnShadows = true;
            Destroy(this.gameObject);
        }
    }
}
