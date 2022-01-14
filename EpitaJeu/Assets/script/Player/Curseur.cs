using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curseur : MonoBehaviour
{
    public static void Change (Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware) ;

    }
}
