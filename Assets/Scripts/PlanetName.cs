using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetName : MonoBehaviour
{
    [Header("Planet3DTextSettings")]
    public GameObject planet;
    public TextMeshPro p_name;
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
        planet = transform.parent.gameObject;
        p_name = GetComponent<TextMeshPro>();
        p_name.text = planet.name.Replace("(Clone)", "");
    }

    void Update()
    {     
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,cam.transform.rotation*Vector3.up);
    }
}
