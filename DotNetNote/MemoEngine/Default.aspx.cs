using DotNetNote.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new DotNetNoteContext())
            {
                var ideas = context.Ideas.OrderBy(i => i.Id).ToList();
                foreach (var idea in ideas)
                {
                    Response.Write($"{idea.Id} - {idea.Note}<br />");
                }
            }
        }
    }
}