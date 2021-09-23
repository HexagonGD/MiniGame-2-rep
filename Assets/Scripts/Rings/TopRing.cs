using UnityEngine;

public class TopRing : Ring
{
    [SerializeField] Transform _secondRing;
    [SerializeField] Animation _animation;

    public float AngleHole => 47f - _secondRing.transform.localRotation.eulerAngles.z;

    public void OnLevelStepComplited()
    {
        _animation.Play("ScaleResize");
    }

    public void OnHoleChanged(float hole)
    {
        _secondRing.localRotation = Quaternion.Euler(Vector3.forward * (47 - hole));
    }

    public void SetRandomRotation()
    {
        _transform.rotation = Quaternion.Euler(Vector3.forward * Random.value * 360f);
    }

    protected override void Rotate()
    {
        _transform.Rotate(_speed * Vector3.forward * Time.deltaTime);
    }
}
