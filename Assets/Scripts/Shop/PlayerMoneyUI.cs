using DG.Tweening;
using UnityEngine;

public class PlayerMoneyUI : MonoBehaviour
{
    [SerializeField] private TextController textController;
    [SerializeField] private Transform coinPanel;
    [SerializeField] private Transform coinImage;
    [SerializeField] private ShakeUIConfiguration shakeUIConfiguration;
    private PlayerParameters _playerParameters;
    private Sequence _positionShake;
    private Sequence _coinShake;

    private void Start()
    {
        _playerParameters = ServiceLocator.GetService<PlayerParameters>();
        _playerParameters.moneyUpdated += UpdateMoney;
        UpdateMoney();
        InitializeSequence();
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<PlayerMoneyUI>(this);
        if (_playerParameters == null)
        {
            return;
        }

        _playerParameters.moneyUpdated += UpdateMoney;
    }

    private void InitializeSequence()
    {
        _positionShake = DOTween.Sequence();
        _positionShake.SetLoops(-1);
        _positionShake.Append(coinPanel.DOShakePosition(shakeUIConfiguration.PanelShakeDuration,
            shakeUIConfiguration.PanelShakeStrange));
        _positionShake.Pause();
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<PlayerMoneyUI>();
        _playerParameters.moneyUpdated -= UpdateMoney;
    }

    private void UpdateMoney()
    {
        textController.UpdateText(_playerParameters.CurrentMoney.ToString());
    }

    public void StartShakeShake()
    {
        _positionShake.Play();
    }

    public void PauseShake()
    {
        _positionShake.Restart();
        _positionShake.Pause();
    }

    public void PlayImageShake()
    {
        _coinShake = DOTween.Sequence();
        _coinShake.SetLoops(1);
        _coinShake.Append(coinImage.DOShakeScale(shakeUIConfiguration.ImageShakeDuration,
            shakeUIConfiguration.ImageShakeStrange));
    }
}