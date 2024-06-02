using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WF_Tool1
{
    public partial class Form1 : Form
    {
        private static bool _isRunning = false;

        private static Thread _thread;
        public Form1()
        {
            InitializeComponent();
            GetValue();
            toolTip1.SetToolTip(bf_btn, "把存档文件夹压缩保存到备份目录");
            toolTip1.SetToolTip(hf_btn, "使用备份目录的压缩文件恢复存档（存档文件夹正在运行时不可用！）");
            toolTip1.SetToolTip(txb1, @txb1.Text);
            toolTip1.SetToolTip(txb3, txb3.Text);
            toolTip1.SetToolTip(txb2, @txb2.Text);
        }

        /// <summary>
        /// 选择存档文件夹按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "选择存档文件夹";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = dialog.SelectedPath;
                }
                else
                {
                    return;
                }

                txb1.Text = folderPath;
                txb3.Text = folderPath.Substring(folderPath.LastIndexOf(@"\") + 1) + ".zip";

                toolTip1.SetToolTip(txb1, @txb1.Text);
                toolTip1.SetToolTip(txb3, txb3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选择备份目录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "选择备份目录";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = dialog.SelectedPath;
                }
                else
                {
                    return;
                }

                txb2.Text = folderPath;

                toolTip1.SetToolTip(txb2, @txb2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 存档备份按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bf_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txb1.Text) || string.IsNullOrEmpty(txb2.Text))
                {
                    MessageBox.Show("请选择完整！");
                    return;
                }
                if (!Directory.Exists(@txb1.Text))
                {
                    MessageBox.Show("存档文件夹不存在！");
                    return;
                }
                DialogResult result = MessageBox.Show("确认操作吗？", "确认对话框", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                if (CompressFolder(@txb1.Text, @txb2.Text, txb3.Text))
                {
                    MessageBox.Show("备份存档完成！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 恢复存档按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hf_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txb1.Text) || string.IsNullOrEmpty(txb2.Text))
                {
                    MessageBox.Show("请选择完整！");
                    return;
                }
                if (!File.Exists(@txb2.Text + @"\" + txb3.Text))
                {
                    MessageBox.Show("备份文件不存在！");
                    return;
                }
                DialogResult result = MessageBox.Show("确认操作吗？", "确认对话框", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                //删除存档文件夹
                if (Directory.Exists(@txb1.Text))
                { 
                    Directory.Delete(@txb1.Text, true);
                }

                //解压文件夹
                ZipFile.ExtractToDirectory(@txb2.Text + @"\" + txb3.Text, @txb1.Text.Substring(0, @txb1.Text.LastIndexOf(@"\")));

                //保存路径到json文件
                SetValue();

                MessageBox.Show("恢复存档完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        ///  自动备份按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zd_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txb1.Text) || string.IsNullOrEmpty(txb2.Text) || string.IsNullOrEmpty(t_txb.Text))
                {
                    MessageBox.Show("请选择完整！");
                    return;
                }
                if (!Directory.Exists(@txb1.Text))
                {
                    MessageBox.Show("存档文件夹不存在！");
                    return;
                }
                //判断t_txb.Text是否是正数
                if (!int.TryParse(t_txb.Text, out int interval))
                {
                    MessageBox.Show("请输入正整数！");
                    return;
                }
                if (interval <= 0)
                {
                    MessageBox.Show("请输入正整数！");
                    return;
                }
                DialogResult result = MessageBox.Show("确认操作吗？", "确认对话框", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                _isRunning = true;
                _thread = new Thread(() =>
                {
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            btn1.Enabled = false;
                            btn2.Enabled = false;
                            t_txb.Enabled = false;
                            bf_btn.Enabled = false;
                            hf_btn.Enabled = false;
                            zd_btn.Enabled = false;
                            tz_btn.Enabled = true;
                        }));
                        int time = 0;
                        while (_isRunning)
                        {
                            Invoke(new Action(() =>
                            {
                                if (CompressFolder(@txb1.Text, @txb2.Text, txb3.Text))
                                {
                                    t_lab.Text = "已自动备份" + ++time + "次";
                                }
                                else
                                {
                                    _thread.Interrupt();
                                }
                            }));
                            Thread.Sleep(interval * 1000);
                        }
                    }

                    catch (ThreadInterruptedException)
                    { }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Invoke(new Action(() =>
                        {
                            btn1.Enabled = true;
                            btn2.Enabled = true;
                            t_txb.Enabled = true;
                            bf_btn.Enabled = true;
                            hf_btn.Enabled = true;
                            zd_btn.Enabled = true;
                            tz_btn.Enabled = false;
                            MessageBox.Show("自动备份已停止！");
                        }));
                    }
                });
                _thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 停止自动备份按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tz_btn_Click(object sender, EventArgs e)
        {
            _isRunning = false;

            _thread.Interrupt();
        }

        /// <summary>
        /// 获取json文件路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetLoad(string fileName = "data.json")
        {
            // 获取当前执行的程序集
            var assembly = Assembly.GetExecutingAssembly();

            // 获取当前程序集所在的目录
            var assemblyLocation = assembly.Location;

            // 获取文件所在目录
            var directory = Path.GetDirectoryName(assemblyLocation);

            // 合并文件名获取完整文件路径
            var filePath = Path.Combine(directory, fileName);

            return filePath;
        }

        /// <summary>
        /// 保存路径到json文件
        /// </summary>
        public void SetValue()
        {
            //获取json文件路径
            string filePath = GetLoad();

            if (!File.Exists(filePath))
            {
                // 创建json文件 
                File.Create(filePath).Close();
            }

            JsModel jsModel = new JsModel
            {
                txb1 = txb1.Text,
                txb2 = txb2.Text,
                txb3 = txb3.Text
            };

            //序列化json
            string jsonString = JsonConvert.SerializeObject(jsModel);

            // 写入文件
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// 读取json文件       
        /// </summary>
        public void GetValue()
        {
            //获取json文件路径
            string filePath = GetLoad();

            if (!File.Exists(filePath))
            {
                // 创建json文件 
                File.Create(filePath).Close();
            }
            //读取json文件
            string jsonContent = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(jsonContent))
            {
                txb1.Text = "";
                txb2.Text = "";
                txb3.Text = "";
                return;
            }

            //反序列化json
            var jsModel = JsonConvert.DeserializeObject<JsModel>(jsonContent);

            //设置输入框的值
            txb1.Text = jsModel.txb1 ?? "";
            txb2.Text = jsModel.txb2 ?? "";
            txb3.Text = jsModel.txb3 ?? "";
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destinationFolder"></param>
        /// <param name="zipFileName"></param>
        public bool CompressFolder(string sourceFolder, string destinationFolder, string zipFileName)
        {
            // 确保存档文件夹存在
            if (!Directory.Exists(sourceFolder))
            {
                return false;
            }
            // 确保目标文件夹存在，不存在就创建文件夹
            Directory.CreateDirectory(destinationFolder);

            // 创建完整的压缩文件路径
            string zipFilePath = Path.Combine(destinationFolder, zipFileName);

            //删除原压缩文件
            File.Delete(zipFilePath);

            // 压缩文件夹
            ZipFile.CreateFromDirectory(sourceFolder, zipFilePath, CompressionLevel.Optimal, includeBaseDirectory: true);

            //保存路径到json文件
            SetValue();

            return true;

        }
    }
}
