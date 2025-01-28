using UnityEngine;

[System.Serializable]
public struct RangeClick
{
    [SerializeField, Range(0f, 10f)] private float _min;
    [SerializeField, Range(0f, 10f)] private float _max;
    
    public float Min => _min;
    public float Max => _max;

    public RangeClick(float min, float max)
    {
        _min = min;
        _max = max;
    }
}