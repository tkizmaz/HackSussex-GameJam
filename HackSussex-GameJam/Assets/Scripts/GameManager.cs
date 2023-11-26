using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> skills = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There can be only one Grid Manager");
        }
        else
        {
            instance = this;
        }
    }
}
