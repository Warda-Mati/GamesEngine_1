using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseOptions
{
   public enum Type
   {
      Simple,
      Rigid
   };

   public Type type;
   public float strength;
   [Range(1, 8)] 
   public int layers;
   public float baseRoughness,frequency,amplitude,minValue;
   public Vector3 centre;

}
