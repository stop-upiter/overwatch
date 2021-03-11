using System;
using System.Collections.Generic;
using System.IO;

namespace InsideLibrary
{
    /// <summary>
    /// Класс для парсинга файла типа .csv
    /// </summary>
    public class ParserCSV
    {
        /// <summary>
        /// Свойство путь до файла, из которого производится парсинг.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Свойство количество колонок - 
        /// сколько именно их должно быть в таблице.
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Массив из названий заголовков таблицы.
        /// </summary>
        public string[] Header { get; private set; }

        /// <summary>
        /// Свойство список с построчной информацией таблицы csv.
        /// </summary>
        public List<Unit> TableInfo { get; private set; }

        /// <summary>
        /// Массив с поячеечной информацией таблицы csv.
        /// </summary>
        private string[,] table;

        /// <summary>
        /// Конструктор парсера.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу, 
        /// из которого нужно заспарсить таблицу.
        /// </param>
        /// <param name="columns">
        /// Количество колонок - 
        /// сколько именно их должно быть в таблице.
        /// </param>
        /// <remarks>
        /// <para>
        /// Все нужные технические действия вызываются из конструктора.
        /// </para>
        /// <para>
        /// Объект класса нужен для хранения и 
        /// удобного доступа к запарсенной информации.
        /// </para>
        /// </remarks>
        /// <exception cref="System.ArgumentException">
        /// <para>
        /// Если в строке с адресом файла пустая, 
        /// состоит только из разделительных симболов 
        /// или не содержит точку.
        /// </para>
        /// <para>
        /// Если указанное количество колонок неположительное.
        /// </para>
        /// </exception>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Если файла с заданным адресом path не существует.
        /// </exception>
        /// <exception cref="System.NotImplementedException">
        /// Если этот файл не csv - парсинг не поддерживается.
        /// </exception>
        /// <exception cref="System.UnauthorizedAccessException">
        /// Если у нас запрет доступа операционной системой
        /// из-за ошибки ввода-вывода
        /// или особого типа ошибки безопасности.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Если у нас в принципе ошибка ввода-вывода.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// Если ошибка безопасности.
        /// </exception>
        /// <exception cref="System.IO.InvalidDataException">
        /// <para>
        /// Если указанный файл - пуст.
        /// </para>
        /// <para>
        /// Если в указанном файле меньше 3 строк - 
        /// слишком мало персонажей для игры.
        /// </para>
        /// </exception>
        /// <exception cref="InsideLibrary.ColumnCountException">
        /// Если количество колонок в строке не равно Columns.
        /// </exception>
        /// <exception cref="InsideLibrary.HeaderFormatException">
        /// Если заголовок неправильный.
        /// </exception>
        public ParserCSV(string path, int columns = 6)
        {
            if (String.IsNullOrWhiteSpace(path) || !path.Contains("."))
            {
                throw new ArgumentException(
                    $"Неверный вид аргумента - пути к файлу! " +
                    $"\"{path}\" - не адрес файла", "path");
            }

            if (columns <= 0)
            {
                throw new ArgumentException(
                    $"Значение {columns} недопустимо для количества столбцов таблицы",
                    "columns");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    $"Файл с адресом {path} не существует");
            }

            if (path.Split('.')[path.Split('.').Length - 1] != "csv")
            {
                throw new NotImplementedException(
                    $"Парсинг файлов типа " +
                    $"{path.Split('.')[path.Split('.').Length - 1]}" +
                    $" не поддерживается");
            }

            Path = path;

            Columns = columns;

            ParseCSV();
            TableArrayToList();
        }

        /// <summary>
        /// Конструктор пустого парсера.
        /// </summary>
        /// <remarks>
        /// По факту это создание пустого образца, 
        /// с которым мы ничего не можем поделать.
        /// Но зато не null.
        /// </remarks>
        public ParserCSV()
        {
            Path = String.Empty;
            Columns = 0;
            TableInfo = new List<Unit>();
            table = new string[0, 0];
            Header = new string[0];
        }

