using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StageUI : MonoBehaviour
{
    public static StageUI Instance;

    public ReadyPanel readyPanel;
    public StartPanel startPanel;
    public SuccessPanel successPanel;
    public FailPanel failPanel;

    public Action<BallColor> onSelectColor;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        readyPanel.startStageButton.onClick.AddListener(
            () =>
            {
                StageManager.Instance.StartStage();
            }
        );
        successPanel.nextButton.onClick.AddListener(() => 
        {
            GameManager.Instance.NextStage();
        });

        for (int i = 0; i < startPanel.colorButtons.Count; i++)
        {
            int buttonIndex = i;

            startPanel.colorButtons[i].button.onClick.AddListener(() => {
                OnSelectColor(startPanel.colorButtons[buttonIndex].ballColor);
            });
        }

        OnSelectColor(startPanel.colorButtons[0].ballColor);
    }

    public void OnSelectColor(BallColor color) 
    {
        onSelectColor?.Invoke(color);

        for (int i = 0; i < startPanel.colorButtons.Count; i++)
        {
            startPanel.colorButtons[i].selectionBorder.SetActive(false);
        }

        startPanel.colorButtons.Find(x => x.ballColor == color).selectionBorder.SetActive(true);
    }

    public void ShowPanel(StageState stageState)
    {
        readyPanel.parent.SetActive(false);
        startPanel.parent.SetActive(false);
        successPanel.parent.SetActive(false);
        failPanel.parent.SetActive(false);

        switch (stageState)
        {
            case StageState.READY:
                readyPanel.parent.SetActive(true);
                readyPanel.stageHeaderText.text = "Stage " + (PlayerPrefHelper.CurrentStage+1).ToString();
                break;
            case StageState.START:
                startPanel.parent.SetActive(true);
                break;
            case StageState.SUCCESS:
                successPanel.parent.SetActive(true);
                successPanel.headerText.text = "Stage " + (PlayerPrefHelper.CurrentStage +1).ToString();
                break;
            case StageState.FAIL:
                failPanel.parent.SetActive(true);

                break;
            default:
                break;
        }
    }
}

[System.Serializable]
public class ReadyPanel
{
    public GameObject parent;

    public TextMeshProUGUI stageHeaderText;

    public Button startStageButton;
}

[System.Serializable]
public class StartPanel
{
    public GameObject parent;

    public ProgressSlider stageProgressSlider;

    public List<ColorButton> colorButtons;

    [System.Serializable]
    public class ColorButton 
    {
        public Button button;

        public BallColor ballColor;
        
        public bool hasSelected;

        public GameObject selectionBorder;
    }
}

[System.Serializable]
public class SuccessPanel
{
    public GameObject parent;

    public Button nextButton, rewardedNextButton;

    public TextMeshProUGUI headerText;

    public TextMeshProUGUI infoText;
}

[System.Serializable]
public class FailPanel
{
    public GameObject parent;

    public Button restartButton, rewardedContinueButton;

    public TextMeshProUGUI headerText;

    public TextMeshProUGUI infoText;
}
