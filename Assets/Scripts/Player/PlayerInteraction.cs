using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;

    [Header("Interaction")]
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private float sphereRadius = 0.3f;

    [Header("Layer")]
    [SerializeField] private LayerMask npcLayer;

    private NPCInteraction currentNPC;
    private NPCInteraction previousNPC;

    private void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen)
        return;

        if (GameManager.Instance.IsGameplayLocked)
        return;

        DetectNPC();

        if (currentNPC != null &&
            PlayerInputHandler.Instance.InteractPressed)
        {
            currentNPC.Interact();
        }
    }

    private void DetectNPC()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward);

        NPCInteraction detectedNPC = null;

        if (Physics.SphereCast(
            ray,
            sphereRadius,
            out RaycastHit hit,
            interactDistance,
            npcLayer))
        {
            detectedNPC = hit.collider.GetComponent<NPCInteraction>();
        }

        // Tidak ada perubahan target
        if (detectedNPC == currentNPC)
            return;

        // Matikan indikator NPC sebelumnya
        if (currentNPC != null)
        {
            currentNPC.IsPlayerNearby = false;
        }

        previousNPC = currentNPC;
        currentNPC = detectedNPC;

        // Hidupkan indikator NPC baru
        if (currentNPC != null)
        {
            currentNPC.IsPlayerNearby = true;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (playerCamera == null)
            return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            playerCamera.transform.position +
            playerCamera.transform.forward * interactDistance,
            sphereRadius);
    }
#endif
}