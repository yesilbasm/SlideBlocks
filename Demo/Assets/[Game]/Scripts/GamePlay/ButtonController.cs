using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public int Index;
    public void ChangeIndex()
    {
        LevelManager.Instance.CurrentIndex = Index;
    }

}
