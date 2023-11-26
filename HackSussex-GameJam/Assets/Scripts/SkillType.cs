using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Scritables/SkillType")]
public class SkillType : ScriptableObject
{
    [SerializeField]
    private GameObject skillPrefab;
    public GameObject SkillPrefab { get; set; }

    
}
