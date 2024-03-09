# Принципи програмування у MoneyClassLibrary

Цей документ описує, як у проекті MoneyClassLibrary дотримуються відомі принципи програмування.

## DRY (Don't Repeat Yourself)

Цей принцип демонструється в класах валют [`Dollar`](./MoneyClassLibrary/Dollar.cs) та [`Euro`](./MoneyClassLibrary/Euro.cs), які успадковують спільну поведінку від абстрактного класу [`Currency`](./MoneyClassLibrary/Currency.cs), уникаючи повторення коду.

## KISS (Keep It Simple, Stupid)

Код проекту тримається простим та зрозумілим, як, наприклад, метод `ReducePrice` у класі [`Product`](./MoneyClassLibrary/Product.cs), який просто зменшує ціну продукту без зайвої складності.

## SOLID

### Single Responsibility Principle (SRP)

Клас [`Product`](./MoneyClassLibrary/Product.cs) відповідає лише за інформацію та операції, пов'язані з продуктом, дотримуючись SRP.

### Open/Closed Principle (OCP)

Клас [`Currency`](./MoneyClassLibrary/Currency.cs) є відкритим для розширення (створення нових валют як нащадків), але закритим для модифікації.

### Liskov Substitution Principle (LSP)

Нащадки класу [`Currency`](./MoneyClassLibrary/Currency.cs), такі як `Dollar` та `Euro`, можуть бути взаємозамінними без впливу на правильність програми.

### Interface Segregation Principle (ISP)

Цей принцип не демонструється яскраво у цьому проекті, оскільки він не використовує інтерфейси у великому обсязі.

### Dependency Inversion Principle (DIP)

Клас [`Reporting`](./MoneyClassLibrary/Reporting.cs) залежить від абстракції `Warehouse`, а не від конкретної реалізації, дотримуючись DIP.

## YAGNI (You Aren't Gonna Need It)

Усі класи та методи в проекті створені з конкретною потребою, без зайвого функціоналу, який "може знадобитися у майбутньому".

## Composition Over Inheritance

Цей проект використовує композицію, як, наприклад, клас [`Product`](./MoneyClassLibrary/Product.cs), який містить `Money`, замість успадкування.

## Program to Interfaces not Implementations

Цей принцип може бути застосований у майбутніх розширеннях проекту, наприклад, інтеграції з базою даних або зовнішніми сервісами.

## Fail Fast

Методи, такі як конструктор в [`Currency`](./MoneyClassLibrary/Currency.cs), використовують перевірки аргументів для швидкого виявлення помилок.



