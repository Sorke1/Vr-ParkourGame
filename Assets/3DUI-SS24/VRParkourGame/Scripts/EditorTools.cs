using UnityEditor;
using UnityEngine;

namespace Assets._3DUI_SS24.Starters.Gameplay
{

    // [CustomEditor(typeof(Transform))]
    // public class ResetTransformEditor : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         DrawDefaultInspector();

    //         Transform transform = (Transform)target;
    //         if (GUILayout.Button("Reset Position"))
    //         {
    //             Undo.RecordObject(transform, "Reset Position");
    //             transform.position = Vector3.zero;
    //             EditorUtility.SetDirty(transform);
    //         }
    //     }
    // }

    //[CustomEditor(typeof(Transform))]
    //public class CollapseAllComponents : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        DrawDefaultInspector();
    //        if (GUILayout.Button("Collapse All"))
    //        {

    //            foreach (var obj in Selection.gameObjects)
    //            {
    //                var editor = Editor.CreateEditor(obj);
    //                var serializedObject = editor.serializedObject;
    //                var iterator = serializedObject.GetIterator();

    //                while (iterator.NextVisible(true))
    //                {
    //                    iterator.isExpanded = false;
    //                }

    //                serializedObject.ApplyModifiedProperties();
    //            }
    //        }
    //    }
    //}
}