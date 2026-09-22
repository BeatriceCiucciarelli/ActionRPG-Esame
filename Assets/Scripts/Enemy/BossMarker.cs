using UnityEngine;

public class BossMarker : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen; // il pannello "HAI VINTO"
    [SerializeField] private bool pauseGameOnVictory = true;

    private void OnDestroy()
    {
        // Se stiamo chiudendo il gioco o cambiando scena, non fare nulla
        if (!Application.isPlaying) return;

        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }

        if (pauseGameOnVictory)
        {
            Time.timeScale = 0f;
        }
    }
}