using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class HelperUtilities
{
    public static Camera mainCamera;

    public static Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, 0f, Screen.width);
        mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, 0f, Screen.height);

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        return new Vector3(mouseWorldPosition.x, mouseScreenPosition.y, 0f);
    }
    
    /// null value debug check
    public static bool ValidateCheckNullValue(Object thisObject, string fieldName, Object objectToCheck)
    {
        if (objectToCheck == null)
        {
            Debug.Log(fieldName + "is null and must contain a value in object" + thisObject.name.ToString());
            return true;
        }

        return false;
    }

    /// Empty string debug check
    public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "")
        {
            Debug.Log(fieldName + "is empty and must contain a value in object" + thisObject.name.ToString());
            return true;
        }

        return false;
    }

    /// Convert the linear volume scale to decibels
    public static float LinearToDecibels(int linear)
    {
        float linearScaleRange = 20f;

        // formula to convert from the linear scale to the logarithmic decibel scale
        return Mathf.Log10((float)linear / linearScaleRange) * 20f;
    }

    public static bool ValidateCheckPositiveRange(Object thisObject, string fieldNameMin, float valueToCheckMin, string fieldNameMax, float valueToCheckMax)
    {
        if (valueToCheckMin > valueToCheckMax)
        {
            Debug.Log(fieldNameMin + " must bee less than or equal to " + fieldNameMax + " in object " +
                      thisObject.name.ToString());
            return true;
        }

        return false;
    }
}