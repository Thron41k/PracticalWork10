﻿namespace Task1.Logger;

/// <summary>
/// Интерфейс логгера
/// </summary>
internal interface ILogger
{
    /// <summary>
    /// Регистрирует событие с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение о событии.</param>
    public void Event(string message);

    /// <summary>
    /// Регистрирует ошибку с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public void Error(string message);
}