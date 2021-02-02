using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMovement : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.OnBlocksInstantiate.AddListener(()=> StartCoroutine(InstantiateTimer()));    
    }

    private void OnDisable() 
    {
        EventManager.OnBlocksInstantiate.RemoveListener(()=> StartCoroutine(InstantiateTimer()));
    }
    private void Start() 
    {  
         if(LevelManager.Instance.CanBlocksMove)
        {
            transform.DOMoveX(LevelManager.Instance.CurrentDestination.x , LevelManager.Instance.MoveDuration);
            transform.DOMoveZ(LevelManager.Instance.CurrentDestination.z , LevelManager.Instance.MoveDuration);
        }
    }

    IEnumerator InstantiateTimer()
    {   
        LevelManager.Instance.CanInstantiate = false;
        yield return new WaitForSeconds(LevelManager.Instance.MoveDuration);
        LevelManager.Instance.CanInstantiate=true;
        
        
        
    }

   
}
