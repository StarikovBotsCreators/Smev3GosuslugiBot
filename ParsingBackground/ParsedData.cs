using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingBackground
{
    internal class ParsedData
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Назначение
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Значение идентификатора
        /// </summary>
        /// 
        public string Identifier { get; set; }

        /// <summary>
        /// Область применения
        /// </summary>
        public string ScopeOfData { get; set; }

        /// <summary>
        /// Версия
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Версия МР
        /// </summary>
        public string MPVersion { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public string RegistrationDate { get; set; }

        /// <summary>
        /// Ссылка на страницу
        /// </summary>
        public string Link { get; set; }

    }
}
