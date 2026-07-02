using UnityEngine;

public class PauseInput : MonoBehaviour
{
    private void Update()
    {
        if (PlayerInputHandler.Instance == null)
            return;

        if (PlayerInputHandler.Instance.PausePressed)
        {
            PauseManager.Instance.TogglePause();
        }
    }
}