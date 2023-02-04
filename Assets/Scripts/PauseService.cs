using System;
using UnityEngine;

public class PauseService : MonoBehaviour
{
    #region Events

    public event Action<bool> OnPaused;

    #endregion


    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseSwitcher();
    }

    #endregion


    #region Private Methods

    private void PauseSwitcher()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke(IsPaused);
    }

    #endregion
}