using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField] private LevelSettings _settings;
    [SerializeField] private Text _rewardText;
    [SerializeField] private Text _finalRewardText;
    private int _countCompleteStep = 0;

    public void OnStepComplete()
    {
        _rewardText.text = _settings.GetStepReward(++_countCompleteStep).ToString();
    }

    public void OnStepFail()
    {
        _countCompleteStep = 0;
        _finalRewardText.text = "Вы получили " + _rewardText.text;
        _rewardText.text = "0";
    }

    public void OnGameCompleted()
    {
        _countCompleteStep = 0;
        _finalRewardText.text = "Вы получили " + _settings.FinalReward;
        _rewardText.text = "0";
    }
}
