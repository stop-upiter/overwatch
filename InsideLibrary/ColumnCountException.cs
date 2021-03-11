using System;

namespace InsideLibrary
{
    /// <summary>
    /// Класс ошибки ColumnCountException - 
    /// ошибка в количестве колонок в строке.
    /// </summary>
    [Serializable]
    public class ColumnCountException : Exception
    {
        /// <summary>
        /// Пустой конструктор ColumnCountException.
        /// </summary>
        public ColumnCountException() { }

        /// <summary>
        /// Конструктор ColumnCountException с одним параметром.
        /// </summary>
        /// <param name="message">
        /// Сообщение ошибки.
        /// </param>
        public ColumnCountException(string message) : base(message) { }

        /// <summary>
        /// Конструктор ColumnCountException стремя целочисленными параметрами.
        /// </summary>
        /// <param name="row">
        /// Номер строки, в которой произошла ошибка.
        /// </param>
        /// <param name="countColumn">
        /// Нужное количество колонок.
        /// </param>
        /// <param name="realLen">
        /// Количество колонок в неправильной строке.
        /// </param>
        public ColumnCountException(int row, int countColumn, int realLen) : 
            this($"Неверное количество элементов в строке {row}:\n" +
                $"должно быть {countColumn}, получено {realLen}.\n" +      
                $"Если вы уверены, что количество элементов верное, " +                            
                $"проверьте и удалите все найденые ; из текста элементов.") { }

        /// <summary>
        /// Классический конструктор ошибки с двумя параметрами.
        /// </summary>
        /// <param name="message">
        /// Сообщение ошибки.
        /// </param>
        /// <param name="inner">
        /// Внутреннее исключение.
        /// </param>
        public ColumnCountException(string message, Exception inner) : base(message, inner) { }

        // хз что это :)
        protected ColumnCountException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
