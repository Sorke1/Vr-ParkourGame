using Codice.Client.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace Assets._3DUI_SS24.VRParkourGame.Scripts
{
    public class MyDynamicMoveProvider : ActionBasedContinuousMoveProvider
    {
        /// <inheritdoc />
        protected override Vector3 ComputeDesiredMove(Vector2 input)
        {
            Transform m_HeadTransform;

            if (input == Vector2.zero)
                return Vector3.zero;

            var xrOrigin = system.xrOrigin;
            if (xrOrigin != null)
            {
                var xrCamera = xrOrigin.Camera;
                if (xrCamera != null)
                {
                    m_HeadTransform = xrCamera.transform;
                    var leftHandValue = leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
                    Debug.Log("leftHandValue " + leftHandValue);
                    if (leftHandValue.y > 0.8) { 
                    Vector3 NewLoc = m_HeadTransform.position + (m_HeadTransform.forward * leftHandValue.y * 1.0f * UnityEngine.Time.deltaTime) ;
                    Debug.Log("m_HeadTransform.position " + m_HeadTransform.position);
                    Debug.Log("(m_HeadTransform.forward " + m_HeadTransform.forward);
                    Debug.Log("NewLoc " + NewLoc);
                    return NewLoc;
                    }
                }
               
            }
            return Vector3.zero;
        }
    }
}