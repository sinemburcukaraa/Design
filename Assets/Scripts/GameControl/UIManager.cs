using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject winPanel, gameOverPanel, gamePanel, startPanel;
    public Image f›llAmount;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void OpenWinPanel()
    {
        winPanel.gameObject.SetActive(true);
        FillAmountControl();
    }
    public void OpengameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);

    }
    public void OpengamePanel()
    {
        gamePanel.gameObject.SetActive(true);
    }

    public void OpenStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void FillAmountControl()
    {
        f›llAmount.fillAmount = Mathf.Lerp(f›llAmount.fillAmount,CurrentPlaceManager.instance.CurrentPlaceScoreCalculate(), Time.deltaTime * 2);

    }
}
