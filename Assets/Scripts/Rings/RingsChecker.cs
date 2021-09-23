using UnityEngine;
using UnityEngine.Events;

public class RingsChecker : MonoBehaviour
{
    [SerializeField] private TopRing _topRing;
    [SerializeField] private Transform _botRing;

    public UnityEvent SuccessHit;
    public UnityEvent FailHit;

    public void PlayerClick()
    {
        var angle = (_topRing.transform.rotation.eulerAngles.z - _botRing.rotation.eulerAngles.z + 360) % 360;
        angle = Mathf.Min(angle, 360 - angle);
        Debug.Log(angle);
        Debug.Log(_topRing.AngleHole);
        if (_topRing.AngleHole / 2f > angle) Debug.Log("Success");

        if (_topRing.AngleHole / 2f > angle)
            SuccessHit.Invoke();
        else
            FailHit.Invoke();
    }
}
