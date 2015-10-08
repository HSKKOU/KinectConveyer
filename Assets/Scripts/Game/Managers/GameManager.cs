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
  private GUIManager guiManager;

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
    guiManager = GUIManager.Instance;
		
		conveyerManager.Initialize();
		fruitsManager.Initialize();
		scoreManager.Initialize();
		recieverManager.Initialize();
		thiefManager.Initialize();
		timerManager.Initialize();
    guiManager.Initialize();
		
//		this.GameStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GameStart() {
    this.guiManager.HideTitle();
		this.gameState = GameState.Playing;
    this.fruitsManager.InitialAction();
	}

  public void LevelUp(int levelNum) {
    this.fruitsManager.LevelUp(levelNum);
    this.conveyerManager.LevelUp(levelNum);
  }
	
	public void GameOver() {
		this.gameState = GameState.GameOver;
		this.conveyerManager.StopConveyer();
	}
}
