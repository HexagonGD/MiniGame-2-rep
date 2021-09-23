using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "MiniGame/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private List<StepSettings> _stepsSettings;
    [SerializeField] private int _finalReward;

    public int MaxStep => _stepsSettings.Count;
    public int FinalReward => _finalReward;

    public float GetStepSpeed(int step) => _stepsSettings[step].Speed;
    public float GetStepHole(int step) => _stepsSettings[step].Hole;
    public int GetStepReward(int step) => _stepsSettings[step].Reward;

    [System.Serializable]
    private class StepSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hole;
        [SerializeField] private int _reward;

        public float Speed => _speed;
        public float Hole => _hole;
        public int Reward => _reward;
    }
}