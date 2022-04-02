namespace Parser
{
    public enum ScopeOfData
    {
        /// <summary>
        /// Межведомственное взаимодействие
        /// </summary>
        InterdepartmentalInteraction,
        /// <summary>
        /// Межведомственное взаимодействие/Базовый реестр;
        /// </summary>
        BaseRegister,
        /// <summary>
        /// Приём заявлений с ЕПГУ;
        /// </summary>
        AcceptanceOfApplicationsFromEPGU,
        /// <summary>
        /// Прием заявлений с ЕПГУ/МФЦ;)
        /// </summary>
        AcceptanceOfApplicationsFromEPGU_MFC
    }
}