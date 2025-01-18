using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject _part1;
    [SerializeField] private GameObject _part2;
    
    private Camera _camera;
    
    private GameObject _groundPrv;
    private GameObject _groundNex;

    private void Awake()
    {
        _camera = Camera.main;

        _groundPrv = _part1;
        _groundNex = _part2;
    }

    private void Update()
    {
        if (_camera == null) return;
        if (!(Math.Abs(_camera.transform.position.x - _groundNex.transform.position.x) < 0.01f)) return;
            
        var gSizeW = _groundNex.GetComponent<BoxCollider2D>().bounds.size.x;
        _groundPrv.transform.position = new Vector2(_groundNex.transform.position.x + gSizeW , _groundPrv.transform.position.y);
        (_groundPrv, _groundNex) = (_groundNex, _groundPrv);
    }
}
