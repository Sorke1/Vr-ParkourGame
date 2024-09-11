using UnityEngine;

namespace Assets._3DUI_SS24.Starters.gameplay
{
    public class RotateToTarget : MonoBehaviour
    {
        public Transform target;
        void Update()
        {
            if (target != null)
            {
                this.gameObject.transform.LookAt(target);
            }
        }
    }
}