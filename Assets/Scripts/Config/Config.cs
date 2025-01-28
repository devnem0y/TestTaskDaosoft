using UnityEngine;

//[CreateAssetMenu(fileName = "Config", order = 1)]
[System.Serializable]
public class Config
{
    [SerializeField, Range(0f, 80f)] private float _speed;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    
    [SerializeField] private Jump _jumpLong;
    [SerializeField] private Jump _jumpMedium;
    [SerializeField] private Jump _jumpHigh;

    public Jump JumpLong
    {
        get => _jumpLong;
        set => _jumpLong = value;
    }

    public Jump JumpMedium
    {
        get => _jumpMedium;
        set => _jumpMedium = value;
    }

    public Jump JumpHigh
    {
        get => _jumpHigh;
        set => _jumpHigh = value;
    }
}
