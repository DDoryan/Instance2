using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CameraWindowDice : MonoBehaviour
{
    private RollDice _dice;

    [Header("Window Position")]
    [SerializeField] private float _windowPosXPercentage = 2.5f;
    [SerializeField] private float _windowPosYPercentage = 2.5f;

    [Header("Window Size")]
    [SerializeField] private float _windowWidthPercentage = 20f;
    [SerializeField] private float _windowHeightPercentage = 15f;

    [Header("Window reference")]
    [SerializeField] private Camera _cameraToRender;
    [SerializeField] private GameObject _cameraParent;
    [SerializeField] private bool _showCameraWindow = true;

    private int _screenWidth;
    private int _screenHeight;

    void Start()
    {
        _dice = FindObjectOfType<RollDice>();

        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        UpdateCameraTextureSize();
        _cameraParent.SetActive(_showCameraWindow);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCameraWindow();
        }
    }

    void OnGUI()
    {
        if (_showCameraWindow)
        {
            float windowPosX = _screenWidth * (_windowPosXPercentage / 100f);
            float windowPosY = _screenHeight * (_windowPosYPercentage / 100f);
            float windowWidth = _screenWidth * (_windowWidthPercentage / 100f);
            float windowHeight = _screenHeight * (_windowHeightPercentage / 100f);

            // Create a GUI window that displays the camera rendering
            GUI.DrawTexture(new Rect(windowPosX, windowPosY, windowWidth, windowHeight), _cameraToRender.targetTexture);
        }
    }

    public void ToggleCameraWindow()
    {
        _showCameraWindow = !_showCameraWindow;
        //_dice.SetBoolEnabledText(_showCameraWindow); // set the line, if the rest of the canvas selected (in rolldice) is not a child of the gameObject, which is deactivated
        _cameraParent.SetActive(_showCameraWindow);
    }

    private void UpdateCameraTextureSize()
    {
        int textureWidth = Mathf.RoundToInt(_screenWidth * (_windowWidthPercentage / 100f));
        int textureHeight = Mathf.RoundToInt(_screenHeight * (_windowHeightPercentage / 100f));

        _cameraToRender.targetTexture = new RenderTexture(textureWidth, textureHeight, 32);
        _cameraToRender.targetTexture.filterMode = FilterMode.Bilinear;
        _cameraToRender.targetTexture.Create();
    }
}
