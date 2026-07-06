using UnityEngine;

public class NPCSituationController : MonoBehaviour
{
    [SerializeField] private GameObject[] beforeObjects;
    [SerializeField] private GameObject[] afterObjects;

    public bool IsSolved { get; private set; }

    private void Start()
    {
        foreach (GameObject obj in beforeObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        foreach (GameObject obj in afterObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    public void SolveSituation()
    {
        if (IsSolved)
            return;

        IsSolved = true;

        foreach (GameObject obj in beforeObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        foreach (GameObject obj in afterObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        Debug.Log("Situasi NPC berubah.");
    }
}