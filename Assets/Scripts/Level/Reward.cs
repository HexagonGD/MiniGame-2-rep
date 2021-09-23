using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField] private List<int> _rewardList;
    [SerializeField] private Text _rewardText;
    [SerializeField] private Text _finalRewardText;
    private int _countCompleteStep = 0;

    public void OnStepComplete()
    {
        _rewardText.text = _rewardList[++_countCompleteStep].ToString();
    }

    public void OnStepFail()
    {
        _countCompleteStep = 0;
        _finalRewardText.text = "Вы получили " + _rewardText.text;
        _rewardText.text = "0";
        
    }
}
