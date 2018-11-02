using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordCombine
{
    public string word;
    public string[] combineFromWords;
}
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public WordCombine[] wordCombines;
}
