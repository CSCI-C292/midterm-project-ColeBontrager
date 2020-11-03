using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBarrier : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;

    void Awake()
    {
        ClearLevelData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ClearLevelData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        
    }

    void ClearLevelData()
    {
        _runtimeData.ClocksRemaining = 0;
        _runtimeData.playerMovements = new List<Vector3>();
        _runtimeData.spawnShadows = false;
    }

    void OnApplicationQuit()
    {
        ClearLevelData();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "Player" && _runtimeData.ClocksRemaining == 0)
        {
            
            ClearLevelData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
