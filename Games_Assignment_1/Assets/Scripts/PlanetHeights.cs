using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHeights
{
    public float min { get; private set; }
    public float max { get; private set; }

    public PlanetHeights()
    {
        min = float.MaxValue;
        max = float.MinValue;
    }

    public void Add(float value)
    {
        if (value > max)
        {
            max = value;
        }
        if (value < min)
        {
            min = value;
        }
        
    }
}
