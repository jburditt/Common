using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Common.Helpers
{
    public class ControlHelper
    {
        public static void Bind<T>(DropDownList control, ICollection<T> data, string text, string value) where T: class
        {
            var selectedValue = control.SelectedValue;
            control.SelectedValue = null;
            control.DataTextField = text;
            control.DataValueField = value;
            control.DataSource = data;
            control.DataBind();
            if (control.Items.FindByValue(selectedValue) != null)
                control.SelectedValue = selectedValue;
        }

        public static void Bind<T>(GridView control, ICollection<T> data) where T : class
        {
            control.DataSource = data;
            control.DataBind();
        }

        public static void Bind(Repeater control, IEnumerable data, string text, string value)
        {
            control.DataSource = data;
            control.DataBind();
        }
    }
}
