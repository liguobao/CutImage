using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace CutImage
{
    public partial class CutImg : Form
    {
        public CutImg()
        {
            InitializeComponent();
            cbbCutLineColor.SelectedIndex = 0;
        }

        delegate void myDelegateHandler(string txtPath);

        public static string soursepath = "";
        int ColorLineType = 0;
        int CutImgSumNumber = 0;



        /// <summary>
        /// 切图
        /// </summary>
        /// <param name="img">Image文件。</param>
        /// <param name="savepath">保存路径。</param>
        /// <param name="width">宽。</param>
        /// <param name="height">高</param>
        protected bool CutImage(Image img, string savepath, int width, int starH,int endH)
        {
            if (width > img.Width || endH > img.Height)
            {
                return false;
            }

            try
            {
                Bitmap newBitmap = new Bitmap(width, endH - starH);
                Bitmap oldBitmap = new Bitmap(img);
                Color pixel;
                for (int i = 0; i < width; i++)
                    for (int j = starH, k = 0; j < endH; j++, k++)
                    {
                        pixel = oldBitmap.GetPixel(i, j);

                        newBitmap.SetPixel(i, k, pixel);
                    }
                newBitmap.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                newBitmap.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        protected bool CutImageByW(Image img, string savepath, int H, int starW, int endW)
        {
            if (endW > img.Width || H > img.Height)
            {
                return false;
            }

            try
            {
                Bitmap newBitmap = new Bitmap(endW - starW, H);
                Bitmap oldBitmap = new Bitmap(img);
                Color pixel;
                for (int j = 0; j < H; j++)
                   for (int i = starW, k = 0; i < endW; i++,k++)
                    {
                        pixel = oldBitmap.GetPixel(i, j);
                        newBitmap.SetPixel(k, j, pixel);
                    }
                newBitmap.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                newBitmap.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 检查白色分割线。
        /// </summary>
        /// <param name="ls">颜色集合，list</param>
        /// <param name="threshold">色差参数</param>
        /// <returns></returns>
        protected bool CheckColorWhiteLine(List<Color> ls, int threshold)
        {
            int sum = 0;
            for (int i = 1; i < ls.Count;i++ )//计算本集合内所有像素点色差，A的值为255，RGB分别为色彩值
            {
               sum = sum + (ls[i].A - ls[i].B) + (ls[i].A - ls[i].G) + (ls[i].A - ls[i].R);
            }

            if (sum > ls.Count * threshold)//参数 * 总和
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        protected bool CheckColorBlackLine(List<Color> ls, int threshold)
        {
            int sum = 0;
            for (int i = 1; i < ls.Count; i++)
            {
                sum = sum + (ls[i].B) + (ls[i].G) + (ls[i].R);
            }

            if (sum > ls.Count * threshold)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            if(txtSoursePath.Text=="")
            {
                MessageBox.Show("请选择文件！");
                return;
            }
            if(txtSavePath.Text=="")
            {
                MessageBox.Show("请选择图片切割好之后的保存位置！");
                return;
            }

            //
            DirectoryInfo mydir = new DirectoryInfo(txtSavePath.Text);
            if (!mydir.Exists)
            {
                mydir.Create();
            }
            if(!File.Exists(txtSoursePath.Text))
            {
                MessageBox.Show("文件不存在，请重新选择！");
                return;
            }

            bgwCutImage.RunWorkerAsync();

            btnStar.Enabled = false;
            cbbCutLineColor.Enabled = false;
            rdbH.Enabled = false;
            rdbW.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            txtSavePath.Text = path.SelectedPath +"\\";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = ".\\download";
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*|图片(jpg)|*.jpg|图片(png)|*.png|图片(gif)|*.gif";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                txtSoursePath.Text = fileDialog.FileName;
            }
        }

        private void bgwCutImage_DoWork(object sender, DoWorkEventArgs e)
        {
            #region  初始化

            int pro = 0, piecewise= 0,coefficient=100;
            coefficient = (int)nudCoefficient.Value;

            Image img = Image.FromFile(txtSoursePath.Text);
            int imgH = 0;
            int imgW = 0;

            bool blWH = false;
            if(rdbW.Checked) //横向选中
            {
                imgH = img.Height;
                imgW = img.Width;
                blWH = false;
            }

            if (rdbH.Checked) //竖向选中
            {
                imgH = img.Width;
                imgW = img.Height;
                blWH = true;
            }

            

            Bitmap bmp = new Bitmap(img);
            int i = 1, j = 0;
            List<Int32> li = new List<Int32>();

            piecewise = imgH / 50;

            li.Add(0);

            #endregion

            #region 搜索分割线

            for (; i < imgH; i++)
            {
                List<Color> lcolor = new List<System.Drawing.Color>(imgW);
                for (j = 0; j < imgW; j++)
                {
                    Color cl = new Color();
                    if (!blWH) 
                        cl = bmp.GetPixel(j, i);//竖向读取
                    else cl = bmp.GetPixel(i,j);//横向读取
                  
                    lcolor.Add(cl);
                }

               if (ColorLineType == 0)//白色分割线
                {
                    if (CheckColorWhiteLine(lcolor, coefficient))
                    {
                       // LineColor.CheckColor(lcolor);
                        li.Add(i);
                    }
                }
                else if (ColorLineType == 1) //黑色分割线
                {
                    if (CheckColorBlackLine(lcolor, coefficient))
                    {
                       // LineColor.CheckLineColor(lcolor,false);
                        li.Add(i);
                    }

                }



                
                if (i % piecewise == 0)
                {
                    pro = i / piecewise;
                    bgwCutImage.ReportProgress(pro);
                }

                if (bgwCutImage.CancellationPending)//取消进程
                {
                    e.Cancel = true;
                    return;
                }

            }
           
            li.Add(imgH);
            #endregion

            #region  切图
          

            pro = 50;
            bgwCutImage.ReportProgress(pro);
            piecewise = li.Count / 50;
            if (piecewise==0)
            {
                piecewise = 1;
            }

            for (i = 0, j = 0; i < li.Count - 1; i++)
            {
                if (i % piecewise == 0)
                {
                    pro = (Int32)(i / piecewise);
                    pro = pro + 50;
                    if (pro >= 100)
                    {
                        pro = 99;
                    }
                    if(i==li.Count-1)
                    {
                        pro = 100;
                    }

                    bgwCutImage.ReportProgress(pro);
                   
                }
                int width = img.Width;

                if (!blWH) width = img.Width;//竖向设置高度
                else width = img.Height;//横向设置高度
                      
                int star = li[i];
                int end = li[i + 1];
                if (end - star <100)
                {
                   // li[i + 1] = li[i];
                    continue;
                }
                j++;
                CutImgSumNumber = j;
                if (!blWH)
                {
                    CutImage(img, txtSavePath.Text + j + ".jpg", width, star, end);
                }
                else
                {
                    
                    CutImageByW(img, txtSavePath.Text + j + ".jpg", width, star, end);

                }

                if (ColorLineType == 1)
                {
                    CutImageBlackLine.CutBlackLine(txtSavePath.Text + j + ".jpg");//纵向再次切图。
                  
                }
                if(ColorLineType ==0)
                {
                    CutImgWhiteLine.CutWhiteLine(txtSavePath.Text + j + ".jpg");//纵向再次切图。
                }


                if (bgwCutImage.CancellationPending)//取消进程
                {
                    e.Cancel = true;
                    return;
                }
            }
            img.Dispose();

            #endregion
            bgwCutImage.ReportProgress(100);
           
        }

        private void bgwCutImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbCutImg.Value = e.ProgressPercentage;
            lblCut.Text = e.ProgressPercentage + "%";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgwCutImage.CancelAsync();
            
        }

        private void bgwCutImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("取消成功！");
                btnStar.Enabled = true;
            }
            else
            {
               

                MessageBox.Show("已完成图片切制！");
                btnStar.Enabled = true;
                cbbCutLineColor.Enabled = true;
                rdbH.Enabled = true;
                rdbW.Enabled = true;
                //string openpath = txtSavePath.Text;
                //openpath = openpath.Remove(openpath.Length - 3, 2);
                //int len = openpath.Length;
                //System.Diagnostics.Process.Start("Explorer.exe", openpath);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            bgwDownload.RunWorkerAsync();//下载线程，执行函数在bgwDownload_DoWork
            btnDown.Enabled = false;
          
        }

        private void bgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            if (txtImgURL.Text != "")
            {
                try
                {
                    string url = txtImgURL.Text;
                    string type = url.Substring(url.Length - 4, 4);
                    DateTime dt = DateTime.Now;
                    DirectoryInfo mydir = new DirectoryInfo(".\\download\\");
                    if (!mydir.Exists)
                    {
                        mydir.Create();
                    }
                    Random rd = new Random();
                    int i = rd.Next(1, 1000);

                    string filepath = ".\\download\\" + dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + i.ToString() + type;
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();

                    Stream reader = response.GetResponseStream();
                    FileStream writer = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
                    byte[] buff = new byte[512];
                    int c = 0; //实际读取的字节数

                    Int32 piecewise = 0, count=0;

                    count = (Convert.ToInt32(response.ContentLength) / 512) / 100;//每1%要写的次数。
                    piecewise = (Convert.ToInt32(response.ContentLength) / 512);
                    int pre = 0;
                    i = 0;
                    while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                    {
                        
                        writer.Write(buff, 0, c);
                        if (piecewise % count == 0)
                        {
                            pre++;
                        }
                        if (pre >=100)
                        {
                            pre = 99;
                        }
                        piecewise = piecewise - 1;
                        bgwDownload.ReportProgress(pre);
                    }

                    bgwDownload.ReportProgress(100);

                    writer.Close();
                    writer.Dispose();
                    reader.Close();
                    reader.Dispose();
                    response.Close();
                    soursepath = filepath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("图片URL无效！" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("图片URL不能为空！");
            }

        }

        private void bgwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbDownload.Value = e.ProgressPercentage;
            lblDown.Text = e.ProgressPercentage.ToString() + "%";

        }



        protected  void ChangeSoursePath(string path)
        {
            txtSoursePath.Text = path;
        }

        private void bgwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("取消成功！");
            }
            else
            {

                myDelegateHandler changePath = new myDelegateHandler(ChangeSoursePath);
                changePath(soursepath);
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("马上处理?", "图片下载成功！", messButton, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    btnStar_Click(null, null);
                }
                btnDown.Enabled = true;
            }
        }

        private void cbbCutLineColor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbCutLineColor.SelectedIndex == 0)
            {
                ColorLineType = 0;
                nudCoefficient.Value = 100;
            }
            else if (cbbCutLineColor.SelectedIndex == 1)
            {
                ColorLineType = 1;
                nudCoefficient.Value = 30;
            }
        }

    }
}
