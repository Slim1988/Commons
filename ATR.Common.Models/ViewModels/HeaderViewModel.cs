namespace ATR.Common.Models
{
    using System.Collections.Generic;
    using ATR.Common.Models.Requests;
    using Logging;

    /// <summary>
    /// Header View Model
    /// </summary>
    public class HeaderViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderViewModel"/> class.
        /// Set the list of Menus availables
        /// </summary>
        /// <param name="user">the user in session variable</param>
        public HeaderViewModel(UserSessionModel user)
        {
            // Get CRM Portal URL from DB (table Menus)
            this.MenuCRMPortal = DataModelRequests.GetMenusByCode("REQUEST_ATR");
            if (this.MenuCRMPortal == null)
            {
                this.MenuCRMPortal = new MENUS();
                LoggingService.Application.Error("The menu with code 'REQUEST_ATR' is not defined in ATRactive Referential (Menus table)");
            }

            if (user != null)
            {
                this.ListMenus = DataModelRequests.GetHeaderMenusAvailableByUserId(user.IdUser);
                this.ListMenusIcons = new List<MENUS>();

                // Add each menu icon to the list of menu icon, but add only the my users and the my company menu if the user is administrator
                List<MENUS> listMenuAsIcons = DataModelRequests.GetIconsMenusAvailable();
                foreach (MENUS icon in listMenuAsIcons)
                {
                    bool addIcon = false;

                    if (icon.CODE_MENU.Equals("MYUSERS") || icon.CODE_MENU.Equals("MYCOMPANY"))
                    {
                        if (user.IsAdministrator && user.IsEntityPublic)
                        {
                            addIcon = true;
                        }
                    }
                    else
                    {
                        addIcon = true;
                    }

                    if (addIcon)
                    {
                        switch (icon.CODE_MENU)
                        {
                            case "MYCOMPANY":
                                icon.CODE_MENU = "fa-building";
                                break;

                            case "MYPROFILE":
                                icon.CODE_MENU = "fa-user";
                                break;

                            case "MYUSERS":
                                icon.CODE_MENU = "fa-users";
                                break;

                            default:
                                break;
                        }

                        this.ListMenusIcons.Add(icon);
                    }
                }

                this.IsUserAdministror = user.IsAdministrator;
            }
            else
            {
                this.ListMenus = new List<MENUS>();
                this.ListMenusIcons = new List<MENUS>();
                this.IsUserAdministror = false;
            }
        }

        /// <summary>
        /// Gets or sets the list of menus
        /// </summary>
        public List<MENUS> ListMenus { get; set; }

        /// <summary>
        /// Gets or sets the list of icons menus
        /// </summary>
        public List<MENUS> ListMenusIcons { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is administrator of his entity
        /// </summary>
        public bool IsUserAdministror { get; set; }

        /// <summary>
        /// Gets or sets the menu for CRM Portal (Request ATR)
        /// </summary>
        public MENUS MenuCRMPortal { get; set; }
    }
}