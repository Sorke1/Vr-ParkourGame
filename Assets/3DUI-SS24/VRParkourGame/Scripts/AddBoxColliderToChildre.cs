using UnityEngine;

public class AddBoxColliderToChildren : MonoBehaviour
{
    public GameObject parent;
    public bool DontAddIfAlreadyPresent = true;
    private int addedColliders = 0;
    private int removedColliders = 0;

    public void AddColliderToChildren()
    {
        if (parent == null)
            throw new System.Exception("No Parent Assigned");
        AddToAll(parent.transform);
    }
    private void AddToAll(Transform parent)
    {
        addedColliders = 0;
        foreach (Transform child in parent)
            AddBoxCollider(child);
        Debug.Log("Total Colliders Added: " + addedColliders);
    }
    private void AddBoxCollider(Transform transform)
    {
        var gameobject = transform.gameObject;
        var collider = gameobject.GetComponent<BoxCollider>();
        var shouldAdd = collider == null || (collider != null && !DontAddIfAlreadyPresent);
        if (shouldAdd)
        {
            gameobject.AddComponent<BoxCollider>();
            addedColliders++;
            Debug.Log("Collider is added to:  " + gameobject);
        }
    }
    public void RemoveCollidersFromChildren()
    {
        if (parent == null)
            throw new System.Exception("No Parent Assigned");
        RemoveToAll(parent.transform);
    }
    public void RemoveToAll(Transform parent)
    {
        removedColliders = 0;
        foreach (Transform child in parent.transform)
            RemoveCollider(child);
        Debug.Log("Total Collider Removed: " + removedColliders);
    }
    private void RemoveCollider(Transform transform)
    {
        var gameobject = transform.gameObject;
        var collider = gameobject.GetComponent<Collider>();
        if (collider != null)
        {
            DestroyImmediate(collider);
            removedColliders++;
            Debug.Log("Collider is removed from " + gameobject);
        }
    }
}