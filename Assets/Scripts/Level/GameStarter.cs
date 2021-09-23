using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Text _textRemainingEnergy;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Level _level;
    private int _remainingEnergy = 3;

    public void TryStartGame()
    {
        if(_remainingEnergy > 0)
        {
            _remainingEnergy--;
            _textRemainingEnergy.text = _remainingEnergy.ToString() + " / 3";
            _startPanel.SetActive(false);
            _level.StartLevel();
        }
    }

    public void OnFailStep()
    {
        _startPanel.SetActive(true);
    }
}
