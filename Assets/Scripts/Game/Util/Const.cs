namespace Constants {
	public static class Const {

    // LEVEL
    public const int MAX_LEVEL = 3;

    // Conveyer
    public static float[] CONVEYER_SPEED = { 0.02f, 0.025f, 0.03f };

    // Fruit Drop span
    public static float[] FRUIT_DROP_SPAN = { 4.0f, 3.2f, 2.6667f };

    // Fruit num
    public const int APPLE_NUM = 0;
    public const int GRAPE_NUM = 1;
    public const int LEMON_NUM = 2;
    public const int MELON_NUM = 3;
    public const int ORANGE_NUM = 4;

    // Emitted Fruit List
    public static int[][] FRUITS_LEVEL = {
      new int[]{ APPLE_NUM, GRAPE_NUM },
      new int[]{ APPLE_NUM, GRAPE_NUM, LEMON_NUM },
      new int[]{ APPLE_NUM, GRAPE_NUM, LEMON_NUM, MELON_NUM, ORANGE_NUM }
    };

    // Tag
    public const string CONVEYER_TAG = "Conveyer";
		public const string RECIEVER_TAG = "Reciever";
		public const string FRUIT_TAG = "Fruit";
    public const string GRABBED_FRUIT_TAG = "GrabbedFruit";

    // Layer
    public const int GRABBED_FRUIT_LAYER = 10;

    // Timer 
    public const float DEFAULT_INIT_TIME = 100.0f;
		public const float STEEL_MINUS_TIME = 5.0f;
    public const float TIME_CHANGE_LEVEL_2 = 70.0f;
    public const float TIME_CHANGE_LEVEL_3 = 40.0f;
  }
}
