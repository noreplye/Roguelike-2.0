public class Quest
{
    // static void Main(string[] args)
    //{
    //
    //  Quest2();
    //   AnswerQuest2();
    //}
    public int currentQuest = 0;
    public static void ColorOfName(string text, ConsoleColor color)
    {
        ScreenInfo screenInfo = new ScreenInfo(9);
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        ScreenInfo.AddInfo(text,screenInfo);
        ScreenInfo.ShowLastInfo(screenInfo);
        Console.ForegroundColor = defaultColor;

    }

    public static void MainQuests1(Person character)
    {
        ScreenInfo screenInfo = new ScreenInfo(9);
        ScreenInfo.AddInfo("Вы встретили незнакомца",screenInfo);
        ScreenInfo.ShowLastInfo(screenInfo);
        Console.ReadKey();
        ColorOfName("-Приветствую герой. Не поможешь ли ты мне?", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("-Чего ты хочешь?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("-Убей монстра и тогда я помогу тебе выбраться ", ConsoleColor.Yellow);
        Console.ReadKey();
        ScreenInfo.AddInfo("Хотите ли вы помочь ему?", screenInfo);
        ScreenInfo.AddInfo("press Y (Yes)" + " or " + " N (No)", screenInfo);
        ScreenInfo.ShowLastInfo(screenInfo);
        ConsoleKeyInfo answer = Console.ReadKey();
        while (1 == 1)
        {
            if (answer.Key == ConsoleKey.Y)
            {
                ColorOfName("Спасибо тебе, герой", ConsoleColor.Yellow);
                break;
            }
            if (answer.Key == ConsoleKey.N)
            {
                ColorOfName(".....", ConsoleColor.Yellow);
                character.win = 0;
                break;
            }
            answer = Console.ReadKey();
        }
        
    }
    public static void AnswerMain1(Person character)
    {
        ScreenInfo screenInfo = new ScreenInfo(2);
        ScreenInfo.AddInfo("Вы снова встретили незнакомца",screenInfo);
        Console.ReadKey();
        ColorOfName("-Ты убил монстра?", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("-Да", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("-За это я тебе дам особый предмет", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("-Спасибо, но как он поможет мне выбраться отсюда?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("-Благодаря ему ты сможешь быстрее расправляться с врагами.", ConsoleColor.Yellow);
        ColorOfName("-Плюс не забывай что есть и другие кому нужна помощь.", ConsoleColor.Yellow);
        ColorOfName("-Если поможешь моим друзьям, то я попробую вывести тебя отсюда.", ConsoleColor.Yellow);
        Console.ReadKey();






    }

    public static void Quest1(Person character)
    {
        ScreenInfo screenInfo = new ScreenInfo(2);
        ScreenInfo.AddInfo("Вы встретили таинственную фигуру в плаще", screenInfo);
        ColorOfName("- Кто ты такой ?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("- Я страж этого подземелья. Моя цель - уничтожать любого кто осмелится сбежать отсюда.", ConsoleColor.Yellow);
        Console.WriteLine(" ");
        Console.ReadKey();
        ColorOfName("- Ты выглядишь рассерженным. Что-то случилось?", ConsoleColor.Green);
        Console.WriteLine(" ");
        Console.ReadKey();
        ColorOfName("- Один тупоголовый Орк украл у меня мой лук Вескер " +
            "Поможешь мне? А я взамен тебе что нибудь весомое", ConsoleColor.Yellow);
        Console.WriteLine(" ");
        Console.ReadKey();
        ColorOfName("- Да, смогу", ConsoleColor.Green);
        Console.WriteLine(" ");

    }
    public static void AnswerQuest1()
    {
        Console.WriteLine("Вы встретили стража");
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Вот твой лук", ConsoleColor.Green);
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Это и впраду он" +
            "У меня ничего нет, но я в награду я могу закрыть глаза на некоторые твои поступки, в том числе побег отсюда", ConsoleColor.Yellow);
        Console.WriteLine(" ");
        Console.ReadKey();
    }

    public static void Quest2()
    {
        Console.WriteLine("Вы встретили всадника");
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Кто ты такой ?", ConsoleColor.Green);
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Я второй Всадник Апокалипсиса - Всадник войны." +
            " Я знаю, что ты хочешь сбежать,  я дам тебе свой Великий меч войны, но ты должен доказать, что достоин." +
            "Убей 20 врагов ", ConsoleColor.Yellow);
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Я сделаю это", ConsoleColor.Green);
        Console.WriteLine(" ");
        Console.ReadKey();
    }
    public static void AnswerQuest2()
    {
        Console.WriteLine("Вы снова встретили Всадника Апокалипсиса");
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Я уничтожил 20 врагов", ConsoleColor.Green);
        Console.WriteLine(" ");
        Console.ReadKey();

        ColorOfName("- Ты доказал, что достоин. Вот держи мечь", ConsoleColor.Yellow);
        Console.WriteLine(" ");
        Console.ReadKey();

    }

    public static void MainQuest2(map current_map)
    {
        ScreenInfo screenInfo = new ScreenInfo(9);
        ScreenInfo.AddInfo("Вы снова встретили таинственного незнакомца",screenInfo);
        ScreenInfo.ShowLastInfo(screenInfo);
        ColorOfName("- Снова ты?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("- Пора бы мне представиться.", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("Я тот кто может тебе дать второй шанс. Я помогу тебе выбраться", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("- Но почему?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("- Ты проделал огромную работу.", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("Это подземелье что-то среднее между адом и человечеством.", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("Cюда попадают те, кто еще может исправиться.", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("- Что нужно сделать?", ConsoleColor.Green);
        Console.ReadKey();
        ColorOfName("- Иди к следующей двери, я предупрежу тебя сразу.", ConsoleColor.Yellow);
        Console.ReadKey();
        ColorOfName("Там ты встретишь самого опасного врага!", ConsoleColor.Yellow);
        Console.ReadKey();
        current_map.kvesti.currentQuest++;
    }

}