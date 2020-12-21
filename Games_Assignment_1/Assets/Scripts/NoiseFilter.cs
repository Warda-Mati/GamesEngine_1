using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    public NoiseOptions options;
    public Noise noise = new Noise();

    public NoiseFilter(NoiseOptions options)
    {
        this.options = options;
        
    }

    public float ShapeNoise(Vector3 planetPoint)
    {
        float value = 0;
        float frequency = options.baseRoughness;
        float amplitude = 1;
        for (int i = 0; i < options.layers; i++)
        {
            float evaluation = noise.Evaluate(planetPoint * frequency + options.centre);
            value += (evaluation + 1) * .5f * amplitude;
            frequency *= options.frequency;
            amplitude *= options.amplitude;
            
        }
        
        value = Mathf.Max(0, value - options.minValue);
        return value * options.strength;
    }
}
