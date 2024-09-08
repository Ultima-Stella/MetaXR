using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class Marker : MonoBehaviour
{
    bool inPlane = false;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Locals"))
        {
            Unit newSelectedUnit = other.GetComponent<Unit>();
            GameManager.Instance.AddToSelection(newSelectedUnit);
            newSelectedUnit.SetSelected(true);

        }

        if (other.gameObject.CompareTag("Plane"))
        {
            inPlane = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.CompareTag("Plane"))
        {
            inPlane = false;
        }

    }
    private void Update()
    {

        // Check if the trigger is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            GameManager.Instance.ClearSelection();
        }
        // Check if the trigger is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            GameManager.Instance.ClearSelection();
        }
        // Check if A button is pressed on Oculus controller (Right hand)
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            UnityEngine.Vector3 localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);

            // Convert to world position by applying the camera rig's world transform
            UnityEngine.Vector3 worldPosition = OVRManager.instance.transform.TransformPoint(localPosition);
            if (inPlane)
            {
                GameManager.Instance.SentSelectedUnitsTo(worldPosition);
            }
        }

        // Check if B button is pressed on Oculus controller (Right hand)
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            UnityEngine.Vector3 localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

            // Convert to world position by applying the camera rig's world transform
            UnityEngine.Vector3 worldPosition = OVRManager.instance.transform.TransformPoint(localPosition);
            if (inPlane)
            {
                GameManager.Instance.SentSelectedUnitsTo(worldPosition);

            }
        }

    }
}
