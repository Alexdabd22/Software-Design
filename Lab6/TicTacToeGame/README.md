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

