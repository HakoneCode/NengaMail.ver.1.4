using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace NengaMail
{
    public partial class SelectPage : Page
    {
        private ObservableCollection<string> imagePaths;

        public ObservableCollection<string> ImagePaths
        {
            get { return imagePaths; }
            set { imagePaths = value; }
        }

        // 共有データをフィールドに持つ
        private MainWindow.SharedData sharedData;

        // コンストラクタに共有データを追加
        public SelectPage(string folderPath, MainWindow.SharedData sharedData)
        {
            InitializeComponent();
            LoadImageFromFolder(folderPath);
            DataContext = this;

            // 共有データをフィールドに設定
            this.sharedData = sharedData;
        }

        private void LoadImageFromFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("指定されたフォルダが見つかりません。");
                return;
            }

            string[] imagePaths = Directory.GetFiles(folderPath, "*.jpg");

            if (imagePaths.Length > 0)
            {
                ObservableCollection<string> paths = new ObservableCollection<string>(imagePaths);
                ImagePaths = paths;
            }
            else
            {
                MessageBox.Show("指定されたフォルダ内に画像が存在しません。");
            }
        }

        private void SelectedImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image selectedImage = (Image)sender;
            string imagePath = (string)selectedImage.DataContext;

            // 選択した画像パスを共有データに設定
            sharedData.SelectedImagePath = imagePath;

            // AddressPage に遷移
            // 共有データを引数に追加
            AddressPage addressPage = new AddressPage(sharedData);
            NavigationService?.Navigate(addressPage);
        }
    }
}
