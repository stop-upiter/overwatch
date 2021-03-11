using System;

namespace InsideLibrary
{
    /// <summary>
    /// Класс ошибки формата заголовка - 
    /// что-то было введено не так.
    /// </summary>
    [Serializable]
    public class HeaderFormatException : FormatException
    {
        /// <summary>
        /// Пустой конструктор класса HeaderFormatException.
        /// </summary>
        public HeaderFormatException() { }

        /// <summary>
        /// Конструктор класса HeaderFormatException с одним строковым параметром.
        /// </summary>
        /// <param name="message">
        /// Сообщение ошибки.
        /// </param>
        public HeaderFormatException(string message) : base(message) { }

        /// <summary>
        /// Конструктор класса HeaderFormatException с одним целочисленным параметром.
        /// </summary>
        /// <param name="headerNumber">
        /// Номер неправильного заголовка.
        /// </param>
        /// <remarks>
        /// В зависимости от номера заголовка создаются разные сообщения.
        /// </remarks>
        public HeaderFormatException(int headerNumber) : 
            this(HeaderFormatExceptionMessage(headerNumber)) { }

        /// <summary>
        /// Классический конструктор ошибки с двумя параметрами.
        /// </summary>
        /// <param name="message">
        /// Сообщение ошибки.
        /// </param>
        /// <param name="inner">
        /// Внутреннее исключение.
        /// </param>
        public HeaderFormatException(string message, Exception inner) : base(message, inner) { }

        // idk =(
        protected HeaderFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Метод для выбора нужного сообщения 
        /// в зависимости от номера заголовка, в котором ошибка.
        /// </summary>
        /// <param name="headerNumber">
        /// Номер неправильного заголовка.
        /// </param>
        /// <returns>
        /// Сообщение ошибки для данного заголовка.
        /// </returns>
        static string HeaderFormatExceptionMessage(int headerNumber)
        {
            switch (headerNumber)
            {
                case 0:
                    return $"Самый первый заголовок и уже неправильный! " +
                        $"Что за безобразие! " +
                        $"Разве так сложно исправить на \"Heroes\"?";
                case 1:
                    return $"Второй заголовок неправильный! " +
                        $"Аккуратнее! " +
                        $"Я понимаю, что сложно, но исправь его на \"Damage per second\", ладно?)";
                case 2:
                    return $"Третий заголовок неправильный! " +
                        $"Будь внимательнее! " +
                        $"Поправь его, пожалуйста, на \"Headshot DPS\" =)";
                case 3:
                    return $"Четвёртый заголовок неправильный! " +
                        $"Будь внимательнее! " +
                        $"Поправь его, пожалуйста, на \"Single shot\" =)";
                case 4:
                    return $"Пятый заголовок неправильный! " +
                        $"Будь внимательнее! " +
                        $"Поправь его, пожалуйста, на \"Life\" =)";
                case 5:
                    return $"Последний заголовок неправильный! " +
                         $"Будь внимательнее! " +
                         $"Поправь его, пожалуйста, на \"Reload\" =)";
                default:
                    return "Ты вообще нужное количество заголовков ввел? " +
                        "Их всего шесть! Счет от нуля!";
            }
        }
    }
}
