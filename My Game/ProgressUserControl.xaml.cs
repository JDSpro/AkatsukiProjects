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
    /// Interaction logic for ProgressUserControl.xaml
    /// </summary>
    public partial class ProgressUserControl : UserControl
    {
        int currentStage = 1;

        public ProgressUserControl()
        {
            InitializeComponent();
        }

        public void NextStage()
        {
            if((progressStackPanel.Children.Count - currentStage) == 14)
            {
                
            }
            else
            {
                int pos1 = (progressStackPanel.Children.Count - currentStage) + 1;
                Grid grid1 = (Grid)progressStackPanel.Children[pos1];
                Label lbl1 = (Label)grid1.Children[0];
                lbl1.Style = FindResource("Normal") as Style;
                lbl1.Foreground = new SolidColorBrush(Colors.White);
                lbl1.FontSize = 15;
               
            }

            int pos = progressStackPanel.Children.Count - currentStage;
            Grid grid = (Grid)progressStackPanel.Children[pos];
            Label lbl = (Label)grid.Children[0];
            lbl.Style = FindResource("CustomLabel") as Style;
            lbl.FontSize = 20;
            lbl.FontWeight = FontWeights.Bold;

            currentStage++;
        }

        public void EndGame()
        {
            foreach(Grid grid in progressStackPanel.Children)
            {
               Label lbl = (Label)grid.Children[0];
                lbl.Style = FindResource("Normal") as Style;
                lbl.FontSize = 15;
                lbl.Foreground = new SolidColorBrush(Colors.Gold);
            }


            currentStage = 1;
        }
    }
}
