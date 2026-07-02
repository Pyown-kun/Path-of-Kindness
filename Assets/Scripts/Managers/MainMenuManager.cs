using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;

    [SerializeField] private GameObject levelSelectPanel;

    [SerializeField] private GameObject settingPanel;

    [SerializeField] private GameObject creditPanel;

    private void Start()
    {
        GameManager.Instance.SetGameplayCursor(false);
        
        ShowMainPanel();
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);

        levelSelectPanel.SetActive(false);

        settingPanel.SetActive(false);

        creditPanel.SetActive(false);
    }

    public void ShowLevelSelect()
    {
        mainPanel.SetActive(false);

        levelSelectPanel.SetActive(true);

        settingPanel.SetActive(false);

        creditPanel.SetActive(false);
    }

    public void ShowSetting()
    {
        mainPanel.SetActive(false);

        levelSelectPanel.SetActive(false);

        settingPanel.SetActive(true);

        creditPanel.SetActive(false);
    }

    public void ShowCredit()
    {
        mainPanel.SetActive(false);

        levelSelectPanel.SetActive(false);

        settingPanel.SetActive(false);

        creditPanel.SetActive(true);
    }
}