using System.Windows.Forms;
using EnumDescriptionExample.Classes;

namespace EnumDescriptionExample.Extensions
{
    public static class Extensions
    {
        
        public static (string text, Categories category) CurrentCategory(this ListControl source)
            => (source.Text, (Categories)source.SelectedValue);

    }
}