using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Image timerIcon;

    private int totalSeconds = 120;
    private int remainingSeconds;


    public static Action onUpdateSpeedByTime;

    private void Start()
    {
        remainingSeconds = totalSeconds;
        UpdateTimerText();
        StartCountdown();
    }

    private void StartCountdown()
    {
        InvokeRepeating(nameof(UpdateCountdown), 1f, 1f);
    }

    private void UpdateCountdown()
    {
        remainingSeconds--;
        UpdateTimerText();
        if (remainingSeconds % 10 == 0)
        {
            timerIcon.rectTransform.DOScale(Vector3.one * 1.3f, 0.5f).OnComplete(() => timerIcon.rectTransform.DOScale(Vector3.one, 0.5f));
            onUpdateSpeedByTime.Invoke();
        }
        if (remainingSeconds < 30)
        {
            timerText.DOColor(Color.red, 0.5f);
        }


        if (remainingSeconds <= 0)
        {
            GameManager.OnActivateLoseCondition.Invoke();
            CancelInvoke(nameof(UpdateCountdown));
        }
    }

    private void UpdateTimerText()
    {
        int minutes = remainingSeconds / 60;
        int seconds = remainingSeconds % 60;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}