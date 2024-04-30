using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene_", menuName ="Scriptable Objects/Create New Scene")]
public class SceneScriptableObject : ScriptableObject
{
    public string sceneName;
    public Sprite[] sceneSprites;

    public List<int> collisionGridList = new List<int>();

    public int[] nonColisionGrid;
}
