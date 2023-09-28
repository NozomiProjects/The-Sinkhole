using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create New Item")]
[System.Serializable]

public class items : ScriptableObject
{
    
    public int id;

    public string itemName;

    

    public GameObject prefab;
    public Texture icon;
    public int maxStack;
   


}
