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
using System.Windows.Shapes;

namespace laba2
{
    /// <summary>
    /// Логика взаимодействия для InfThreadWindow.xaml
    /// </summary>
    public partial class InfThreadWindow : Window 
    {
        Threat threat;

        public InfThreadWindow(Threat threat)
        {
            InitializeComponent();
            ONe3.Text = threat.Id.ToString();
            ONe1.Text = threat.Name;
            ONe.Text = threat.Description;
            ONe2.Text = threat.SourceOfThreat;
            ONe4.Text = threat.ObjectOfInfluence;
            ONe5.Text = threat.IntegrityViolation;
            ONe6.Text = threat.Accessibility;
            ONe7.Text = threat.PrivacyViolation;
            
        }

       
    }
}
