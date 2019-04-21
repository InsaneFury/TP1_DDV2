using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Object[] planets;

    void Start()
    {
        planets = Resources.LoadAll("prefab/planets",typeof(Object));
        foreach(GameObject go in planets)
        {
            CameraMovement.targets.Add((GameObject)Instantiate(go, go.transform.position, Quaternion.identity));
        }

    }
}
