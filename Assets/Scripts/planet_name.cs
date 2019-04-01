using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class planet_name : MonoBehaviour
{
    public GameObject planet;
    public TextMeshPro p_name;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        p_name = GetComponent<TextMeshPro>();
       // p_name.transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y+0.5f, planet.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        p_name.text = planet.name;

        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,cam.transform.rotation*Vector3.up);
    }
}
