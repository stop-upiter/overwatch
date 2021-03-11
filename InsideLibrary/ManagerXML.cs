using System;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace InsideLibrary
{
    /// <summary>
    /// Помощник для работы с XML - запись и чтение XML.
    /// </summary>
    public static class ManagerXML
    {
        /// <summary>
        /// Метод для получения информации о сохраненной в XML игре.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу с сохраненной игрой.
        /// </param>
        /// <returns>
        /// Кортеж из юнита игрока,
        /// юнита компьютера,
        /// текущего раунда,
        /// логического значения - сейчас очередь игрока?
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Если данные в файле некорректны.
        /// </exception>        
        /// <exception cref="System.ArgumentException">
        /// Если в строке с адресом файла пустая, 
        /// состоит только из разделительных симболов 
        /// или не содержит точку.
        /// </exception>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Если файла с заданным адресом path не существует.
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
        /// <exception cref="System.NotImplementedException">
        /// Если этот файл не xml - парсинг не поддерживается.
        /// </exception>
        /// <exception cref="System.UriFormatException">
        /// Исключение возникает при обнаружении недопустимого универсального кода ресурса (URI).
        /// </exception>
        /// <exception cref="System.IO.FileLoadException">
        /// Если формат файла не соответствует схеме.
        /// </exception>
        public static Tuple<Unit, Unit, int, bool> ParseXMLForGame(string path)
        {
            var document = DoDocWithSchema(path);
            var fight = document.DocumentElement;
            var children = fight.ChildNodes;

            XmlNode player;
            XmlNode computer;

            int raund;
            bool turn;

            Unit pl;
            Unit comp;

            try
            {
                player = children[0];
                computer = children[1];
                raund = int.Parse(fight.GetAttribute("Raund"));
                turn = bool.Parse(fight.GetAttribute("Turn"));

                if (raund <= 0)
                {
                    raund = 1;
                }

                string[] values = new string[6]
                {
                    player.Attributes[0].Value,
                     player.Attributes[1].Value,
                      player.Attributes[2].Value,
                       player.Attributes[3].Value,
                        player.Attributes[4].Value,
                         player.Attributes[5].Value,
                };

                pl = new Unit(values, player.Attributes[6].Value);

                values = new string[6]
                {
                    computer.Attributes[0].Value,
                     computer.Attributes[1].Value,
                      computer.Attributes[2].Value,
                      computer.Attributes[3].Value,
                        computer.Attributes[4].Value,
                         computer.Attributes[5].Value,
                };

                comp = new Unit(values, computer.Attributes[6].Value);
            }
            catch (FormatException)
            {
                throw new FormatException("Неправильные данные в xml!");
            }

            return new Tuple<Unit, Unit, int, bool>(pl, comp, raund, turn);
        }

        /// <summary>
        /// Метод для чтения xml-файла и проверки его на соответствие схеме.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу с сохраненной игрой.
        /// </param>
        /// <returns>
        /// Считанный xml-документ.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Если в строке с адресом файла пустая, 
        /// состоит только из разделительных симболов 
        /// или не содержит точку.
        /// </exception>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Если файла с заданным адресом path не существует.
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
        /// <exception cref="System.NotImplementedException">
        /// Если этот файл не xml - парсинг не поддерживается.
        /// </exception>
        /// <exception cref="System.UriFormatException">
        /// Исключение возникает при обнаружении недопустимого универсального кода ресурса (URI).
        /// </exception>
        /// <exception cref="System.IO.FileLoadException">
        /// Если формат файла не соответствует схеме.
        /// </exception>
        static XmlDocument DoDocWithSchema(string path)
        {
            if (String.IsNullOrWhiteSpace(path) || !path.Contains("."))
            {
                throw new ArgumentException(
                    $"Неверный вид аргумента - пути к файлу! " +
                    $"\"{path}\" - не адрес файла", "path");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    $"Ой-ой-ой! Файл по адресу {path} не найден." +
                    $" Кажется, вас обманули! (или вы его удалили)");
            }

            if (path.Split('.')[path.Split('.').Length - 1] != "xml")
            {
                throw new NotImplementedException(
                    $"Парсинг файлов типа " +
                    $"{path.Split('.')[path.Split('.').Length - 1]}" +
                    $" не поддерживается");
            }

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.Schemas.Add(GetSchema());
            readerSettings.ValidationType = ValidationType.Schema;
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;

            readerSettings.ValidationEventHandler += new ValidationEventHandler(
                (o, e) => throw new FileLoadException($"Неверный формат xml файла!"));

            XmlDocument document = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(path, readerSettings))
            {
                document.Load(reader);
            }

            return document;
        }

        /// <summary>
        /// Метод для получения схемы для xml-файлов.
        /// </summary>
        /// <returns>
        /// Схему для xml-файлов.
        /// </returns>
        /// <remarks>
        /// Я заморочилась, да. 
        /// Если что схема в текстовом виде ниже в качестве комментария.
        /// </remarks>
        static XmlSchema GetSchema()
        {
            XmlSchema schema = new XmlSchema();

            // <xs:element name = "Fight" >
            XmlSchemaElement elementFight = new XmlSchemaElement();
            schema.Items.Add(elementFight);
            elementFight.Name = "Fight";

            //< xs:complexType>
            XmlSchemaComplexType complexType = new XmlSchemaComplexType();
            elementFight.SchemaType = complexType;

            // <xs:attribute name = ""raund"" type=""xs:decimal"" use=""required"" />
            XmlSchemaAttribute raund = new XmlSchemaAttribute();
            raund.Name = "Raund";
            raund.SchemaTypeName = new XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");
            complexType.Attributes.Add(raund);

            //< xs:attribute name = ""turn"" type = ""xs: decimal"" use = ""required"" />
            XmlSchemaAttribute turn = new XmlSchemaAttribute();
            turn.Name = "Turn";
            turn.SchemaTypeName = new XmlQualifiedName("boolean", "http://www.w3.org/2001/XMLSchema");
            complexType.Attributes.Add(turn);

            //<xs:sequence>
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            complexType.Particle = sequence;

            //<xs:element name="Player">
            XmlSchemaElement elementPlayer = new XmlSchemaElement();
            sequence.Items.Add(elementPlayer);
            elementPlayer.Name = "Player";

            //<xs:element name = "Computer">
            XmlSchemaElement elementComputer = new XmlSchemaElement();
            sequence.Items.Add(elementComputer);
            elementComputer.Name = "Computer";

            //< xs:complexType>
            XmlSchemaComplexType complexTypePlayer = new XmlSchemaComplexType();
            elementPlayer.SchemaType = complexTypePlayer;

            //< xs:complexType>
            XmlSchemaComplexType complexTypeComputer = new XmlSchemaComplexType();
            elementComputer.SchemaType = complexTypeComputer;

            //<xs:attribute name = "Heroes" type="xs:string" use="required" />
            XmlSchemaAttribute heroes = new XmlSchemaAttribute();
            heroes.Name = "Heroes";
            heroes.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(heroes);
            complexTypeComputer.Attributes.Add(heroes);

            //<xs:attribute name = "DamagePerSecond" type="xs:decimal" use="required" />
            XmlSchemaAttribute damage = new XmlSchemaAttribute();
            damage.Name = "DamagePerSecond";
            damage.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(damage);
            complexTypeComputer.Attributes.Add(damage);

            //<xs:attribute name = "HeadshotDPS" type="xs:decimal" use="required" />
            XmlSchemaAttribute headshot = new XmlSchemaAttribute();
            headshot.Name = "HeadshotDPS";
            headshot.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(headshot);
            complexTypeComputer.Attributes.Add(headshot);

            //<xs:attribute name = "SingleShot" type="xs:decimal" use="required" />
            XmlSchemaAttribute singleshot = new XmlSchemaAttribute();
            singleshot.Name = "SingleShot";
            singleshot.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(singleshot);
            complexTypeComputer.Attributes.Add(singleshot);

            //<xs:attribute name = "Life" type="xs:decimal" use="required" />
            XmlSchemaAttribute life = new XmlSchemaAttribute();
            life.Name = "Life";
            life.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(life);
            complexTypeComputer.Attributes.Add(life);

            //<xs:attribute name = "Reload" type="xs:decimal" use="required" />
            XmlSchemaAttribute reload = new XmlSchemaAttribute();
            reload.Name = "Reload";
            reload.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(reload);
            complexTypeComputer.Attributes.Add(reload);

            //<xs:attribute name = "Picture" type="xs:decimal" use="required" />
            XmlSchemaAttribute picture = new XmlSchemaAttribute();
            picture.Name = "Picture";
            picture.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
            complexTypePlayer.Attributes.Add(picture);
            complexTypeComputer.Attributes.Add(picture);

            return schema;
        }

        /// <summary>
        /// Метод для сохранения информации о текущем ходе боя в xml-файл.
        /// </summary>
        /// <param name="pl">
        /// Юнит игрока.
        /// </param>
        /// <param name="comp">
        /// Юнит компьютера.
        /// </param>
        /// <param name="raund">
        /// Номер раунда.
        /// </param>
        /// <param name="turn">
        /// Очередь игрока?
        /// </param>
        /// <param name="path">
        /// Адрес, по которому сохранить файл.
        /// </param>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Если файла с заданным адресом path не существует.
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
        /// <remarks>
        /// Я сделала очень тупо и костыльно, да. Знаю.
        /// Мне стало лень делать нормально.
        /// Хех.
        /// </remarks>
        public static void SaveXML(Unit pl, Unit comp, int raund, bool turn, string path)
        {
            var text = String.Format(sablon,
                raund,
                turn ? "true" : "false",
                pl.Heroes, pl.DamagePerSecond.Replace(",", "."),
                pl.HeadshotDPS.Replace(",", "."),
                pl.SingleShot.Replace(",", "."),
                pl.Life.Replace(",", "."),
                pl.Reload.Replace(",", "."),
                pl.Picture, comp.Heroes,
                comp.DamagePerSecond.Replace(",", "."),
                comp.HeadshotDPS.Replace(",", "."),
                comp.SingleShot.Replace(",", "."),
                comp.Life.Replace(",", "."),
                comp.Reload.Replace(",", "."), comp.Picture);

            File.WriteAllText(path, text);
        }

        /// <summary>
        /// Мой костыль - шаблон для записи игры в xml.
        /// </summary>
        static string sablon = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            Environment.NewLine +
            "<Fight Raund = \"{0}\" Turn = \"{1}\">" +
            Environment.NewLine +
            "\t<Player Heroes = \"{2}\" " +
            "DamagePerSecond=\"{3}\" " +
            "HeadshotDPS = \"{4}\" " +
            "SingleShot=\"{5}\" Life = \"{6}\" " +
            "Reload=\"{7}\" Picture=\"{8}\"/>" +
            Environment.NewLine +
            "\t<Computer Heroes = \"{9}\" " +
            "DamagePerSecond=\"{10}\" " +
            "HeadshotDPS = \"{11}\" " +
            "SingleShot=\"{12}\" Life = \"{13}\" " +
            "Reload=\"{14}\" Picture=\"{15}\"/>" +
            Environment.NewLine +
            "</Fight>";
    }
}

