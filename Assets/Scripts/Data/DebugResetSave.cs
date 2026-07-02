using UnityEngine;

public class DebugResetSave : MonoBehaviour
{
    [ContextMenu("Reset Save")]
    private void ResetSave()
    {
        SaveManager.ResetProgress();
    }
}