namespace Parser
{
    public class ParserSettings
    {
        /// <summary>
        /// Вид сведений: Федеральный уровень; Региональный уровень
        /// </summary>
        public InformationType InformationType { get; set; }
        /// <summary>
        /// Выбрать субъект (не обязательно)
        /// </summary>
        public string SubjectRussian { get; set; }
        /// <summary>
        /// Выбрать: Тестовая среда; Продуктивная среда
        /// </summary>
        public Environment Environment { get; set; }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Область применения
        /// </summary>
        public ScopeOfData ScopeOfData { get; set; }
        /// <summary>
        /// Наименование участника взаимодействия/Владелец: (пункт не обязателен)
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// Назначение/Наименование: (можно полностью, можно ключевым словом)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Версия
        /// </summary>
        public string Version { get; set; }
    }
}