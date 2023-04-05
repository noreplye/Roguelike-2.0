internal class Program
{
    static void Main(string[] args)
    {
        ScreenMenu.StartGreeting();
		ScreenMenu.StartNaming();
        ScreenMenu.Menu(5,18,171,4);
        Game.GameProcess();
           
    }
}