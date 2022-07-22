namespace ATR.Common.Enumerations
{
    /// <summary>
    /// Defines action type in AD available values.
    /// </summary>
    public enum ActionTypeInAD
    {
        /// <summary>
        /// Add user.
        /// </summary>
        AddUser,

        /// <summary>
        /// Remove user.
        /// </summary>
        RemoveUser,

        /// <summary>
        /// Update user.
        /// </summary>
        UpdateUser,

        /// <summary>
        /// Update user group.
        /// </summary>
        UpdateUserGroup,

        /// <summary>
        /// Add a user user to an AD group.
        /// </summary>
        AddUserToGroup,

        /// <summary>
        /// Remove a user user from an AD group.
        /// </summary>
        RemoveUserFromGroup
    }
}
