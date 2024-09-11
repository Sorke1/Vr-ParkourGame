using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AddBoxColliderToChildren))]
public class AddBoxColliderToChildrenGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AddBoxColliderToChildren script = (AddBoxColliderToChildren)target;
        if (GUILayout.Button("Add To Children"))
            script.AddColliderToChildren();
        if (GUILayout.Button("Remove From Children"))
            script.RemoveCollidersFromChildren();
    }
}