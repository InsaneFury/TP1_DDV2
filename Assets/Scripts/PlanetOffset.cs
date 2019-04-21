using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOffset : MonoBehaviour
{
    [Header("OffsetSettings")]
    public float speed;
    public bool to_right_side;

    void Update()
    {
        if (to_right_side)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, -(speed * Time.deltaTime), 0);
        }

    }
}
