// Nicholas Wile
// Dr. Sungchul Jung
// Created March 2, 2023
// Last Edited: March 2, 2023

///<summary>
/// Displays the frame rate of the application. Used for testing, debugging, and profiling on HMD devices. 
/// </summary>

using UnityEngine;

public class FrameCounter : MonoBehaviour
{
    private int frameRate;

    // Update is called once per frame
    void Update()
    {
        frameRate = (int)(1 / Time.unscaledDeltaTime);
    }

    private void OnGUI()
    {

        GUI.Box(new Rect(Screen.width - 135, 10, 125, 60), "Frame Rate");
        

        GUI.Label(new Rect(Screen.width - 135+25, 40, 100, 50), frameRate + " fps");

    }
}
