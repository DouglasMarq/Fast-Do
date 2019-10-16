using System;
using System.Collections.Generic;
using System.Text;

namespace Fast_Do.Models
{
    public enum MenuItemType
    {
        Browse,
        Favorite,
        About,
        Logout,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
