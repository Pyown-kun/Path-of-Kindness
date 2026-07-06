using UnityEngine;

public class MobileUI : MonoBehaviour
{
    [SerializeField]
    private GameObject mobileControls;

    private void Awake()
    {
#if UNITY_ANDROID || UNITY_IOS
        mobileControls.SetActive(true);
#else
        mobileControls.SetActive(false);
#endif
    }
}