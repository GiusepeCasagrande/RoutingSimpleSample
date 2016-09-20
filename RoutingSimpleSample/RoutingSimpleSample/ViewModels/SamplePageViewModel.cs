using System;
namespace RoutingSimpleSample.ViewModels
{
    public class SamplePageViewModel : ViewModelBase
    {
        MenuCellViewModel m_menuCell;
        public SamplePageViewModel(MenuCellViewModel menuCell)
        {
            m_menuCell = menuCell;
        }
        public string Name
        {
            get
            {
                return m_menuCell.Name;
            }
        }

        public string Icon
        {
            get
            {
                return m_menuCell.Icon;
            }
        }
    }
}
