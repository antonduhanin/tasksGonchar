using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScroll
{
    public partial class UserControl1: UserControl
    {
        private int m_min=int.MinValue;
        private int m_max=int.MaxValue;
        private int m_current=0;
        public int Min
        {
            get
            { return m_min; }
            set
            { m_min = value; }
        }
        public int Max
        {
            get
            { return m_max; }
            set
            {
                m_max = value;
            }
        }
        public int Current
        {
            get
            {
                return m_current;
            }
            set
            {
                if ((value > m_max) || (value < m_min))
                {
                    throw new ArgumentOutOfRangeException("Current");
                }
                m_current = value;
                textBox1.Text = m_current.ToString();
            }
        } 
        public UserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                try
                {
                    Current -= 1;
                }
                catch
                {

                }
            }else if(e.Type==ScrollEventType.SmallDecrement){
                Current+=1;
            }

        }
    }
}
