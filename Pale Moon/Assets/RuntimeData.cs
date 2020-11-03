using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New RuntimeData")]
public class RuntimeData : ScriptableObject
{
    public int ClocksRemaining = 0;
    public List<Vector3> playerMovements = new List<Vector3>();
    

    public bool spawnShadows = false;

    
}