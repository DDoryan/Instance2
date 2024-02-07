using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraWindowDice : MonoBehaviour
{
    public int windowWidth = 320;
    public int windowHeight = 240;

    private Rect windowRect;
    [SerializeField] private Camera cameraToRender;
    private bool showCameraWindow = true;

    void Start()
    {
        //cameraToRender = Camera.main;

        cameraToRender.targetTexture = new RenderTexture(windowWidth, windowHeight, 24);
        cameraToRender.targetTexture.Create();

        // initial position of the window
        windowRect = new Rect(10, 10, windowWidth, windowHeight);
    }

    void OnGUI()
    {
        if (showCameraWindow)
        {
            // Create a GUI window that displays the camera rendering
        }

        //windowRect = GUI.Window(0, windowRect, DrawCameraWindow, "");

        RenderTexture renderTexture = cameraToRender.targetTexture;
        GUI.DrawTexture(new Rect(10, 10, windowWidth, windowHeight), renderTexture, ScaleMode.ScaleToFit, false);

    }

    void DrawCameraWindow(int windowID)
    {
        RenderTexture renderTexture = cameraToRender.targetTexture;

        // Display texture in the GUI window
        GUI.DrawTexture(new Rect(10, 20, windowWidth, windowHeight), renderTexture, ScaleMode.ScaleToFit, false);

        windowRect.width = windowWidth;
        windowRect.height = windowHeight;
    }

    public void ToggleCameraWindow()
    {
        showCameraWindow = !showCameraWindow;
    }
}