using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtons : MonoBehaviour 
{
        private Vector3 rayDirection;
        private float eulerAngY ;
        private Vector3 initPos;
       
        
        
        private void Start() 
        {
           eulerAngY = transform.localEulerAngles.y;
           initPos  = new Vector3(transform.position.x , LevelManager.Instance.LevelHeight , transform.position.z);
           
           
        }
        void OnMouseDown() 
        {
            if(Input.GetMouseButton(0))
            {
                OnClick();
            }
        }

       
        private void OnClick()
        {   

            GameObject levelPrefab = LevelManager.Instance.LevelPrefabs[LevelManager.Instance.CurrentIndex];

            if(levelPrefab)
            {
                
                LevelManager.Instance.CanBlocksMove =true;

                if(eulerAngY == 0 || eulerAngY == -180 || eulerAngY == 180  )
                {
                    rayDirection = new Vector3(0 , 0 , (Vector3.zero - transform.position).z).normalized;
                    Debug.Log(rayDirection);
                 }

                 else
                {
                    rayDirection = new Vector3((Vector3.zero -transform.position).x , 0 , 0).normalized;
                    Debug.Log(rayDirection);
                }

                RaycastHit hit;
                
                if (Physics.Raycast(transform.position + Vector3.up *LevelManager.Instance.LevelHeight , rayDirection , out hit, Mathf.Infinity))
                {   
                
                    Debug.DrawRay(transform.position + Vector3.up*LevelManager.Instance.LevelHeight, rayDirection*100, Color.red , 10);
                    LevelManager.Instance.CurrentDestination = hit.point - rayDirection * Mathf.CeilToInt(levelPrefab.transform.localScale.x)/2  - rayDirection * 0.05f  ;
                    Debug.Log("if");
                    if(Vector3.Distance(hit.point , transform.position) > levelPrefab.transform.localScale.x +0.5f && LevelManager.Instance.CanInstantiate)
                    {
                        Instantiate(levelPrefab , initPos , Quaternion.Euler(0,eulerAngY + 90F , 0) );
                         EventManager.OnBlocksInstantiate.Invoke();
                     }

                }
                else
                {
                    Debug.Log("else");
                    Debug.DrawRay(transform.position , rayDirection *100 , Color.red , 10);
                    if(Mathf.CeilToInt(levelPrefab.transform.localScale.x ) % 2 == 0 )
                    {
                         LevelManager.Instance.CurrentDestination = transform.position +  rayDirection * (LevelManager.Instance.GridSize - Mathf.CeilToInt(levelPrefab.transform.localScale.x)/2 );
                    }
               
                     else
                    {
                        LevelManager.Instance.CurrentDestination = transform.position +  rayDirection * (LevelManager.Instance.GridSize - Mathf.CeilToInt(levelPrefab.transform.localScale.x)/2 );
                    
                    }
               
                    if(LevelManager.Instance.CanInstantiate)
                    {
                        Instantiate(levelPrefab , initPos , Quaternion.Euler(0,eulerAngY + 90F , 0) );
                        EventManager.OnBlocksInstantiate.Invoke();
                    }
               
                }
                
        }
     }
    
}
