namespace SubtitleEdit
{
    partial class GptDictForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colSrc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mDel = new System.Windows.Forms.ToolStripMenuItem();
            this.mClean = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuList.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSrc,
            this.colDst,
            this.colInfo});
            this.listView1.ContextMenuStrip = this.menuList;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(684, 468);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colSrc
            // 
            this.colSrc.Text = "源";
            this.colSrc.Width = 120;
            // 
            // colDst
            // 
            this.colDst.Text = "目标";
            this.colDst.Width = 120;
            // 
            // colInfo
            // 
            this.colInfo.Text = "提示";
            // 
            // menuList
            // 
            this.menuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdd,
            this.mLoad,
            this.mSave,
            this.mDel,
            this.mClean});
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(125, 114);
            this.menuList.Text = "添加";
            // 
            // mAdd
            // 
            this.mAdd.Name = "mAdd";
            this.mAdd.Size = new System.Drawing.Size(180, 22);
            this.mAdd.Text = "添加";
            this.mAdd.Click += new System.EventHandler(this.mAdd_Click);
            this.mAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mAdd_MouseUp);
            // 
            // mLoad
            // 
            this.mLoad.Name = "mLoad";
            this.mLoad.Size = new System.Drawing.Size(180, 22);
            this.mLoad.Text = "加载";
            this.mLoad.Click += new System.EventHandler(this.mLoad_Click);
            // 
            // mSave
            // 
            this.mSave.Name = "mSave";
            this.mSave.Size = new System.Drawing.Size(180, 22);
            this.mSave.Text = "保存";
            this.mSave.Click += new System.EventHandler(this.mSave_Click);
            // 
            // mDel
            // 
            this.mDel.Name = "mDel";
            this.mDel.Size = new System.Drawing.Size(180, 22);
            this.mDel.Text = "删除行";
            this.mDel.Click += new System.EventHandler(this.mDel_Click);
            // 
            // mClean
            // 
            this.mClean.Name = "mClean";
            this.mClean.Size = new System.Drawing.Size(180, 22);
            this.mClean.Text = "清除全部";
            this.mClean.Click += new System.EventHandler(this.mClean_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "csv文件|*.csv|txt文件|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "csv文件|*.csv";
            // 
            // GptDictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 468);
            this.Controls.Add(this.listView1);
            this.Name = "GptDictForm";
            this.Text = "GptDictForm";
            this.Load += new System.EventHandler(this.GptDictForm_Load);
            this.menuList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colSrc;
        private System.Windows.Forms.ColumnHeader colDst;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.ContextMenuStrip menuList;
        private System.Windows.Forms.ToolStripMenuItem mAdd;
        private System.Windows.Forms.ToolStripMenuItem mLoad;
        private System.Windows.Forms.ToolStripMenuItem mSave;
        private System.Windows.Forms.ToolStripMenuItem mDel;
        private System.Windows.Forms.ToolStripMenuItem mClean;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}