using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_planet_name : MonoBehaviour
{
    public List<Transform> planets;
    TextMeshProUGUI planet_name;

    // Start is called before the first frame update
    void Start()
    {
        planet_name = GetComponent<TextMeshProUGUI>();
        planet_name.text = planets[camera_movement.counter].name;
    }

    // Update is called once per frame
    void Update()
    {
        planet_name.text = planets[camera_movement.counter].name;
    }
}
