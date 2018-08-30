using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Map_Generator))]
public class Map_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Map_Generator map = target as Map_Generator;

        map.GenerateMap();
    }

}