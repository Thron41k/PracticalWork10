using Task1.Logger;

namespace Task1.Calculator;


/// <summary>
/// Класс калькулятора, реализующий интерфейс ICalculator.
/// </summary>
internal class Calculator(ILogger logger) : ICalculator
{
    /// <summary>
    /// Складывает два числа типа double.
    /// </summary>
    /// <param name="num1">Первое слагаемое типа double.</param>
    /// <param name="num2">Второе слагаемое типа double.</param>
    /// <returns>Сумма двух чисел типа double.</returns>
    public double Add(double num1, double num2)
    {
        // Логируем событие, информирующее о том, что происходит сложение двух чисел.
        logger.Event($"Сумма чисел {num1} и {num2} равна {num1 + num2}");

        // Выполняем сложение двух чисел и возвращаем результат.
        return num1 + num2;
    }

    /// <summary>
    /// Преобразует строковое значение в число типа double.
    /// </summary>
    /// <param name="input">Входная строка для преобразования типа string.</param>
    /// <param name="value">Выходное значение типа double.</param>
    /// <returns>True, если преобразование успешно, False в противном случае.</returns>
    public bool GetValue(string? input, out double value)
    {
        try
        {
            // Пытаемся преобразовать строку в число типа double.
            value = Convert.ToDouble(input);

            // Если преобразование успешно, возвращаем true.
            return true;
        }
        catch (FormatException)
        {
            // Если во время преобразования возникает исключение FormatException, логируем ошибку.
            logger.Error("Ошибка: введенное значение не является числом.");
        }
        catch (Exception ex)
        {
            // Если во время преобразования возникает любое другое исключение, логируем ошибку.
            logger.Error($"Ошибка: {ex.Message}");
        }

        // Если преобразование не удалось, присваиваем value значение 0 и возвращаем false.
        value = 0;
        return false;
    }
}