using System;
using UnityEngine;
using UnityEngine.UI;

public enum TypeGame
{
    Classic,
    Training
}

public class Main : MonoBehaviour
{
    public static Main Instance;

    public static Action OnBallReady;
    public static Action OnOpportunityHit;
    public static Action OnHitSuccess;
    public static Action OnReturnSet;
    public static Action OnTimeEnd;
    public static Action OnStopGame;

    public static Action<float> OnChangeValueTime;

    [Header("View")]
    [SerializeField] private GameView _gameView;
    [SerializeField] private ResultView _resultView;

    [Header("Balance Player View")]
    [SerializeField] private Text[] _balanceTexts;

    [Header("Core")]
    [SerializeField] private Timer _timer;
    [SerializeField] private SpawnBalls _spawnBalls;
    [SerializeField] private Transform _posSpawnToBall;
    [SerializeField] private TopResultHandler topResultHandler;

    private ScorePlayer _scorePlayer;
    private BalancePlayer _balancePlayer;

    private TypeGame currentTypeGame;

    private Sprite ballSpriteCurrent;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        Vibration.Init();

        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        _scorePlayer = new ScorePlayer();
        _balancePlayer = new BalancePlayer(_balanceTexts);

        OnHitSuccess += SuccessHit;
        OnChangeValueTime += ChangeTimeValue;
        OnReturnSet += SpawnNextBall;
        OnTimeEnd += TimeEnd;
    }

    public void StartGame(TypeGame typeGame)
    {
        currentTypeGame = typeGame;

        switch (currentTypeGame)
        {
            case TypeGame.Classic:
                _timer.StartTimer(61);
                break;
            case TypeGame.Training:
                break;
        }
        _scorePlayer.ResetScoreValue();
        _gameView.SetScoreView(0);

        _gameView.SetViewToGame(currentTypeGame);

        Main.OnReturnSet?.Invoke();
    }

    private void OnDisable()
    {
        OnChangeValueTime -= ChangeTimeValue;
        OnHitSuccess -= SuccessHit;
        OnReturnSet -= SpawnNextBall;
        OnTimeEnd -= TimeEnd;
    }

    public void ChangeTimeValue(float value)
    {
        _gameView.SetValueTimeView(value);
    }

    public void SuccessHit()
    {
        _scorePlayer.AddScore();
        _gameView.SetScoreView(_scorePlayer.GetValueScore());

        GameSound.OnPlaySound?.Invoke(SName.SuccessHit);
    }

    public void SpawnNextBall()
    {
        Ball ballNew = _spawnBalls.GetBall();
        ballNew.SpawnBall(_posSpawnToBall.position, ballSpriteCurrent);
    }

    private void TimeEnd()
    {
        int scoreResult = _scorePlayer.GetValueScore();
        bool isRecord = topResultHandler.CheckResult(scoreResult);
        int rewardBalance = scoreResult / 5;
        _balancePlayer.AddBalance(rewardBalance);
        _resultView.ShowResult(scoreResult, rewardBalance, isRecord);

        OnStopGame?.Invoke();
    }

    public int GetValueBalance()
    {
        return _balancePlayer.GetBalanceValue();
    }

    public void DissBalance(int value)
    {
        _balancePlayer.DiscreaseBalance(value);
    }

    public void SetChoiceBallSprite(Sprite sprite)
    {
        ballSpriteCurrent = sprite;
    }
}
