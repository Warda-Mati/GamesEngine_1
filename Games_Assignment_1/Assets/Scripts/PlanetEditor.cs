using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MakePlanet))]
public class PlanetEditor : Editor
{

    MakePlanet planet;
    Editor shapeEditor;
    Editor colorEditor;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.CreatePlanet();
            }
        }

        if (GUILayout.Button("Generate Planet"))
        {
            planet.CreatePlanet();
        }

        DrawSettingsEditor(planet.settings, planet.SettingsUpdated, ref planet.foldout, ref shapeEditor);
        DrawSettingsEditor(planet.Coloring, planet.ColorUpdated, ref planet.colorFoldout, ref shapeEditor);
     
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();

                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (MakePlanet) target;
    }
}