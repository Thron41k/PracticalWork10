using Task1.Calculator;
using Task1.Logger;

// Создаем экземпляр класса логгера и присваиваем его переменной logger.
var logger = new Logger();

// Создаем экземпляр класса калькулятора и передаем в него экземпляр логгера.
var calc = new Calculator(logger);

// Создаем массив значений с размером 2 и типом double?.
var val = new double?[2];

// Создаем переменную currentCursorPosition для хранения текущей позиции курсора.
(int Left, int Top) currentCursorPosition;

// Устанавливаем позицию курсора в начало экрана.
Console.SetCursorPosition(0,5);

// Запускаем цикл для ввода значений слагаемых.
for (var i = 0; i < 2; i++)
{
    // Сохраняем текущую позицию курсора.
    currentCursorPosition = Console.GetCursorPosition();

    // Устанавливаем позицию курсора в начало строки и выводим сообщение о вводе слагаемого.
    Console.SetCursorPosition(0, i);
    Console.Write($"Введите слагаемое №{i + 1}: ");

    // Считываем введенное значение слагаемого.
    var input = Console.ReadLine();

    // Восстанавливаем позицию курсора.
    Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);

    // Создаем переменную result для хранения результата преобразования введенного значения.
    double result;

    // Проверяем, что значение слагаемого является числом.
    while (!calc.GetValue(input,out result))
    {
        // Сохраняем текущую позицию курсора.
        currentCursorPosition = Console.GetCursorPosition();

        // Устанавливаем позицию курсора в начало строки и очищаем содержимое строки.
        Console.SetCursorPosition(0, i);
        Console.WriteLine(new string(' ', Console.WindowWidth));

        // Устанавливаем позицию курсора в начало строки и выводим сообщение о вводе слагаемого.
        Console.SetCursorPosition(0, i);
        Console.Write($"Введите слагаемое №{i + 1}: ");

        // Считываем новое значение слагаемого.
        input = Console.ReadLine();

        // Восстанавливаем позицию курсора.
        Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
    }

    // Сохраняем введенное значение слагаемого в массиве val.
    val[i] = result;

    // Проверяем, что все значения слагаемых были введены.
    if (val.All(x => x.HasValue))
    {
        // Сохраняем текущую позицию курсора.
        currentCursorPosition = Console.GetCursorPosition();

        // Вычисляем сумму слагаемых.
        var sum = calc.Add(val[0]!.Value, val[1]!.Value);

        // Устанавливаем позицию курсора и выводим сумму.
        Console.SetCursorPosition(0, 2);
        Console.WriteLine($"Сумма: {sum}");

        // Устанавливаем счетчик цикла обратно на начало.
        i = -1;

        // Устанавливаем позицию курсора и выводим сообщение.
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("Нажмите любую клавишу для выхода или ENTER для продолжения.");

        // Восстанавливаем позицию курсора.
        Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);

        // Ожидаем нажатия клавиши.
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Enter:
                // Вызываем метод ResetCalc для сброса калькулятора.
                ResetCalc();
                break;
            default:
                // Выходим из программы.
                return;
        }
    }
}

return;

// Метод для сброса калькулятора.
void ResetCalc()
{
    // Обнуляем массив значений.
    val = new double?[2];

    // Устанавливаем позицию курсора в начало экрана.
    Console.SetCursorPosition(0, 0);

    // Очищаем содержимое экрана.
    for (var i = 0; i < 4; i++)
    {
        Console.WriteLine(new string(' ', Console.WindowWidth));
    }

    // Восстанавливаем позицию курсора.
    Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
}

