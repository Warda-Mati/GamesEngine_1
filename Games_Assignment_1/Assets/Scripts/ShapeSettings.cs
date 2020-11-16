﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    public float radius;
    public NoiseLayer[] layers;
    
    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool layerMask;    
        public NoiseOptions options;
    }
}
