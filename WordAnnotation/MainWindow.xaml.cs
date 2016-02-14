using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;

namespace WordAnnotation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _wordApp = new Word.Application();
        }

        private readonly Word.Application _wordApp;
        private BitmapImage _bitmapImage;

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName)) return;

                Object filefullname = dlg.FileName;
                _wordApp.Documents.Open(ref filefullname);
            }
            catch (Exception)
            {
            }
        }

        private void InsertAnnotation_OnClick(object sender, RoutedEventArgs e)
        {
            var model = GetDocumentAnnotationInfo();
            if (model == null) MessageBox.Show("ensure right input");
            InsertAnnotation(model);
        }

        private void InsertImage_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName)) return;
                ImagePath.Text = dlg.FileName;

                _bitmapImage = new BitmapImage(new Uri(dlg.FileName));
            }
            catch (Exception)
            {
            }
        }

        private void InsertAnnotation(DocumentAnnotationInfo model)
        {
            try
            {
                var wordDocument = _wordApp.ActiveDocument;

                //Focus current word page
                Object selectObj = (Object)(wordDocument.ActiveWindow.RangeFromPoint((int)model.LocationX, (int)model.LocationY));
                try
                {
                    ((Word.Range)selectObj).Select();
                }
                catch (Exception ex)
                {
                    try
                    {
                        ((Word.Shape)selectObj).Select();
                    }
                    catch (Exception e)
                    {
                    }
                }


                Object oMissing = System.Reflection.Missing.Value;
                Object linkToFile = false;
                Object saveWithDocument = true;

                float zoomPercentage = wordDocument.ActiveWindow.View.Zoom.Percentage / 100f;

                Word.Shape shape = wordDocument.Shapes.AddPicture(model.FilePath, ref linkToFile, ref saveWithDocument,
                     wordDocument.Application.PixelsToPoints(model.LocationX),
                     wordDocument.Application.PixelsToPoints(model.LocationY),
                     wordDocument.Application.PixelsToPoints(model.PicWidth) / zoomPercentage,
                     wordDocument.Application.PixelsToPoints(model.PicHeight) / zoomPercentage,
                     oMissing);

                shape.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoBringToFront);

            }
            catch (Exception ex)
            {
            }
        }

        private DocumentAnnotationInfo GetDocumentAnnotationInfo()
        {
            try
            {
                var model = new DocumentAnnotationInfo();
                model.FilePath = ImagePath.Text;
                model.LocationX = float.Parse(XPosition.Text);
                model.LocationY = float.Parse(YPosition.Text);
                model.PicHeight = (float)_bitmapImage.Height;
                model.PicWidth = (float)_bitmapImage.Width;
                return model;
            }
            catch (Exception)
            {

            }
            return null;
        }
    }

    public class DocumentAnnotationInfo
    {
        public string FilePath { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public float PicWidth { get; set; }
        public float PicHeight { get; set; }
    }
}
