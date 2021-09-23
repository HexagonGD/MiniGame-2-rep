using UnityEngine;

public class Ring : MonoBehaviour
{
    protected Transform _transform;

    protected float _speed;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Rotate();
    }

    public void OnSpeedChanged(float speed)
    {
        _speed = speed;
    }

    protected virtual void Rotate()
    {
        _transform.Rotate(_speed * -Vector3.forward * Time.deltaTime);
    }
}
