using UnityEngine;

public class NPCIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicator;

    private NPCInteraction npc;

    private void Awake()
    {
        npc = GetComponent<NPCInteraction>();
    }

    private void Update()
    {
        indicator.SetActive(
            npc.IsPlayerNearby &&
            !npc.HasInteracted);
    }
}