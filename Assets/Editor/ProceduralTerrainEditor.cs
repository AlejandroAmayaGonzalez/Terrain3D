using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain))]
public class ProceduralTerrainEditor : Editor {

    SerializedProperty perlinHeight;

    private bool showPerlin;

    private void OnEnable(){
        perlinHeight = serializedObject.FindProperty("perlinHeight");
    }

    public override void OnInspectorGUI(){
        serializedObject.Update();

        ProceduralTerrain myTerrain = (ProceduralTerrain) target;

        if ( GUILayout.Button("Random Terrain")){
            myTerrain.RandomTerrain();
        }

        showPerlin = EditorGUILayout.Foldout(showPerlin, "Perlin Terrain", true);
        if (showPerlin){
            EditorGUILayout.PropertyField(perlinHeight);

            if ( GUILayout.Button("Perlin Terrain")){
                myTerrain.PerlinTerrain();
            }
        }

        if ( GUILayout.Button("Clear Terrain")){
            myTerrain.ClearTerrain();
        }

        serializedObject.ApplyModifiedProperties();
    }

}
