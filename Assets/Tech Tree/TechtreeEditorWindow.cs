using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Aoiti.Techs
{
    public class TechtreeWindow : EditorWindow
    {
        private Techtree targetTree;
        private string selectedTechDefinition = "";

        [MenuItem("Window/Techtree Editor")]
        public static void ShowWindow()
        {
            GetWindow<TechtreeWindow>("Techtree Editor");
        }

        private void OnGUI()
        {
            if (Selection.activeObject is Techtree)
            {
                targetTree = (Techtree)Selection.activeObject;
                DrawTechtree();
            }
            else
            {
                EditorGUILayout.LabelField("Select a Techtree asset in the Project window to edit.");
            }
        }

        private void DrawTechtree()
        {
            EditorGUILayout.LabelField("Tech Definition:");
            EditorGUILayout.TextArea(selectedTechDefinition, GUILayout.Height(50));
            foreach (var node in targetTree.tree)
            {
                EditorGUILayout.BeginHorizontal();

                // Draw your node representation here
                EditorGUILayout.LabelField(node.tech.name);

                // Add a button to research the tech
                GUI.enabled = !node.researched;
                if (GUILayout.Button("Research"))
                {
                    selectedTechDefinition = node.tech.definition;
                    node.researched = true;
                }
                GUI.enabled = true;

                EditorGUILayout.EndHorizontal();
            }

            
        }
    }
}
