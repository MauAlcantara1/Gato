using UnityEngine;
using UnityEngine.InputSystem;

public class SeguidoCursorUI : MonoBehaviour
{
    public RectTransform canvas; 
    public RectTransform imagen; 
    public Vector2 offset; 


    void Start()
    {
        Cursor.visible = false; 
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mousePos, null, out Vector2 localPoint);

        imagen.localPosition = localPoint + offset;
    }
}
