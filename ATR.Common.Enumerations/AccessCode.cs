namespace ATR.Common.Enumerations
{
    public enum AccessCode
    {
        UserHasAccess = 1,
        UserNotValidated = -1,
        EntityNotValidated = -2,
        EntityTcuCgvNotChecked = -3,
        AdminTcuCgvNotChecked = -4,
        ApplicationAccessDeniedForUser = -5,
        ApplicationAccessDeniedForEntity = -6,
        UserNotFound = -7,
    }
}
