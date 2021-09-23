using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelSettings _settings;

    [SerializeField] private float _delay = 1f;
    private int _step = 0;
    private bool _isGame = true;

    [SerializeField] private UnityEvent LevelStepCompleted;
    [SerializeField] private UnityEvent LevelFailed;
    [SerializeField] private UnityEvent GameCompleted;

    private event Action<float> SpeedChanged;
    private event Action<float> HoleChanged;

    public void Awake()
    {
        TopRing topRing = GameObject.Find("TopRing").GetComponent<TopRing>();
        Ring botRing = GameObject.Find("BotRing").GetComponent<Ring>();
        HoleChanged += topRing.OnHoleChanged;
        SpeedChanged += topRing.OnSpeedChanged;
        SpeedChanged += botRing.OnSpeedChanged;
    }

    public void StartLevel()
    {
        _step = 0;
        _isGame = true;
        RefreshSpeedAndHole();
    }

    private void RefreshSpeedAndHole()
    {
        SpeedChanged?.Invoke(_settings.GetStepSpeed(_step));
        HoleChanged?.Invoke(_settings.GetStepHole(_step));
    }

    public void OnSuccessHit()
    {
        if(_isGame)
        {
            StartCoroutine(LevelStepComplete());
        }
    }

    public void OnFailHit()
    {
        if (_isGame)
        {
            StartCoroutine(LevelStepFail());
        }
    }

    private IEnumerator LevelStepComplete()
    {
        if(++_step >= _settings.MaxStep)
        {
            GameCompleted?.Invoke();
            yield break;
        }

        LevelStepCompleted?.Invoke();
        _isGame = false;

        yield return new WaitForSeconds(_delay / 2f);
        RefreshSpeedAndHole();

        yield return new WaitForSeconds(_delay / 2f);
        _isGame = true;
    }

    private IEnumerator LevelStepFail()
    {
        _isGame = false;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(_delay);
        _isGame = true;
        Time.timeScale = 1;
        LevelFailed?.Invoke();
    }
}