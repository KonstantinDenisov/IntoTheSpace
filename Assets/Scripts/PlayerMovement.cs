using System;
using UnityEngine;

[Serializable]
public class PlayerMovement : MonoBehaviour
{
    #region Variables

    private PauseService _pauseService;

    #endregion


    #region Unity LifeCycle

    void Start()
    {
        _pauseService = FindObjectOfType<PauseService>();
    }

    void Update()
    {
        if (_pauseService.IsPaused)
            return;

        else
        {
            Vector3 mousePositionInPixels = Input.mousePosition;
            Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
            Vector3 currentPosition = transform.position;
            currentPosition.x = mousePositionInUnits.x;
            transform.position = currentPosition;
        }
    }

    #endregion
}