        /// <summary>
        /// Метод для первичного парсинга информации из файла.
        /// </summary>
        /// <remarks>
        /// Здесь инициализируется параметр table.
        /// </remarks>
        /// <exception cref="System.UnauthorizedAccessException">
        /// Если у нас запрет доступа операционной системой
        /// из-за ошибки ввода-вывода
        /// или особого типа ошибки безопасности.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// Если у нас в принципе ошибка ввода-вывода.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// Если ошибка безопасности.
        /// </exception>
        /// <exception cref="System.IO.InvalidDataException">
        /// <para>
        /// Если указанный файл - пуст.
        /// </para>
        /// <para>
        /// Если в указанном файле меньше 3 строк - 
        /// слишком мало персонажей для игры.
        /// </para>
        /// </exception>
        /// <exception cref="InsideLibrary.ColumnCountException">
        /// Если количество колонок в строке не равно Columns.
        /// </exception>
        void ParseCSV()
        {
            var lines = File.ReadAllLines(Path);

            if (lines.Length == 0)
            {
                throw new InvalidDataException(
                    $"Пустой файл!");
            }

            if (lines.Length < 3)
            {
                throw new InvalidDataException(
                    $"Количество персонажей в файле слишком мало!");
            }

            var tablet = new List<string[]>();

            for (int i = 0; i < lines.Length; i++)
            {
                
                // Пустые строки пропускаются.
                if (!String.IsNullOrWhiteSpace(lines[i].Trim()))
                {
                    tablet.Add(new string[Columns]);

                    var words = lines[i].Split(';');

                    if (words.Length != Columns)
                    {
                        throw new ColumnCountException(i + 1, Columns, words.Length);
                    }

                    for (int j = 0; j < Columns; j++)
                    {
                        words[j] = words[j].Trim();

                        if (String.IsNullOrEmpty(words[j]))
                        {
                            words[j] = "0";
                        }

                        tablet[tablet.Count-1][j] = words[j];
                    }
                }
            }

            table = new string[tablet.Count, Columns];

            for (int i = 0; i < tablet.Count; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    table[i, j] = tablet[i][j];
                }
            }
        }

        /// <summary>
        /// Метод для преобразования поячеечной информации 
        /// из таблицы в построчный список.
        /// </summary>
        void TableArrayToList()
        {
            TableInfo = new List<Unit>();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                string[] tmp = new string[table.GetLength(1)];

                for (int j = 0; j < table.GetLength(1); j++)
                {
                    tmp[j] = table[i, j];
                }

                if (i != 0)
                {
                    Unit un = new Unit(tmp);

                    if (!un.IsEmpty())
                    {
                        TableInfo.Add(un);
                    }
                }
                else
                {
                    CheckHeaders(tmp); 
                    Header = tmp;
                }
            }
        }

        /// <summary>
        /// Метод для проверки корректности заголовков.
        /// </summary>
        /// <param name="headers">
        /// Массив из данных заголовков.
        /// </param>
        /// <exception cref="InsideLibrary.HeaderFormatException">
        /// Если заголовок неправильный.
        /// </exception>
        void CheckHeaders(string[] headers)
        {
            string Lower(string s)
            {
                return s.Replace(" ", String.Empty).ToLowerInvariant();
            }

            for (int k = 0; k < headers.Length; k++)
            {
                headers[k] = headers[k].Replace("<", String.Empty);
                headers[k] = headers[k].Replace(">", String.Empty);
                headers[k] = headers[k].Replace(";", String.Empty);
                headers[k] = headers[k].Trim();

                bool isRight = true;
                switch (k)
                {
                    case 0:
                        isRight = Lower(headers[k]) == "heroes";
                        break;
                    case 1:
                        isRight = Lower(headers[k]) == "damagepersecond";
                        break;
                    case 2:
                        isRight = Lower(headers[k]) == "headshotdps";
                        break;
                    case 3:
                        isRight = Lower(headers[k]) == "singleshot";
                        break;
                    case 4:
                        isRight = Lower(headers[k]) == "life";
                        break;
                    case 5:
                        isRight = Lower(headers[k]) == "reload";
                        break;
                }

                if (!isRight)
                {
                    throw new HeaderFormatException(k);
                }
            }
        }

        /// <summary>
        /// Переопределенный метод приведения к строке.
        /// </summary>
        /// <returns>
        /// Сведения о хранимой информации в объекте Парсере.
        /// </returns>
        /// <remarks>
        /// Метод нужен для последующей работы с классом.
        /// В рамках данного приложения его использование не предусмотрено.
        /// </remarks>
        public override string ToString()
        {
            return $"ParserCSV: колонок {Columns}, " +
                $"строчек {TableInfo.Count}, " +
                $"файл прочитан из {Path}";
        }
    }
}
