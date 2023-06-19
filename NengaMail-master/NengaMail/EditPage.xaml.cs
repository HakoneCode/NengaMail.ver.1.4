using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NengaMail
{
    public partial class EditPage : Page
    {
        // 共有データをフィールドに持つ
        private MainWindow.SharedData sharedData;

        public EditPage(MainWindow.SharedData sharedData)
        {
            InitializeComponent();

            // 共有データをフィールドに設定
            this.sharedData = sharedData;

            // 共有データから選択された画像を表示
            if (sharedData.SelectedImagePath != null)
            {
                BitmapImage selectedBitmapImage = new BitmapImage(new Uri(sharedData.SelectedImagePath, UriKind.RelativeOrAbsolute));
                SelectedImage.Source = selectedBitmapImage;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // 入力内容を共有データに保存
            sharedData.MailTitle = TitleField.Text;
            sharedData.Comment = CommentField.Text;

            // CheckWindowを表示
            CheckWindow checkWindow = new CheckWindow(sharedData);
            checkWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // AddressPageに戻る
            // 共有データを引数に追加
            AddressPage addressPage = new AddressPage(sharedData);
            NavigationService?.Navigate(addressPage);
        }
    }
}
