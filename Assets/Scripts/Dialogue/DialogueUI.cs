using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Situation")]
    [SerializeField] private TMP_Text situationText;

    [Header("Buttons")]
    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonB;
    [SerializeField] private Button buttonC;

    [Header("Button Text")]
    [SerializeField] private TMP_Text buttonAText;
    [SerializeField] private TMP_Text buttonBText;
    [SerializeField] private TMP_Text buttonCText;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void Show(DialogueData data)
    {

        
        panel.SetActive(true);

        situationText.text = data.situation;

        buttonAText.text = data.optionA.optionText;
        buttonBText.text = data.optionB.optionText;
        buttonCText.text = data.optionC.optionText;

        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonC.onClick.RemoveAllListeners();

        buttonA.onClick.AddListener(() =>
        {
            DialogueManager.Instance.SelectChoice(0);
        });

        buttonB.onClick.AddListener(() =>
        {
            DialogueManager.Instance.SelectChoice(1);
        });

        buttonC.onClick.AddListener(() =>
        {
            DialogueManager.Instance.SelectChoice(2);
        });
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}