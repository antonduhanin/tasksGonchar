using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYCOMP
{
    public partial class WindowsControlLibrary : Control
    {
        private string m_mes;
        public string Message
        {
            get { return m_mes; }
            set { m_mes = value; }
        }

        public WindowsControlLibrary()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            pe.Graphics.FillEllipse(brush, 0, 0, 50, 50);
            base.OnPaint(pe);
           
        }

    }
}
