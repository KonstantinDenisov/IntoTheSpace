using System;
using UnityEngine;

public class PauseService : MonoBehaviour
{
    public event Action<bool> OnPaused;

    public bool IsPaused { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseSwitcher();
    }
    
    public void PauseSwitcher()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke(IsPaused);
    }
}