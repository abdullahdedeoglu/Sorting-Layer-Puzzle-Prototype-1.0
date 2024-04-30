using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Layer_", menuName = "Scriptable Objects/Create New Layer")]
public class LayerScriptableObject : ScriptableObject
{
    public string layerName;
    public int orderIndex;
    public string importantItemName;
}
