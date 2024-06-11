using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubtitleEdit
{
    public partial class DictAddForm : Form
    {
        public DictItem Item { get; private set; }
        public DictAddForm()
        {
            InitializeComponent();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Item = new DictItem() { Src = txtSrc.Text, Dst = txtDst.Text, Info = txtInfo.Text };
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void DictAddForm_Load(object sender, EventArgs e)
        {
            this.txtSrc.Clear();
            this.txtDst.Clear();
            this.txtInfo.Clear();
        }
    }
}
