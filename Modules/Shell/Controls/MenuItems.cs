using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkiChair.Shell.Controls
{
    public class MenuItems : BulletedList
    {
        /// <summary>
        /// Override Items collection to force PersistenceMode.InnerProperty. This will cause the control to
        /// wrap the ListItems inside of an &lt;Items&gt; tag which the Visual Studio designer will validate.
        /// If you don't do this, the designer will complain that the "Element 'ListItem' is not a known element."
        /// </summary>
        [Category("Default")]
        [DefaultValue("")]
        [MergableProperty(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public override System.Web.UI.WebControls.ListItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Enabled)
            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
                String rendered;

                base.Render(htmlWriter);

                rendered = Regex.Replace(sb.ToString(), "(?<!&lt;)&lt;(?!&lt;)", "<");
                rendered = Regex.Replace(rendered, "(?<!&gt;)&gt;(?!&gt;)", ">");
                rendered = Regex.Replace(rendered, "(?<!&quot;)&quot;(?!&quot;)", "\"");

                rendered = rendered.Replace("&lt;&lt;", "&lt;")
                    .Replace("&gt;&gt;", "&gt;")
                    .Replace("&quot;&quot;", "&quot;");

                writer.Write(rendered);
            }
            else
            {
                base.Render(writer);
            }

        }
    }
}
