using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 50;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("x");
    }
}
