using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject winPanel, gameOverPanel, gamePanel, startPanel;
    public Image f›llAmount;
    public GameObject correctImage, backImage;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void OpenWinPanel()
    {
        winPanel.gameObject.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        DOVirtual.DelayedCall(0.2f,() => {
            FillAmountControl();
        });

    }

    public void OpengameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);

    }
    public void OpengamePanel()
    {
        gamePanel.gameObject.SetActive(true);
        //correctImage.GetComponent<Image>().DOFillAmount(0, 1);
        //backImage.GetComponent<Image>().DOFillAmount(0, 1);

        backImage.GetComponent<CanvasGroup>().DOFade(0, 1).OnComplete(() => { OpenStartPanel(); });
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
        f›llAmount.DOFillAmount(CurrentPlaceManager.instance.CurrentPlaceScoreCalculate(), 1);
        //f›llAmount.fillAmount = Mathf.Lerp(f›llAmount.fillAmount, CurrentPlaceManager.instance.CurrentPlaceScoreCalculate(), Time.deltaTime * 2);

    }
}
