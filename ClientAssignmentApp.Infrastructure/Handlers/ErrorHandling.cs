namespace ClientAssignmentApp.Infrastructure.Handlers
{
    /// <summary>
    /// Middleware для обработки ошибок в асинхронных вызовах.
    /// </summary>
    public class ErrorHandling
    {
        /// <summary>
        /// Вызывает переданную функцию и обрабатывает возможные исключения.
        /// </summary>
        /// <param name="next">Асинхронная функция, которую нужно выполнить.</param>
        /// <returns>Асинхронная задача.</returns>
        public async Task Invoke(Func<Task> next)
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
