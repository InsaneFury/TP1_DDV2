using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlanetText : MonoBehaviour
{
    [Header("UI Settings")]
    public List<Transform> planets;
    TextMeshProUGUI planet_name;

    void Start()
    {
        planet_name = GetComponent<TextMeshProUGUI>();
        planet_name.text = planets[CameraMovement.counter].name;
    }

    void Update()
    {
        planet_name.text = planets[CameraMovement.counter].name;
    }
}
