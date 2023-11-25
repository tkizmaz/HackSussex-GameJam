using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Scritables/SkillType")]
public class SkillType : ScriptableObject
{
    [SerializeField]
    private GameObject skillPrefab;
    
    public void SpawnPrefabEffect(Vector3 spawnPosition, bool isFacingRight)
    {
        int direction = isFacingRight ? 1 : -1;
        GameObject skill = Instantiate(skillPrefab, spawnPosition, Quaternion.identity) as GameObject;
        skill.GetComponent<Rigidbody2D>().velocity = (Vector2.right * direction) * 3.5f;
    }

}
