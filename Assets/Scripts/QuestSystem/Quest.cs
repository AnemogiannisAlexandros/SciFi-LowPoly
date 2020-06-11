using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quest Object
/// </summary>
[CreateAssetMenu(fileName ="Quest",menuName ="Quest",order =0)]
public class Quest : ScriptableObject
{
    [SerializeField]
    private string questName;
    [SerializeField]
    private string questDescription;
    [SerializeField]
    private QuestRewards questRewards;
}