//        public const string shema = @"<?xml version=""1.0"" encoding=""utf-8""?>
        //<xs:schema attributeFormDefault = ""unqualified"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
        //  <xs:element name = ""Fight"" >
        //    < xs:complexType>
        //      <xs:sequence>
        //        <xs:element name = ""Player"" >
        //          < xs:complexType>
        //            <xs:attribute name = ""Heroes"" type=""xs:string"" use=""required"" />
        //            <xs:attribute name = ""DamagePerSecond"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""HeadshotDPS"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""SingleShot"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Life"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Reload"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Picture"" type=""xs:decimal"" use=""required"" />
        //          </xs:complexType>
        //        </xs:element>
        //        <xs:element name = ""Computer"" >
        //          < xs:complexType>
        //            <xs:attribute name = ""Heroes"" type=""xs:string"" use=""required"" />
        //            <xs:attribute name = ""DamagePerSecond"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""HeadshotDPS"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""SingleShot"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Life"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Reload"" type=""xs:decimal"" use=""required"" />
        //            <xs:attribute name = ""Picture"" type=""xs:decimal"" use=""required"" />
        //          </xs:complexType>
        //        </xs:element>
        //      </xs:sequence>
        //      <xs:attribute name = ""raund"" type=""xs:decimal"" use=""required"" />
        //      <xs:attribute name = ""turn"" type=""xs:decimal"" use=""required"" />
        //    </xs:complexType>
        //  </xs:element>
        //</xs:schema>";