using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class PTopPanel : Widget<Config>
{
    [SerializeField] private GameObject _configGroup;
    [SerializeField] private TMP_Text _lblConfig;
    [SerializeField] private GameObject _lblPause;
    
    [SerializeField] private Slider _sliderSpeed;
    [SerializeField] private TMP_Text _valueSpeed;
    
    [SerializeField] private Slider _sliderForceJumpL;
    [SerializeField] private TMP_Text _valueForceJumpL;
    [SerializeField] private Slider _sliderRangeMinJumpL;
    [SerializeField] private TMP_Text _valueRangeMinJumpL;
    [SerializeField] private Slider _sliderRangeMaxJumpL;
    [SerializeField] private TMP_Text _valueRangeMaxJumpL;
    
    [SerializeField] private Slider _sliderForceJumpM;
    [SerializeField] private TMP_Text _valueForceJumpM;
    [SerializeField] private Slider _sliderRangeMinJumpM;
    [SerializeField] private TMP_Text _valueRangeMinJumpM;
    [SerializeField] private Slider _sliderRangeMaxJumpM;
    [SerializeField] private TMP_Text _valueRangeMaxJumpM;
    
    [SerializeField] private Slider _sliderForceJumpH;
    [SerializeField] private TMP_Text _valueForceJumpH;
    [SerializeField] private Slider _sliderRangeMinJumpH;
    [SerializeField] private TMP_Text _valueRangeMinJumpH;
    [SerializeField] private Slider _sliderRangeMaxJumpH;
    [SerializeField] private TMP_Text _valueRangeMaxJumpH;
    
    public override void Init(Config model)
    {
        base.Init(model);
        
        _lblPause.SetActive(EntryPoint.Instance.IsGamePaused);
        _configGroup.SetActive(EntryPoint.Instance.IsGamePaused);
        _lblConfig.text = EntryPoint.Instance.IsGamePaused ? "Esc - закрыть настройки" : "Esc - открыть настройки";

        EntryPoint.Instance.OnGamePaused += (value) =>
        {
            _lblPause.SetActive(value);
            _configGroup.SetActive(value);
            _lblConfig.text = value ? "Esc - закрыть настройки" : "Esc - открыть настройки";
        };
        
        _sliderSpeed.value = model.Speed;
        _valueSpeed.text = model.Speed.ToString("F1");
        
        _sliderSpeed.onValueChanged.AddListener((value) =>
        {
            model.Speed = value;
            _valueSpeed.text = model.Speed.ToString("F1");
        });
        
        #region JumpLong
        
        _sliderForceJumpL.value = model.JumpLong.Force;
        _valueForceJumpL.text = model.JumpLong.Force.ToString("F1");
        
        _sliderForceJumpL.onValueChanged.AddListener((value) =>
        {
            model.JumpLong.Force = value;
            _valueForceJumpL.text = model.JumpLong.Force.ToString("F1");
        });
        
        _sliderRangeMinJumpL.value = model.JumpLong.RangeClick.Min;
        _valueRangeMinJumpL.text = model.JumpLong.RangeClick.Min.ToString("F1");
        
        _sliderRangeMinJumpL.onValueChanged.AddListener((value) =>
        {
            model.JumpLong.RangeClick = new RangeClick(value, model.JumpLong.RangeClick.Max);
            _valueRangeMinJumpL.text = model.JumpLong.RangeClick.Min.ToString("F1");
        });
        
        _sliderRangeMaxJumpL.value = model.JumpLong.RangeClick.Max;
        _valueRangeMaxJumpL.text = model.JumpLong.RangeClick.Max.ToString("F1");
        
        _sliderRangeMaxJumpL.onValueChanged.AddListener((value) =>
        {
            model.JumpLong.RangeClick = new RangeClick(model.JumpLong.RangeClick.Min, value);
            _valueRangeMaxJumpL.text = model.JumpLong.RangeClick.Max.ToString("F1");
        });
        
        #endregion

        #region JumpMedium
        
        _sliderForceJumpM.value = model.JumpMedium.Force;
        _valueForceJumpM.text = model.JumpMedium.Force.ToString("F1");
        
        _sliderForceJumpM.onValueChanged.AddListener((value) =>
        {
            model.JumpMedium.Force = value;
            _valueForceJumpM.text = model.JumpMedium.Force.ToString("F1");
        });
        
        _sliderRangeMinJumpM.value = model.JumpMedium.RangeClick.Min;
        _valueRangeMinJumpM.text = model.JumpMedium.RangeClick.Min.ToString("F1");
        
        _sliderRangeMinJumpM.onValueChanged.AddListener((value) =>
        {
            model.JumpMedium.RangeClick = new RangeClick(value, model.JumpMedium.RangeClick.Max);
            _valueRangeMinJumpM.text = model.JumpMedium.RangeClick.Min.ToString("F1");
            _valueRangeMinJumpM.color = value < model.JumpLong.RangeClick.Max ? Color.red : Color.white;
            _valueRangeMaxJumpM.color = value > model.JumpMedium.RangeClick.Max ? Color.red : Color.white;
        });
        
        _sliderRangeMaxJumpM.value = model.JumpMedium.RangeClick.Max;
        _valueRangeMaxJumpM.text = model.JumpMedium.RangeClick.Max.ToString("F1");
        
        _sliderRangeMaxJumpM.onValueChanged.AddListener((value) =>
        {
            model.JumpMedium.RangeClick = new RangeClick(model.JumpMedium.RangeClick.Min, value);
            _valueRangeMaxJumpM.text = model.JumpMedium.RangeClick.Max.ToString("F1");
            _valueRangeMaxJumpM.color = value < model.JumpMedium.RangeClick.Min ? Color.red : Color.white;
        });

        #endregion

        #region JumpHigh

        _sliderForceJumpH.value = model.JumpHigh.Force;
        _valueForceJumpH.text = model.JumpHigh.Force.ToString("F1");
        
        _sliderForceJumpH.onValueChanged.AddListener((value) =>
        {
            model.JumpHigh.Force = value;
            _valueForceJumpH.text = model.JumpHigh.Force.ToString("F1");
        });
        
        _sliderRangeMinJumpH.value = model.JumpHigh.RangeClick.Min;
        _valueRangeMinJumpH.text = model.JumpHigh.RangeClick.Min.ToString("F1");
        
        _sliderRangeMinJumpH.onValueChanged.AddListener((value) =>
        {
            model.JumpHigh.RangeClick = new RangeClick(value, model.JumpHigh.RangeClick.Max);
            _valueRangeMinJumpH.text = model.JumpHigh.RangeClick.Min.ToString("F1");
            _valueRangeMinJumpH.color = value < model.JumpMedium.RangeClick.Max ? Color.red : Color.white;
            _valueRangeMaxJumpH.color = value > model.JumpHigh.RangeClick.Max ? Color.red : Color.white;
        });
        
        _sliderRangeMaxJumpH.value = model.JumpHigh.RangeClick.Max;
        _valueRangeMaxJumpH.text = model.JumpHigh.RangeClick.Max.ToString("F1");
        
        _sliderRangeMaxJumpH.onValueChanged.AddListener((value) =>
        {
            model.JumpHigh.RangeClick = new RangeClick(model.JumpHigh.RangeClick.Min, value);
            _valueRangeMaxJumpH.text = model.JumpHigh.RangeClick.Max.ToString("F1");
            _valueRangeMaxJumpH.color = value < model.JumpHigh.RangeClick.Min ? Color.red : Color.white;
        });

        #endregion
    }
}
