using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShape
{
    public NoiseFilter[] filter;
    public ShapeSettings settings;

    public PlanetShape(ShapeSettings settings)
    {
        this.settings = settings;
        filter = new NoiseFilter[settings.layers.Length];
        for (int i = 0; i < filter.Length; i++)
            filter[i] = new NoiseFilter(settings.layers[i].options);

    }

    public Vector3 CalculatePoint(Vector3 point)
    {
        float layer1 = 0;
        float elevation = 0;

        if (filter.Length > 0)
        {
            layer1 = filter[0].ShapeNoise(point);
            if (settings.layers[0].enabled)
                elevation = layer1;
        }

        for (int i = 1; i < filter.Length; i++)
        {
            if (settings.layers[i].enabled)
            {
                float mask = (settings.layers[i].layerMask) ? layer1 : 1;
                elevation += filter[i].ShapeNoise(point) * mask;
            }

        }

        return point * settings.radius * (1 + elevation);
    }
}


