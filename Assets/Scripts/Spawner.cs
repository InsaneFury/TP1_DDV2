﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Object[] planets;
    //public float space;
    // Start is called before the first frame update
    void Start()
    {
       // space = 1f;
        planets = Resources.LoadAll("prefab/planets",typeof(Object));
        foreach(GameObject go in planets)
        {
            Debug.Log(go.name);
            Instantiate(go, go.transform.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}