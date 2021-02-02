using UnityEngine;

public class ArraySpawner
{
	public static void Spawn(string name,GameObject[] prefabs , GameObject[] LevelPrefabs , Array2D array2D, float margin, Vector3 pos, float backgroundHeight , float levelHeight ,Transform parent) {
        Transform grid = new GameObject(name).transform;
        grid.parent = parent;

        int[,] cells = array2D.GetCells();
        

        float firstPosX = array2D.GridSize.x / 2f;
        float firstPosY = array2D.GridSize.y / 2f;

        GameObject prefab;
        GameObject LevelPrefab;
        Vector3 position = pos;

        
        
        for(int i = 0; i < array2D.GridSize.x+2; i++) {
            for(int j = 0; j < array2D.GridSize.y+2; j++) {
                
               
                if(i == 0)
                    {
                      
                        if(j == array2D.GridSize.y+1 || j== 0 )
                            continue;
                        
                        prefab = prefabs[0];
                        position = new Vector3((i - firstPosX + 0.5f) * margin, backgroundHeight , -(j - firstPosY + 0.5f) * margin);
                        position += pos;
                        if (prefab) 
                        {
                            
                            MonoBehaviour.Instantiate(prefab, position,  Quaternion.Euler(0,270,0), grid);
                            
                        }
                    }

                else if(i == array2D.GridSize.x+1)
                    {
                        if(j == array2D.GridSize.y+1 || j== 0 )
                            continue;

                        prefab = prefabs[0];
                        position = new Vector3((i - firstPosX + 0.5f) * margin, backgroundHeight, -(j - firstPosY + 0.5f) * margin);
                        position += pos;

                        if (prefab) 
                        {
                            
                            MonoBehaviour.Instantiate(prefab, position,  Quaternion.Euler(0,90,0), grid);
                            
                        }
                    }
                else if(j == 0)
                    {
                        
                      if( i == 0)
                        break;
                        prefab = prefabs[0];
                        position = new Vector3((i - firstPosX + 0.5f) * margin, backgroundHeight, -(j - firstPosY + 0.5f) * margin);
                        position += pos;
                        if (prefab) 
                        {
                            
                            MonoBehaviour.Instantiate(prefab, position,  Quaternion.Euler(0,0,0) , grid);
                            
                        }
                    }

                 else if(j == array2D.GridSize.y + 1)
                    {
                        

                        prefab = prefabs[0];
                        position = new Vector3((i - firstPosX + 0.5f) * margin, backgroundHeight, -(j - firstPosY + 0.5f) * margin);
                        position += pos;
                        if (prefab) 
                        {
                            
                            MonoBehaviour.Instantiate(prefab, position,  Quaternion.Euler(0,180,0) , grid);
                            
                        }
                    }

                

                else
                {
                    position = new Vector3((i - firstPosX + 0.45f) * margin, levelHeight , -(j - firstPosY + 0.45f) * margin);
                    position += pos;
                    prefab = prefabs[1];
                    if(j < array2D.GridSize.y + 1 && i<array2D.GridSize.x +1  )
                    {
                        int index = cells[j-1,i-1];
                        LevelPrefab = LevelPrefabs[index];

                       
                       if(LevelPrefab)
                        {
                             
                             position = new Vector3((i - firstPosX + 0.5f - LevelPrefab.transform.localScale.x/2 - 0.05f + margin/2 ) * margin, levelHeight , -(j - firstPosY + 0.5f - LevelPrefab.transform.localScale.z/2 -0.05f +margin/2) * margin);

                                MonoBehaviour.Instantiate(LevelPrefab, position, Quaternion.identity, grid);
                        }
                        
                    }

                    position = new Vector3((i - firstPosX +0.5f) * margin, backgroundHeight , -(j - firstPosY + 0.5f) * margin);
                    position += pos;
                   
                    
                    if (prefab) {
                        MonoBehaviour.Instantiate(prefab, position, Quaternion.Euler(0,0,0), grid);
                    }
                     
                }
            }
        }


        
            

        
	}
}