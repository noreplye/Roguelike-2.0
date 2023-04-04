internal class Program
{
   
    static void Main(string[] args)
    {
        ScreenInfo.StartGreeting();
        ScreenInfo.Menu(5,18,171,4);
        Game.GameProcess();
           
    }
}