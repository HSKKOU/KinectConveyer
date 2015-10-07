using UnityEngine;
using System.Collections;

public class GameManager : SingletonMono<GameManager> {
	
	public enum GameState {
		Init,
		Title,
		Playing,
		GameOver,
		Result,
		Num
	}
	private GameState gameState = GameState.Init;
	public GameState getGameState(){return this.gameState;}
	
	private ConveyerManager conveyerManager;
	private DustboxManager dustboxManager;
	private FruitsManager fruitsManager;
	private ScoreManager scoreManager;
	private RecieverManager recieverManager;
	private ThiefManager thiefManager;
	private TimerManager timerManager;
	private TrashManager trashManager;

	// Use this for initialization
	void Start () {
		conveyerManager = ConveyerManager.Instance;
		dustboxManager = DustboxManager.Instance;
		fruitsManager = FruitsManager.Instance;
		scoreManager = ScoreManager.Instance;
		recieverManager = RecieverManager.Instance;
		thiefManager = ThiefManager.Instance;
		timerManager = TimerManager.Instance;
		trashManager = TrashManager.Instance;
		
		conveyerManager.Initialize();
		fruitsManager.Initialize();
		scoreManager.Initialize();
		thiefManager.Initialize();
		timerManager.Initialize();
		
		this.GameStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GameStart() {
		this.gameState = GameState.Playing;
	}
	
	public void GameOver() {
		this.gameState = GameState.GameOver;
		this.conveyerManager.StopConveyer();
	}
}
