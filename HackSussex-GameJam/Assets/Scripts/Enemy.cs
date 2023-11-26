using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected List<int> vulnerabilities = new List<int>();
    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = 100;
        vulnerabilities.Add(0);
    }

    public virtual void TakeDamage(int tag, int damage)
    {
        foreach(int eachTag in vulnerabilities)
        {
            if(tag == eachTag)
            {
                health -= damage * 2;
            }
            else
            {
                health -= damage;
            }
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(health);
    }


}
