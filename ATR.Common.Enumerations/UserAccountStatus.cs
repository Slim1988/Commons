namespace ATR.Common.Enumerations
{
    /// <summary>
    /// This enum is used to know the user's account status
    /// </summary>
    public enum UserAccountStatus
    {
        /// <summary>
        /// Case where the user's account cannot be found in AD, so can't know if the user's account is locked
        /// </summary>
        Unknown,

        /// <summary>
        /// The user's account is locked
        /// </summary>
        Locked,

        /// <summary>
        /// The user's account is unlocked
        /// </summary>
        Unlocked
    }
}
