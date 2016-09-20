using System;
namespace RoutingSimpleSample.ViewModels
{
    public enum MenuItemEnum
    {
        Option1,
        Option2,
        Option3
    }

    public class MenuCellViewModel : ViewModelBase
    {
        string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public MenuItemEnum MenuItem
        {
            get;
            set;
        }

        public string Icon
        {
            get
            {
                switch (MenuItem)
                {
                    case MenuItemEnum.Option1:
                        return "\U0000F218";
                    case MenuItemEnum.Option2:
                        return "\U0000F017";
                    case MenuItemEnum.Option3:
                        return "\U0000F074";
                }

                return "";
            }
        }
    }
}
