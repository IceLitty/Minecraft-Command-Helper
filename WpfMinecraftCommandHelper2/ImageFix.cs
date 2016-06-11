using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfMinecraftCommandHelper2
{
    class ImageFix
    {
        public BitmapSource ChangeColor(BitmapSource pic, byte[] srcBGRA, byte[] dstBGRA) 
        {
            return ChangeColor(pic, srcBGRA, dstBGRA, false);
        }

        /// <summary>
        /// 更改颜色。
        /// </summary>
        /// <param name="pic">原图</param>
        /// <param name="srcBGRA">要更改的像素，顺序为蓝绿红透明通道</param>
        /// <param name="dstBGRA">要更改为的像素，顺序为蓝绿红透明通道</param>
        /// <param name="isIgnoreAlpha">是否忽略Alpha通道的对照值</param>
        /// <returns>更改后的图片</returns>
        public BitmapSource ChangeColor(BitmapSource pic, byte[] srcBGRA, byte[] dstBGRA, bool isIgnoreAlpha)
        {
            int PixelWidth = pic.PixelWidth;
            int PixelHeight = pic.PixelHeight;
            byte[] picArray = new byte[PixelWidth * PixelHeight * 4];
            pic.CopyPixels(picArray, PixelWidth * 4, 0);
            if (picArray[0] == srcBGRA[0]) { picArray[0] = dstBGRA[0]; }
            if (picArray[1] == srcBGRA[1]) { picArray[1] = dstBGRA[1]; }
            if (picArray[2] == srcBGRA[2]) { picArray[2] = dstBGRA[2]; }
            if (picArray[3] == srcBGRA[3]) { picArray[3] = dstBGRA[3]; }
            for (int i = 4; i < picArray.Count(); i++)
            {
                if (i % 4 == 0)
                {
                    if (picArray[i] == srcBGRA[0]) { picArray[i] = dstBGRA[0]; }
                }
                if (i % 4 == 1)
                {
                    if (picArray[i] == srcBGRA[1]) { picArray[i] = dstBGRA[1]; }
                }
                if (i % 4 == 2)
                {
                    if (picArray[i] == srcBGRA[2]) { picArray[i] = dstBGRA[2]; }
                }
                if (i % 4 == 3)
                {
                    if (isIgnoreAlpha) { picArray[i] = dstBGRA[3]; }
                    else { if (picArray[i] == srcBGRA[3]) { picArray[i] = dstBGRA[3]; } }
                }
            }
            BitmapSource bpic = BitmapSource.Create(PixelWidth, PixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, picArray, PixelWidth * 4);
            return bpic;
        }

        /// <summary>
        /// 更改颜色，专门用于上行渐变和下行渐变。
        /// </summary>
        /// <param name="pic">原图</param>
        /// <param name="dstBGRA">要更改为的像素，顺序为蓝绿红透明通道</param>
        /// <returns></returns>
        public BitmapSource ChangeColor(BitmapSource pic, byte[] dstBGRA, bool isUp2Down)
        {
            int lineCount = 0;
            int PixelWidth = pic.PixelWidth;
            int PixelHeight = pic.PixelHeight;
            byte[] picArray = new byte[PixelWidth * PixelHeight * 4];
            pic.CopyPixels(picArray, PixelWidth * 4, 0);
            picArray[0] = dstBGRA[0];
            picArray[1] = dstBGRA[1];
            picArray[2] = dstBGRA[2];
            picArray[3] = dstBGRA[3];
            for (int i = 4; i < picArray.Count(); i++)
            {
                if (i % (4 * 20) == 0)
                {
                    lineCount++;
                }
                if (i % 4 == 0)
                {
                    int temp = dstBGRA[0];
                    if (isUp2Down) temp += lineCount * 3;
                    else temp -= lineCount * 3;
                    if (temp > 255) temp = 255; else if (temp < 0) temp = 0;
                    picArray[i] = (byte)temp;
                }
                if (i % 4 == 1)
                {
                    int temp = dstBGRA[1];
                    if (isUp2Down) temp += lineCount * 3;
                    else temp -= lineCount * 3;
                    if (temp > 255) temp = 255; else if (temp < 0) temp = 0;
                    picArray[i] = (byte)temp;
                }
                if (i % 4 == 2)
                {
                    int temp = dstBGRA[2];
                    if (isUp2Down) temp += lineCount * 3;
                    else temp -= lineCount * 3;
                    if (temp > 255) temp = 255; else if (temp < 0) temp = 0;
                    picArray[i] = (byte)temp;
                }
                if (i % 4 == 3)
                {
                    int temp = dstBGRA[3] - lineCount * 3;
                    if (temp > 255) temp = 255;
                    picArray[i] = (byte)temp;
                }
            }
            BitmapSource bpic = BitmapSource.Create(PixelWidth, PixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, picArray, PixelWidth * 4);
            return bpic;
        }

        /// <summary>
        /// 更改图片的大小
        /// </summary>
        /// <param name="pic">原图</param>
        /// <param name="multiple">缩放比例</param>
        /// <returns>更改后的图片</returns>
        public BitmapSource ChangeSize(BitmapSource pic, int multiple)
        {
            int PixelWidth = pic.PixelWidth;
            int PixelHeight = pic.PixelHeight;
            byte[] picArray = new byte[PixelWidth * PixelHeight * 4];
            pic.CopyPixels(picArray, PixelWidth * 4, 0);
            List<byte> everyWidthPixel = new List<byte>();
            for (int h = 0; h < PixelHeight; h++)
            {
                List<byte> eachWidthPixel = new List<byte>();
                for (int w = 0; w < PixelWidth; w++)
                {
                    eachWidthPixel.Add(picArray[(h * PixelWidth + w) * 4]);
                    eachWidthPixel.Add(picArray[(h * PixelWidth + w) * 4 + 1]);
                    eachWidthPixel.Add(picArray[(h * PixelWidth + w) * 4 + 2]);
                    eachWidthPixel.Add(picArray[(h * PixelWidth + w) * 4 + 3]);
                }
                List<byte> eachWidthPixelChanged = new List<byte>();
                for (int c = 0; c < PixelWidth; c++)
                {
                    for (int m = 0; m < multiple; m++)
                    {
                        eachWidthPixelChanged.Add(eachWidthPixel[c * 4]);
                        eachWidthPixelChanged.Add(eachWidthPixel[c * 4 + 1]);
                        eachWidthPixelChanged.Add(eachWidthPixel[c * 4 + 2]);
                        eachWidthPixelChanged.Add(eachWidthPixel[c * 4 + 3]);
                    }
                }
                for (int m = 0; m < multiple; m++)
                {
                    for (int i = 0; i < eachWidthPixelChanged.Count(); i++)
                    {
                        everyWidthPixel.Add(eachWidthPixelChanged[i]);
                    }
                }
            }
            byte[] fbta = new byte[PixelWidth * multiple * PixelHeight * multiple * 4];
            for (int c = 0; c < everyWidthPixel.Count(); c++)
            {
                fbta[c] = everyWidthPixel[c];
            }
            BitmapSource bpic = BitmapSource.Create(PixelWidth * multiple, PixelHeight * multiple, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, fbta, PixelWidth * multiple * 4);
            return bpic;
        }

        /// <summary>
        /// 合并图片
        /// </summary>
        /// <param name="srcPic">原图</param>
        /// <param name="dstPic">附加在原图上的图</param>
        /// <returns>更改后的图片</returns>
        public BitmapSource Merger(BitmapSource srcPic, BitmapSource dstPic) 
        {
            int srcPixelWidth = srcPic.PixelWidth;
            int srcPixelHeight = srcPic.PixelHeight;
            byte[] srcPicArray = new byte[srcPixelWidth * srcPixelHeight * 4];
            srcPic.CopyPixels(srcPicArray, srcPixelWidth * 4, 0);
            int dstPixelWidth = dstPic.PixelWidth;
            int dstPixelHeight = dstPic.PixelHeight;
            byte[] dstPicArray = new byte[dstPixelWidth * dstPixelHeight * 4];
            dstPic.CopyPixels(dstPicArray, dstPixelWidth * 4, 0);
            for (int c = 0; c < srcPicArray.Count(); c++)
            {
                if (c % 4 == 0)
                {
                    //c + 3 = 透明度通道
                    if (dstPicArray[c + 3] == 255)
                    {
                        //rgb将要替换到src
                        srcPicArray[c] = dstPicArray[c];
                        srcPicArray[c + 1] = dstPicArray[c + 1];
                        srcPicArray[c + 2] = dstPicArray[c + 2];
                        srcPicArray[c + 3] = dstPicArray[c + 3];
                    }
                    //else if (dstPicArray[c + 3] == 128)
                    else if (dstPicArray[c + 3] != 0)
                    {
                        //透明度通道半透明像素，加原值
                        srcPicArray[c] = (byte)((byte)(srcPicArray[c] / 2) + (byte)(dstPicArray[c] / 2));
                        srcPicArray[c + 1] = (byte)((byte)(srcPicArray[c + 1] / 2) + (byte)(dstPicArray[c + 1] / 2));
                        srcPicArray[c + 2] = (byte)((byte)(srcPicArray[c + 2] / 2) + (byte)(dstPicArray[c + 2] / 2));
                        srcPicArray[c + 3] = 255; //Alpha 通道
                    }
                }
            }
            BitmapSource bpic = BitmapSource.Create(srcPixelWidth, srcPixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, srcPicArray, srcPixelWidth * 4);
            return bpic;
        }

        public BitmapSource initBitmap(BitmapSource srcPic)
        {
            int srcPixelWidth = srcPic.PixelWidth;
            int srcPixelHeight = srcPic.PixelHeight;
            byte[] srcPicArray = new byte[srcPixelWidth * srcPixelHeight * 4];
            srcPic.CopyPixels(srcPicArray, srcPixelWidth * 4, 0);
            for (int c = 0; c < srcPicArray.Count(); c++)
            {
                if (c % 4 == 0)
                {
                    if (srcPicArray[c + 3] != 0)
                    {
                        //选中非透明色 bgra * * * !=0
                        if (srcPicArray[c] == 255 && srcPicArray[c + 1] == 255 && srcPicArray[c + 2] == 255 && srcPicArray[c + 3] == 255)
                        {
                            //选中纯白色 bgra 255 255 255 255
                            //替换为纯透明色 bgra 0 0 0 0
                            srcPicArray[c] = 0;
                            srcPicArray[c + 1] = 0;
                            srcPicArray[c + 2] = 0;
                            srcPicArray[c + 3] = 0;
                        }
                        else// if (srcPicArray[c + 3] != 255)
                        {
                            srcPicArray[c + 3] = (byte)(255 - srcPicArray[c]);
                        }
                    }
                }
            }
            BitmapSource bpic = BitmapSource.Create(srcPixelWidth, srcPixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, srcPicArray, srcPixelWidth * 4);
            return bpic;
        }

        public BitmapImage BitmapSource2BitmapImage(BitmapSource pic)
        {
            int PixelWidth = pic.PixelWidth;
            int PixelHeight = pic.PixelHeight;
            byte[] picArray = new byte[PixelWidth * PixelHeight * 4];
            pic.CopyPixels(picArray, PixelWidth * 4, 0);
            MemoryStream ms = new MemoryStream(picArray);
            BitmapImage bi = new BitmapImage();
            bi.StreamSource = ms;
            return bi;
        }

        /// <summary>
        /// 把BitmapImage格式的图片转换成BitmapSource。
        /// </summary>
        /// <param name="pic">原图</param>
        /// <returns>转换后的图片</returns>
        //public BitmapSource BitmapImage2BitmapSource(BitmapImage pic)
        //{
        //    int PixelWidth = pic.PixelWidth;
        //    int PixelHeight = pic.PixelHeight;
        //    byte[] PicArray = new byte[PixelWidth * PixelHeight * 4];
        //    pic.CopyPixels(PicArray, PixelWidth * 4, 0);
        //    BitmapSource bpic = BitmapSource.Create(PixelWidth, PixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, PicArray, PixelWidth * 4);
        //    //GC.Collect();
        //    return bpic;
        //}

        /// <summary>
        /// 把BitmapImage格式的图片转换成BitmapSource。
        /// </summary>
        /// <param name="pic">原图</param>
        /// <param name="darkTheme">是否为深色主题</param>
        /// <returns>转换后的图片</returns>
        public BitmapSource BitmapImage2BitmapSource(BitmapImage pic, bool darkTheme)
        {
            int PixelWidth = pic.PixelWidth;
            int PixelHeight = pic.PixelHeight;
            byte[] PicArray = new byte[PixelWidth * PixelHeight * 4];
            pic.CopyPixels(PicArray, PixelWidth * 4, 0);
            if (darkTheme)
            {
                //把255 255 255 0改为37 37 37 0以适应深色主题
                for (int i = 1; i <= PicArray.Count() / 4; i++)
                {
                    int b = PicArray[(i - 1) * 4 + 0];
                    int g = PicArray[(i - 1) * 4 + 1];
                    int r = PicArray[(i - 1) * 4 + 2];
                    int a = PicArray[(i - 1) * 4 + 3];
                    if (b == 255 && g == 255 && r == 255 && a == 0)
                    {
                        PicArray[(i - 1) * 4 + 0] = 37;
                        PicArray[(i - 1) * 4 + 1] = 37;
                        PicArray[(i - 1) * 4 + 2] = 37;
                    }
                }
                //继续
            }
            BitmapSource bpic = BitmapSource.Create(PixelWidth, PixelHeight, 96, 96, System.Windows.Media.PixelFormats.Bgr32, null, PicArray, PixelWidth * 4);
            //GC.Collect();
            return bpic;
        }

        /* API */
        /*
            BitmapSource bs1 = ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect4.png")));
            BitmapSource bs2 = ifx.ChangeColor(bs1, new byte[] { 27, 27, 27, 255 }, new byte[] { 133, 66, 59, 255 });
            BitmapSource bs0 = ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect2.png")));
            BitmapSource bs4 = ifx.ChangeColor(bs0, new byte[] { 27, 27, 27, 255 }, new byte[] { 240, 42, 73, 255 });
            BitmapSource bs3 = ifx.Merger(bs2, bs4);
            BitmapSource bs = ifx.ChangeSize(bs3, 8);
            picBox.Source = bs;
            picBox.Stretch = Stretch.None;
         */
    }
}
