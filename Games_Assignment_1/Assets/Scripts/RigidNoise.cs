using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidNoise
{
    public NoiseOptions options;
    public Noise noise = new Noise();

    public RigidNoise(NoiseOptions options)
    {
        this.options = options;
        
    }

    public float ShapeNoise(Vector3 planetPoint)
    {
        float value = 0;
        float frequency = options.baseRoughness;
        float amplitude = 1;
        float weight = 1;
        for (int i = 0; i < options.layers; i++)
        {
            float evaluation = 1- Mathf.Abs(noise.Evaluate(planetPoint * frequency + options.centre));
            evaluation *= evaluation;
            evaluation *= weight;
            weight = evaluation;
            value += (evaluation * amplitude);
            frequency *= options.frequency;
            amplitude *= options.amplitude;
            
        }
        
        value = Mathf.Max(0, value - options.minValue);
        return value * options.strength;
    }
}