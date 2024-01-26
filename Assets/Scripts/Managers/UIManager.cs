using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI HealtText;
    public Button DialogueButton;
}
