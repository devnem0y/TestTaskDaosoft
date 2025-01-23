using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private int _count = 1;
    
    private Vector2 _positionLastPlatform;
    private float _widthLastPlatform;

    private void Start()
    {
        for (var i = 0; i < 200; i++) Create();
    }

    private void Create()
    {
        var platform = Instantiate(_platform, transform);
        platform.transform.localScale = new Vector2(Random.Range(2f, 4.5f), platform.transform.localScale.y);
        var posY = _count % 2 != 0 ? Random.Range(0, _minY) : Random.Range(0, _maxY);
        platform.transform.localPosition = new Vector2(_positionLastPlatform.x + _widthLastPlatform * 6.2f, posY);
        _positionLastPlatform = platform.transform.localPosition;
        _widthLastPlatform = platform.GetComponent<BoxCollider2D>().size.x;
        _count++;
    }
}
