﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lantern : MonoBehaviour
{
    public Light light;
    // Start is called before the first frame update
    void Start()
    {

        light.range = 30;
        light.intensity = 2;
        light.color = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Random.Range(1f, 2f);
        light.range = 15 + light.intensity * 5;
        light.color = Random.Range(0.1f, 0.4f) * Color.yellow + Random.Range(0.3f, 0.6f) * Color.red;
    }
}
