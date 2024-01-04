using Microsoft.AspNetCore.SignalR;
using ProjectRPS.Hubs;

namespace ProjectRPS.Core;

public interface IGameLoop
{
    void Start();
    void Stop();
}

public class GameLoop : IGameLoop
{
    private bool _isRunning;
    private const int _tickRate = 30;
    private readonly TimeSpan _tickInterval;
    private readonly ILogger<GameLoop> _logger;
    private readonly IHubContext<MainHub> _mainHub;

    public GameLoop(ILogger<GameLoop> logger, IHubContext<MainHub> mainHub)
    {
        _tickInterval = TimeSpan.FromSeconds(1.0 / _tickRate);
        _logger = logger;
        _mainHub = mainHub;
    }

    public void Start()
    {
        _logger.LogInformation("Game loop starting up...");
        _isRunning = true;

        var gameLoopThread = new Thread(Loop)
        {
            Name = "GameLoopThread"
        };
        
        gameLoopThread.Start();
        _logger.LogInformation("Game loop running");
    }

    public void Stop()
    {
        _isRunning = false;
    }

    private void Loop()
    {
        while (_isRunning)
        {
            var start = DateTime.Now;
            Update();
            var processingTime = DateTime.Now - start;
            var sleepTime = _tickInterval - processingTime;
            if (sleepTime > TimeSpan.Zero)
            {
                Thread.Sleep(sleepTime);
            }
            else
            {
                _logger.LogWarning("Can't keep up with current tick rate");
            }
        }
    }

    private void Update()
    {
        _mainHub.Clients.All.SendAsync("state-update", "Game update tick");
    }
}