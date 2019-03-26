using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_offset : MonoBehaviour
{
    public float speed;
    public bool to_right_side;

    // Update is called once per frame
    void Update()
    {
        if (to_right_side) {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else {
            transform.Rotate(0, -(speed * Time.deltaTime), 0);
        }
        
    }
}
