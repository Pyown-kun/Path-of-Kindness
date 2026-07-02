using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen)
        return;

        if (GameManager.Instance.IsGameplayLocked)
        return;

        Vector2 input = PlayerInputHandler.Instance.MoveInput;

        float speed = PlayerInputHandler.Instance.SprintPressed
            ? sprintSpeed
            : walkSpeed;

        Vector3 move =
            transform.forward * input.y +
            transform.right * input.x;

        controller.Move(move * speed * Time.deltaTime);
    }
}