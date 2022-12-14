using System.Drawing;

namespace VertexLocation
{
    class Imagen
    {
        private string imgPath;
        private Image img;
        private Bitmap imgBitmap;
        private Bitmap imgBitmapGame;
        private Bitmap imgBitmapOrig;
        private Graphics imgGpx;
        private Graphics imgGpxIdentif;
        private Graphics g;

        public Imagen(string imgPath)
        {
            this.ImgPath = imgPath;
            img = Image.FromFile(imgPath);
            imgBitmap = new Bitmap(imgPath);
            imgBitmapGame = null;
            imgBitmapOrig = new Bitmap(imgPath);
            imgGpx = Graphics.FromImage(imgBitmap);
            g = null;
        }

        public string ImgPath { get => imgPath; set => imgPath = value; }
        public Bitmap ImgBitmap { get => imgBitmap; set => imgBitmap = value; }
        public Bitmap ImgBitmapOrig { get => imgBitmapOrig; set => imgBitmapOrig = value; }
        public Graphics ImgGpx { get => imgGpx; set => imgGpx = value; }
        public Image Img { get => img; set => img = value; }
        public Graphics ImgGpxIdentif { get => imgGpxIdentif; set => imgGpxIdentif = value; }
        public Bitmap ImgBitmapGame { get => imgBitmapGame; set => imgBitmapGame = value; }
        public Graphics G { get => g; set => g = value; }
    }
}
