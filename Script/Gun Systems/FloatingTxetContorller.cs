using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTxetContorller : MonoBehaviour
{
    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        if (!popupText)
        {
            popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        }
        
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f,5f), location.position.y + Random.Range(-.5f, 5f)));
        instance.transform.SetParent(canvas.transform, false) ;
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
