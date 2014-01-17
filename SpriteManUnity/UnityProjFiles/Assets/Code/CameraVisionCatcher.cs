using UnityEngine;
using System.Collections;

public class CameraVisionCatcher : MonoBehaviour
{
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        gameObject.transform.localScale = _mainCamera.transform.localScale;
    }

    void Update()
    {
        gameObject.transform.position = _mainCamera.transform.position;
    }

}
