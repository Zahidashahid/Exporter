using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardManager : MonoBehaviour
{
    // Reference to the text input field
    public InputField textField;

    void Update()
    {
        // Check if the user touches the screen (for mobile) or clicks the mouse (for PC)
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Check if the touch or click hits the text input field
            if (textField != null && IsPointerOverUIObject())
            {
                // If the application is running on Android, show the touch screen keyboard
                if (Application.platform == RuntimePlatform.Android)
                {
                    print("for mobile screen");
                    TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                }
            }
        }
    }

    // Function to check if the touch or click hits any UI object
    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
