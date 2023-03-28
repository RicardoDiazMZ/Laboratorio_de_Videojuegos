using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;

namespace LYB
{
    public class Canvas
    {
        public Bitmap bmp;
        public Graphics g;
        public int Width, Height;
        public byte[] bits;
        int pixelFormatSize, stride;

        public Canvas(Size size)
        {
            Init(size);
        }

        private void Init(Size size)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;
            Width = size.Width;
            Height = size.Height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = size.Width * pixelFormatSize;              // total pixels (width) times ARGB (4)
            padding = (stride % 4);                         // PADD = move every pixel in bytes
            stride += padding == 0 ? 0 : 4 - padding;      // pad out to multiple of 4 byte Alpha, Red, Green, Blue
            bits = new byte[stride * size.Height];
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);     // TO LOCK THE MEMORY FOR GB
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bmp = new Bitmap(size.Width, size.Height, stride, format, bitPtr);

            g = Graphics.FromImage(bmp);
        }

        public void LessFast()
        {
            int div = 16;
            Parallel.For(0, bits.Length / div, i => // unrolling 
            {
                bits[(i * div) + 0] = 0;
                bits[(i * div) + 1] = 0;
                bits[(i * div) + 2] = 0;
                bits[(i * div) + 3] = 0;

                bits[(i * div) + 4] = 0;
                bits[(i * div) + 5] = 0;
                bits[(i * div) + 6] = 0;
                bits[(i * div) + 7] = 0;

                bits[(i * div) + 8] = 0;
                bits[(i * div) + 9] = 0;
                bits[(i * div) + 10] = 0;
                bits[(i * div) + 11] = 0;

                bits[(i * div) + 12] = 0;
                bits[(i * div) + 13] = 0;
                bits[(i * div) + 14] = 0;
                bits[(i * div) + 15] = 0;
            }
            );
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, (y,state) => // podría implementar unroll para agilizar y estabilizar                 
                {
                    byte* bits = PtrFirstPixel + (y* bitmapData.Stride);              
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)Blue;
                        bits[x + 1] = 0;// (byte)Green;
                        bits[x + 2] = 0;// (byte)Red;
                        bits[x + 3] = 0;// (byte)Red;
                    }
                }
                );
                
                bmp.UnlockBits(bitmapData);
            }
        }


    }
}
