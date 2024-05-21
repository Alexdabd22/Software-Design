# TicTacToeGame

## Опис проекту
Цей проект реалізує гру "Хрестики-нулики" з використанням WPF та різних патернів проєктування. Гра підтримує режими "Грати з AI" та "Грати з другом", зберігає історію ігор та веде рейтинг гравців.

## Функціонал
- **Режими гри**: Гра з AI або з іншим гравцем.
- **Вибір поля**: 3х3,4х4,5х5.
- **Реєстрація та вхід**: Користувачі можуть реєструватися та входити в систему.
- **Історія ігор**: Зберігання та перегляд історії зіграних ігор.
- **Рейтинг**: Ведення рейтингу гравців на основі виграних ігор.
- **Пауза**: Користувач може натиснути на Esc та щоб продовжити Enter.
- **Відмінна ходу**: Є кнопка яка дозволяє відмінти хід 

## Programming Principles
1. **Single Responsibility Principle (SRP)** - Кожен клас має лише одну відповідальність.
    ```csharp
    // PlayerManager.cs
    public class PlayerManager
    {
        // Відповідальний лише за управління гравцями в базі даних
    }
    ```

2. **Open/Closed Principle (OCP)** - Класи відкриті для розширення, але закриті для змін.
    ```csharp
    // IGameStrategy.cs
    public interface IGameStrategy
    {
        void CheckGameState(GameViewModel gameViewModel);
    }

    // PlayerVsAIStrategy.cs
    public class PlayerVsAIStrategy : IGameStrategy
    {
        public void CheckGameState(GameViewModel gameViewModel)
        {
            // Реалізація для AI
        }
    }

    // PlayerVsPlayerStrategy.cs
    public class PlayerVsPlayerStrategy : IGameStrategy
    {
        public void CheckGameState(GameViewModel gameViewModel)
        {
            // Реалізація для гравця проти гравця
        }
    }
    ```

3. **Liskov Substitution Principle (LSP)** - Наслідуючі класи можуть заміняти базові без порушення роботи програми.
    ```csharp
    // Використання IGameStrategy для підстановки різних стратегій гри
    gameViewModel.SetGameStrategy(new PlayerVsAIStrategy());
    ```

4. **Interface Segregation Principle (ISP)** - Клієнти не повинні залежати від інтерфейсів, які вони не використовують.
    ```csharp
    // Інтерфейси IObserver та ISubject
    public interface IObserver
    {
        void Update(string propertyName);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string propertyName);
    }
    ```

5. **Dependency Inversion Principle (DIP)** - Високорівневі модулі не повинні залежати від низькорівневих модулів. Обидва повинні залежати від абстракцій.
    ```csharp
    // Ін'єкція залежностей для PlayerManager та DatabaseManager
    public GameWindow(bool playWithAI, string username, int boardSize, DatabaseManager dbManager, PlayerManager playerManager)
    {
        InitializeComponent();
        this.dbManager = dbManager;
        this.playerManager = playerManager;
    }
    ```
## Design Patterns
1. **Command Pattern**
    - **Файли**: [MakeMoveCommand.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Commands/MakeMoveCommand.cs), [PauseGameCommand.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Commands/PauseGameCommand.cs), [RegisterPlayerCommand.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Commands/RegisterPlayerCommand.cs)
    - **Пояснення**: Використовується для інкапсуляції запиту як об'єкта, дозволяючи параметризувати клієнтів з різними запитами, чергами або журналами запитів.
    ```csharp
    public class MakeMoveCommand : ICommand
    {
        private readonly GameViewModel _gameViewModel;
        private readonly int _row;
        private readonly int _column;
        private readonly int _player;

        public MakeMoveCommand(GameViewModel gameViewModel, int row, int column, int player)
        {
            _gameViewModel = gameViewModel;
            _row = row;
            _column = column;
            _player = player;
        }

        public void Execute()
        {
            _gameViewModel.MakeMoveInternal(_row, _column, _player);
        }

        public void Undo()
        {
            _gameViewModel.UndoMove(_row, _column, _previousValue);
        }
    }
    ```

2. **Observer Pattern**
    - **Файли**: [IObserver.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Observer/IObserver.cs), [ISubject.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Observer/ISubject.cs), [Subject.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Observer/Subject.cs)
    - **Пояснення**: Використовується для інформування об'єктів-спостерігачів про зміну стану суб'єкта, дозволяючи динамічно додавати/видаляти спостерігачів.
    ```csharp
    public interface IObserver
    {
        void Update(string propertyName);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string propertyName);
    }

    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string propertyName)
        {
            foreach (var observer in observers)
            {
                observer.Update(propertyName);
            }
        }
    }
    ```

3. **Strategy Pattern**
    - **Файли**: [IGameStrategy.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Strategy/IGameStrategy.cs), [PlayerVsAIStrategy.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Strategy/PlayerVsAIStrategy.cs), [PlayerVsPlayerStrategy.cs](https://github.com/Alexdabd22/Software-Design/blob/main/Lab6/TicTacToeGame/TicTacToeGame/Strategy/PlayerVsPlayerStrategy.cs)
    - **Пояснення**: Використовується для визначення сімейства алгоритмів, інкапсуляції кожного з них і забезпечення їх взаємозамінності.
    ```csharp
    public interface IGameStrategy
    {
        void CheckGameState(GameViewModel gameViewModel);
    }

    public class PlayerVsAIStrategy : IGameStrategy
    {
        public void CheckGameState(GameViewModel gameViewModel)
        {
            if (gameViewModel.CheckForWinner())
            {
                gameViewModel.OnPropertyChanged("Winner");
                gameViewModel.Notify("Winner");
            }
            else if (gameViewModel.IsDraw())
            {
                gameViewModel.OnPropertyChanged("Draw");
                gameViewModel.Notify("Draw");
            }
            else
            {
                gameViewModel.ChangePlayer();
                if (gameViewModel.CurrentPlayer == 2)
                {
                    gameViewModel.PerformAiMove();
                }
            }
        }
    }

    public class PlayerVsPlayerStrategy : IGameStrategy
    {
        public void CheckGameState(GameViewModel gameViewModel)
        {
            if (gameViewModel.CheckForWinner())
            {
                gameViewModel.OnPropertyChanged("Winner");
                gameViewModel.Notify("Winner");
            }
            else if (gameViewModel.IsDraw())
            {
                gameViewModel.OnPropertyChanged("Draw");
                gameViewModel.Notify("Draw");
            }
            else
            {
                gameViewModel.ChangePlayer();
            }
        }
    }
    ```
