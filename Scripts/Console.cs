using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour {

    private string InputStr;
    private bool Visibility = false;
    private bool KeyDown = false;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        { 
            Visibility = !Visibility;
            KeyDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (InputStr == "Exit")
            {
                Application.Quit();
            }
        }
    }

    private void OnGUI()
    {
        if (KeyDown)
        {
            if (Visibility)
            {
                InputStr = GUI.TextArea(new Rect(0, 0, Screen.width, 50), InputStr);
                Visibility = true;

            }
        }
    }
}
