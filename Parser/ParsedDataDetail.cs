namespace Parser
{
    public class ParsedDataDetail
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
        
        public string QuarryType { get; set; }
        public string RouteType { get; set; }
        public string NamespaceUrl { get; set; }
        public string InformationFormatUrl { get; set; }
        public string LinkToManual { get; set; }
    }
}