using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubtitleEdit
{
    public partial class GptDictForm : Form
    {
        private DictAddForm _addForm;
        public GptDictForm()
        {
            InitializeComponent();
            _addForm = new DictAddForm();
            this.listView1.Columns[2].Width = this.listView1.Width - 244;
        }

        private void GptDictForm_Load(object sender, EventArgs e)
        {

        }

        private void mAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void mAdd_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            _addForm.StartPosition = FormStartPosition.CenterParent;
            //_addForm.Location = new Point(me.X, me.Y);
            DialogResult result = _addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddItem(_addForm.Item);
            }
        }
        private void AddItem(DictItem item)
        {
            var viewItem = new ListViewItem(item.ToArray());
            viewItem.Name = item.GetKey();
            viewItem.Tag = item.GetTag();
            this.listView1.Items.Add(viewItem);
        }

        private void mDel_Click(object sender, EventArgs e)
        {
            List<string> keys = new List<string>();
            foreach (int index in listView1.SelectedIndices)
            {
                keys.Add(listView1.Items[index].Name);
            }
            listView1.BeginUpdate();
            foreach (var key in keys)
            {
                listView1.Items.RemoveByKey(key);
            }
            listView1.EndUpdate();


        }

        private void mClean_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.EndUpdate();
        }

        private void mLoad_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                List<DictItem> items = new List<DictItem>();
                using (TextReader tr = new StreamReader(file))
                {
                    string line = tr.ReadLine();
                    while(true)
                    {
                        line = tr.ReadLine();
                        if(line== null) break;
                        var ss = line.Trim().Split(new char[] {','},StringSplitOptions.None);
                        if (ss.Length < 2|| String.IsNullOrEmpty(ss[0]) || String.IsNullOrEmpty(ss[1]))
                        {
                            continue;
                        }
                        DictItem item = new DictItem();
                        item.Src = ss[0].Trim();
                        item.Dst = ss[1].Trim();
                        if (ss.Length > 2 && !string.IsNullOrEmpty(ss[2]))
                        {
                            item.Info = ss[2].Trim();
                        }
                        items.Add(item);
                    }
                }
                listView1.BeginUpdate();
                listView1.Items.Clear();
                foreach (var item in items)
                {
                    AddItem(item);
                }
                listView1.EndUpdate();
                    
            }
        }

        private void mSave_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = saveFileDialog1.FileName;
                using(TextWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine("Src, Dst, Info");
                    foreach(ListViewItem item in listView1.Items)
                    {
                        writer.WriteLine(item.Tag.ToString());
                    }
                }
            }
        }

        public string[] GetDict()
        {
            List<string> list = new List<string>();
            foreach(ListViewItem listItem in listView1.Items)
            {
                list.Add(listItem.Name);
            }
            return list.ToArray();
        }
    }
}
