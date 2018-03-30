using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//System.IO.Directory.GetFiles获取文件名使用
using System.Collections;//ArrayList使用

namespace FileStatistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.fbdChoose.ShowDialog();
                if (result == DialogResult.OK)//点击了确定
                {
                    this.lb.Items.Clear();
                    string pathname = fbdChoose.SelectedPath;//获取文件路径
                    MessageBox.Show("文件路径：\n" + pathname);
                    string[] AllFile = System.IO.Directory.GetFiles(pathname);
                    MessageBox.Show("文件数目：\n" + AllFile.Length);
                    ArrayList MyNeedFile = new ArrayList();
                    for (int i = 0; i < AllFile.Length; i++)
                    {
                        FileInfo fi = new FileInfo(AllFile[i]);
                        if (fi.Extension == ".txt")
                        {
                            MyNeedFile.Add(AllFile[i]);
                            this.lb.Items.Add(fi.Name);
                        }
                    }

                    #region 遍历所有子文件夹
                    string[] AllDir = System.IO.Directory.GetDirectories(pathname);
                    MessageBox.Show("文件夹数目：\n" + AllDir.Length);
                    for (int i = 0; i < AllDir.Length; i++)
                    {
                        //DirectoryInfo di = new DirectoryInfo(AllDir[i]);
                        string[] tempFile = System.IO.Directory.GetFiles(AllDir[i]);
                        for (int j = 0; j < tempFile.Length; j++)
                        {
                            FileInfo fi = new FileInfo(tempFile[j]);
                            if (fi.Extension == ".txt")
                            {
                                MyNeedFile.Add(tempFile[j]);
                                this.lb.Items.Add(fi.Name);
                            }
                        }
                    }
                    #endregion

                    MessageBox.Show("筛选后文件数目：\n" + MyNeedFile.Count);
                    for (int i = 0; i < MyNeedFile.Count; i++)
                    {
                        MessageBox.Show(MyNeedFile[i].ToString());
                    }
                    return;
                }
                else if (result == DialogResult.Cancel)//点击了取消
                {
                    MessageBox.Show("点击了取消");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现了异常\n异常信息:" + ex.Message + "\n");
                return;
            }
        }
    }
}
