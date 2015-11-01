using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;

namespace CutImage
{
    class HSB
    {
        public float H;
        public float S;
        public float B;

        public HSB()
        {
            H = 0;
            S = 0;
            B = 0;
        }


        public HSB(Color cl)
        {
            H =cl.GetHue();
            B= cl.GetBrightness();
            S = cl.GetSaturation();
 
        }
 
    }


    class CutImageBlackLine
    {
       /// <summary>
       /// 根据黑色分割线纵向切图，同时切除无关线段。
       /// </summary>
       /// <param name="path">文件路径。</param>
       /// <returns>是否切图成功。</returns>
       public static bool CutBlackLine(string path)
        {
            bool bl = false;
            try
            {
                Image img = Image.FromFile(path);
                int imgH = 0;
                int imgW = 0;

                bool blWH = false;
                imgH = img.Width;
                imgW = img.Height;
                blWH = true;
                Bitmap bmp = new Bitmap(img);
                int i = 1, j = 0;
                List<Int32> li = new List<Int32>();

                li.Add(0);
                for (; i < imgH; i++)
                {
                    List<Color> lcolor = new List<System.Drawing.Color>(imgW);
                    for (j = 0; j < imgW; j++)
                    {
                        Color cl = new Color();
                        if (!blWH)
                            cl = bmp.GetPixel(j, i);
                        else cl = bmp.GetPixel(i, j);
                        lcolor.Add(cl);
                    }

                    if (CheckColorBlackLine(lcolor, 30))
                    {
                        li.Add(i);
                    }
                }

                li.Add(imgH);
                if (li.Count == 2)//原图无分割线
                {
                    return true;
                }

                for (i = 0, j = 0; i < li.Count - 1; i++)
                {
                    int width = img.Width;
                    if (!blWH) width = img.Width;
                    else width = img.Height;
                    int star = li[i];
                    int end = li[i + 1];
                    if (end - star < 100)
                    {
                        continue;
                    }
                    j++;
                    {
                        string savePath = path.Substring(0, path.Length - 4)+ "_"+j +".jpg";
                        CutImageByW(img, savePath, width, star, end);
                    }
                }
                try
                {
                    img.Dispose();
                    File.Delete(path);
                }
                catch(Exception ex)
                {

                }
              

                bl = true;
            }
           catch(Exception ex)
            {
                bl = false;
            }
           
           
            return bl;
        }
       protected static bool CutImageByW(Image img, string savepath, int H, int starW, int endW)
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
                   for (int i = starW, k = 0; i < endW; i++, k++)
                   {
                       pixel = oldBitmap.GetPixel(i, j);
                       newBitmap.SetPixel(k, j, pixel);
                   }
               newBitmap.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }

       }
       public static bool CheckColorBlackLine(List<Color> ls, int threshold)
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
    }


    class CutImgWhiteLine 
    {
        /// <summary>
        /// 根据白色分割线纵向切图，同时去除分割线。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns>是否切图成功。</returns>
        public static bool CutWhiteLine(string path)
        {
            bool bl = false;
            try
            {
                Image img = Image.FromFile(path);
                int imgH = 0;
                int imgW = 0;

                bool blWH = false;
                imgH = img.Width;
                imgW = img.Height;
                blWH = true;
                Bitmap bmp = new Bitmap(img);
                int i = 1, j = 0;
                List<Int32> li = new List<Int32>();

                li.Add(0);
                for (; i < imgH; i++)
                {
                    List<Color> lcolor = new List<System.Drawing.Color>(imgW);
                    for (j = 0; j < imgW; j++)
                    {
                        Color cl = new Color();
                        if (!blWH)
                            cl = bmp.GetPixel(j, i);
                        else cl = bmp.GetPixel(i, j);
                        lcolor.Add(cl);
                    }

                    if (CheckColorWhiteLine(lcolor, 100))
                    {
                        li.Add(i);
                    }
                }

                li.Add(imgH);
                if (li.Count==2)//原图无分割线
                {
                    return true;
                }

                for (i = 0, j = 0; i < li.Count - 1; i++)
                {
                    int width = img.Width;
                    if (!blWH) width = img.Width;
                    else width = img.Height;
                    int star = li[i];
                    int end = li[i + 1];
                    if (end - star < 100)
                    {
                        continue;
                    }
                    j++;
                    {
                        string savePath = path.Substring(0, path.Length - 4) + "_" + j + ".jpg";
                        CutImageByW(img, savePath, width, star, end);
                    }
                }
                try
                {
                    img.Dispose();
                    File.Delete(path);
                }
                catch (Exception ex)
                {

                }


                bl = true;
            }
            catch (Exception ex)
            {
                bl = false;
            }


            return bl;
        }
        protected static bool CutImageByW(Image img, string savepath, int H, int starW, int endW)
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
                    for (int i = starW, k = 0; i < endW; i++, k++)
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
        protected static bool CheckColorWhiteLine(List<Color> ls, int threshold)
        {
            int sum = 0;
            for (int i = 1; i < ls.Count; i++)
            {
                sum = sum + (ls[i].A - ls[i].B) + (ls[i].A - ls[i].G) + (ls[i].A - ls[i].R);
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

    }


    class LineColor
    {
       static public bool CheckColor(List< Color> lic)
        {
            int max_R = 0, max_G = 0, max_B = 0;
            for (int i = 0; i < lic.Count; i++)
            {
                if (lic[i].R > max_R) max_R = lic[i].R;
                if (lic[i].G> max_G) max_G = lic[i].G;
                if (lic[i].B > max_B) max_B = lic[i].B;

            }

            File.AppendAllText("D:\\Color.txt", max_R + " " + max_G + " " + max_B + "\r\n");

            return false;
 
        }


       static public bool CheckLineColor(List<Color> lic,bool BOrW)
       { 
             int max_R = 0, max_G = 0, max_B = 0;
             for (int i = 0; i < lic.Count; i++)
             {
                 if (lic[i].R > max_R) max_R = lic[i].R;
                 if (lic[i].G > max_G) max_G = lic[i].G;
                 if (lic[i].B > max_B) max_B = lic[i].B;
             }
             int max = max_B + max_G + max_R;
             if (BOrW)//白色
             {
                 if (max > 600)
                     return true;
                 else return false;
             }
             else
             {
                 if (max < 150)
                     return true;
                 else return false;
             }


       }

       static public List<HSB> Color2HSB(List<Color> lic)
        {
            List<HSB> lHSB = new List<HSB>();
            foreach(Color temp in lic)
            {
                HSB hsb = new HSB(temp);
                lHSB.Add(hsb);
            }

            return lHSB;


        }


    }
}
