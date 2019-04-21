using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Header("PlanetSettings")]
    public GameObject sun;
    public float ratio;
    public float speed;

    float actual_position;
    float rotation_x, rotation_z;

    void Start()
    {
        sun = GameObject.FindGameObjectWithTag("sun");
    }

    void Update()
    {
        actual_position += Time.deltaTime * speed;

        rotation_x = sun.transform.position.x + ratio * Mathf.Cos(actual_position);
        rotation_z = sun.transform.position.z + ratio * Mathf.Sin(actual_position);

        transform.position = new Vector3(rotation_x,transform.position.y , rotation_z);
    }
}
