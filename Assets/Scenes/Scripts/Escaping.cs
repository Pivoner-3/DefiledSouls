using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class ExampleClass : MonoBehaviour
{
   public KeyCode escape = KeyCode.Z;
    void Update()
    {
        if (Input.GetKeyDown(escape))  // если нажата клавиша Esc (Escape)
        {
            Application.Quit();    // закрыть приложение
        }
    }
}