namespace Task1.Calculator;

/// <summary>
/// Интерфейс калькулятора, реализующий методы сложения и преобразования строкового значения в число.
/// </summary>
internal interface ICalculator
{
    /// <summary>
    /// Складывает два числа типа double.
    /// </summary>
    /// <param name="num1">Первое слагаемое типа double.</param>
    /// <param name="num2">Второе слагаемое типа double.</param>
    /// <returns>Сумма двух чисел типа double.</returns>
    double Add(double num1, double num2);


    /// <summary>
    /// Преобразует строковое значение в число типа double.
    /// </summary>
    /// <param name="input">Входная строка для преобразования типа string.</param>
    /// <param name="value">Выходное значение типа double.</param>
    /// <returns>True, если преобразование успешно, False в противном случае.</returns>
    bool GetValue(string? input, out double value);
}