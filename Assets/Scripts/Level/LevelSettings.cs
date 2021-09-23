using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "MiniGame/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private List<float> _speedGraphic;
    [SerializeField] private List<float> _holeGraphic;
    [SerializeField] private int _maxStep;

    public int MaxStep => _maxStep;
    public float GetStepSpeed(int step) => _speedGraphic[step];
    public float GetStepHole(int step) => _holeGraphic[step];
}