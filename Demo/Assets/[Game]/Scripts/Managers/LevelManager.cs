using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    
    public bool IsLevelStarted;
    public Array2D[] Level1; 
    
    public GameObject[] GridPrefabs;
    public GameObject[] LevelPrefabs;
    public float BackGroundHeight;
    public float LevelHeight;
    public int CurrentIndex;
    public Vector3 CurrentDestination;
    public float GridSize;
    public float MoveDuration;
    public bool CanInstantiate;
    public bool CanBlocksMove;
   
    void Start()
    {
        ArraySpawner.Spawn("Grid1" , GridPrefabs , LevelPrefabs, Level1[0] , 1 , Vector3.down * 0.1f ,BackGroundHeight ,LevelHeight , transform);
        GridSize = Level1[0].GridSize.x;
        LevelManager.Instance.IsLevelStarted = true;
        

    }

    private void OnEnable() 
    {
        EventManager.OnLevelStart.AddListener(()=> LevelManager.Instance.IsLevelStarted = true);
    }

    private void OnDisable() 
    {
        EventManager.OnLevelStart.RemoveListener(()=> LevelManager.Instance.IsLevelStarted = true);
    }
    private void LevelStarter()
    {
        EventManager.OnLevelStart.Invoke();
    }

    
   

         
}
