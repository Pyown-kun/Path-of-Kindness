using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 0.5f;

    float pitch;

    void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen)
        return;
        
        if (GameManager.Instance.IsGameplayLocked)
        return;

        Vector2 look = PlayerInputHandler.Instance.LookInput;

        pitch -= look.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -80, 80);

        transform.localRotation =
            Quaternion.Euler(pitch, 0, 0);

        player.Rotate(Vector3.up * look.x * sensitivity);
    }
}