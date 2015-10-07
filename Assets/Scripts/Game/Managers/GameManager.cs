using UnityEngine;
using System.Collections;

public class GameManager : SingletonMono<GameManager> {
	
	public enum GameState {
		Init,
		Title,
		Start,
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
