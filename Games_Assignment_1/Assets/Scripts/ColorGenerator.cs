using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
   private PlanetColoring Coloring;

   public ColorGenerator(PlanetColoring planetColoring)
   {
      this.Coloring = planetColoring;
   }

   public void UpdateElevation(PlanetHeights elevation)
   {
      Coloring.Material.SetVector("PlanetCol",new Vector4(elevation.min,elevation.max));
   }
}
