namespace Constants {
	public static class Const {

    // LEVEL
    public const int MAX_LEVEL = 3;

    // Conveyer
    public static float[] CONVEYER_SPEED = { 0.03f, 0.03f, 0.04f };

    // Fruit Drop span
    public static float[] FRUIT_DROP_SPAN = { 2.8f, 2.4f, 2.4f };

    // Fruit num
    public const int APPLE_NUM = 0;
    public const int GRAPE_NUM = 1;
    public const int LEMON_NUM = 2;
    public const int MELON_NUM = 3;
    public const int ORANGE_NUM = 4;
    // Fruit name
    public const string APPLE_NAME = "Apple";
    public const string GRAPE_NAME = "Grape";
    public const string LEMON_NAME = "Lemon";
    public const string MELON_NAME = "Melon";
    public const string ORANGE_NAME = "Orange";

    // Tag
    public const string CONVEYER_TAG = "Conveyer";
		public const string RECIEVER_TAG = "Reciever";
		public const string FRUIT_TAG = "Fruit";
    public const string GRABBED_FRUIT_TAG = "GrabbedFruit";
    public const string RELEASED_FRUIT_TAG = "ReleasedFruit";

    // Layer
    public const int GRABBED_FRUIT_LAYER = 10;

    // Timer 
    public const float DEFAULT_INIT_TIME = 100.0f;
		public const float STEEL_MINUS_TIME = 5.0f;
    public const float TIME_CHANGE_LEVEL_2 = 70.0f;
    public const float TIME_CHANGE_LEVEL_3 = 40.0f;


    // Score unit
    public const int DEFAULT_PLUS_POINT = 100;
    public const int DEFAULT_MINUS_POINT = -50;
    public const int BONUS_UNIT = 20;
    public const int COUNT_BONUS_UP = 5;
  }
}
