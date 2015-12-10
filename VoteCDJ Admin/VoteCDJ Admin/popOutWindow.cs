using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteCDJ_Admin
{
    public partial class popOutWindow : Form
    {
        public popOutWindow()
        {
            InitializeComponent();
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            try
            {
                chart.Serializer.Load(mainWindow.chartSave);
            }
            catch
            {
            }
        }
    }
}
