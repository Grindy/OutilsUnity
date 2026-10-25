using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Net;

[CustomEditor(typeof(Oscillator))]
public class OscillatorEditor : Editor //hérite de la classe Editor
{
public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty property = serializedObject.GetIterator();
        bool enterChildren = true;

        while (property.NextVisible(enterChildren))
        {
            enterChildren = false;

            if (property.name == "m_Script")
                continue;

            if (property.name == "ease" ||
                property.name == "easeMultiplier")
            {
                SerializedProperty useEase =
                    serializedObject.FindProperty("useEase");

                EditorGUI.BeginDisabledGroup(!useEase.boolValue);
                EditorGUILayout.PropertyField(property, true);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUILayout.PropertyField(property, true);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }


    SerializedProperty useEase;
    SerializedProperty ease;

    private void OnEnable() // onEnable() est appelé lorsque l'éditeur personnalisé est activé, permet de récupérer les ref aux champs
    {
        useEase = serializedObject.FindProperty("useEase");
        ease = serializedObject.FindProperty("ease");
    }

}