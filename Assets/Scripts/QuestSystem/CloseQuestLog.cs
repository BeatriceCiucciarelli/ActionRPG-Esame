using UnityEngine;

public class CloseQuestLog : MonoBehaviour
{
    [SerializeField] private CanvasGroup questCanvas;

    public void Close()
    {
        questCanvas.alpha = 0f;
        questCanvas.interactable = false;
        questCanvas.blocksRaycasts = false;
    }
}