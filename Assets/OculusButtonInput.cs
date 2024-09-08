using UnityEngine;

public class OculusButtonInput : MonoBehaviour
{
    void Update()
    {
        // Check if A button is pressed on Oculus controller (Right hand)
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("A button pressed!");
        }

        // Check if B button is pressed on Oculus controller (Right hand)
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Debug.Log("B button pressed!");
        }

        // Check if the trigger is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Right trigger pressed!");
        }

        // Check if the left thumbstick is pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch))
        {
            Debug.Log("Left thumbstick pressed!");
        }
    }
}