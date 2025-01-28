using UnityEngine;

[System.Serializable]
public class Jump
{
    [SerializeField, Range(1f, 20f)] private float _force;

    public float Force
    {
        get => _force;
        set => _force = value;
    }
    
    [SerializeField] private RangeClick _rangeClick;

    public RangeClick RangeClick
    {
        get => _rangeClick;
        set => _rangeClick = value;
    }
}