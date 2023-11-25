using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected List<SkillType> vulnerabilities;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = 100;
    }

    protected virtual void TakeDamage(SkillType skillType)
    {
        foreach(SkillType skill in vulnerabilities)
        {
            if(skill == skillType)
            {
                health -= skill.Damage * 2;
            }
            else
            {
                health -= skill.Damage;
            }
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
