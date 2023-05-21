using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanelController : MonoBehaviour
{
    [SerializeField] GameObject deadPanel, radialMenu, barsPanel, debugPanel;
    [SerializeField] Button restartButton;
    void Start()
    {
        restartButton.onClick.AddListener(() => restartGame());
        deadPanel.SetActive(false);
    }

    void Update()
    {
        if (Survivor.instance.GetComponent<Health>().value <= 0)
        {
            radialMenu.SetActive(false);
            barsPanel.SetActive(false);
            debugPanel.SetActive(false);
            deadPanel.SetActive(true);
        }        
    }

    void restartGame()
    {
        SceneManager.LoadScene("snowyMountains");
    }
}
