using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_Game
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
            TextBlock txtBlock = labelQuestion.Content  as TextBlock;

            txtBlock.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris quis tempus lacus, id tincidunt tellus. Ut accumsan lorem non efficitur viverra. Aliquam erat volutpat. Mauris laoreet augue quis diam iaculis, gravida rutrum libero faucibus. Quisque pellentesque libero massa, eget congue odio semper ut. Sed cursus consequat augue vel consectetur. Integer a libero congue, efficitur est eu, semper arcu. Fusce ut massa laoreet, tincidunt nisi sit amet, dignissim elit. Donec dictum suscipit nisl a porta. Morbi suscipit mi sit amet diam ultrices, id volutpat felis lacinia. Sed placerat turpis ante, a dapibus odio porta at.";
        }
    }
}
