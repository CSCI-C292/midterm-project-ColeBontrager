using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(index >= _runtimeData.playerMovements.Count - 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            
            Vector3 newPos = _runtimeData.playerMovements[index];
            transform.position = newPos;
            index++;
            
        }
        
        
    }

    
}
