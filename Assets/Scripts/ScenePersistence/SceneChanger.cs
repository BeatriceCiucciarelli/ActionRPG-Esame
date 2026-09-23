using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;

    public void ChangeSceneNow()
    {
        Time.timeScale = 1f;   // rimette il gioco in moto

        // Distrugge gli oggetti persistenti, così la nuova partita riparte pulita
        if (GameManager.Instance != null)
            Destroy(GameManager.Instance.gameObject);

        if (InventoryManager.Instance != null)
            Destroy(InventoryManager.Instance.gameObject);

        SceneManager.LoadScene(sceneToLoad);
    }
}