namespace ATR.Common.Extensions.WebControls
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Provides extension methods to check box list components.
    /// </summary>
    public static class CheckBoxListExtension
    {
        /// <summary>
        /// Gets list of identifier corresponding to selected items in list of check box.
        /// </summary>
        /// <param name="component">Check box list component.</param>
        /// <returns>List of checked item identifiers.</returns>
        /// <exception cref="ArgumentNullException">Exception thrown if <paramref name="component"/> is null.</exception>
        /// <exception cref="ArgumentException">Exception thrown if value defined in check box list can't be returned as a long value.</exception>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Current class defined extension methods for CheckBoxList component.")]
        public static IList<long> GetSelectedItems(this CheckBoxList component)
        {
            List<long> result = new List<long>();

            #region Check parameters
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if (component.Items == null || component.Items.Count == 0)
            {
                return result;
            }
            #endregion Check parameters

            foreach (ListItem item in component.Items)
            {
                if (!item.Selected)
                {
                    continue;
                }

                long value;
                if (long.TryParse(item.Value, out value))
                {
                    result.Add(value);
                }
                else
                {
                    throw new ArgumentException("Value type of check box item is not a valid long value.", nameof(component));
                }
            }

            return result;
        }

        /// <summary>
        /// Sets selected items in check box list <paramref name="component"/> based on values defined in <paramref name="values"/> string.
        /// </summary>
        /// <param name="component">Check box list component.</param>
        /// <param name="values">List of identifiers of item to select defined as long values separated by semi comma.</param>
        /// <exception cref="ArgumentNullException">Exception thrown if <paramref name="component"/> is null.</exception>
        public static void SetSelectedItems(this CheckBoxList component, string values)
        {
            #region Check parameters
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if (component.Items == null || component.Items.Count == 0)
            {
                // Nothing to do.
                return;
            }

            if (string.IsNullOrWhiteSpace(values))
            {
                // Nothing to do.
                return;
            }
            #endregion Check parameters

            // Convert string list to array
            string[] array = values.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (array == null || array.Length == 0)
            {
                return;
            }

            // Convert array to list of long values
            IList<long> list = new List<long>();
            foreach (string item in array)
            {
                long value;
                if (long.TryParse(item, out value))
                {
                    list.Add(value);
                }
            }

            component.SetSelectedItems(list);
        }

        /// <summary>
        /// Sets selected items in check box list <paramref name="component"/> based on <paramref name="values"/> list.
        /// </summary>
        /// <param name="component">Check box list component.</param>
        /// <param name="values">List of values to select.</param>
        /// <exception cref="ArgumentNullException">Exception thrown if <paramref name="component"/> is null.</exception>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Current class defined extension methods for CheckBoxList component.")]
        public static void SetSelectedItems(this CheckBoxList component, IList<long> values)
        {
            #region Check parameters
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if (component.Items == null || component.Items.Count == 0)
            {
                // Nothing to do.
                return;
            }

            if (values == null || values.Count == 0)
            {
                // Nothing to do.
                return;
            }
            #endregion Check parameters

            foreach (ListItem item in component.Items)
            {
                long value;
                if (!long.TryParse(item.Value, out value))
                {
                    // Value can't be convert as a long value, item is unselected and skipped.
                    item.Selected = false;
                    continue;
                }

                item.Selected = values.Contains(value);
            }
        }
    }
}