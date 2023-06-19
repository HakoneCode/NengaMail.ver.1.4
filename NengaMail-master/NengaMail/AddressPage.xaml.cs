using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace NengaMail
{
    public partial class AddressPage : Page
    {
        // 共有データをフィールドに持つ
        private MainWindow.SharedData sharedData;

        public AddressPage(MainWindow.SharedData sharedData)
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
            sharedData.Address = AddressField.Text;
            sharedData.CC = CCField.Text;
            sharedData.BCC = BCCField.Text;

            // EditPageに遷移
            // 共有データを引数に追加
            EditPage editPage = new EditPage(sharedData);
            NavigationService?.Navigate(editPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // SelectPageに戻る
            // 共有データを引数に追加
            SelectPage selectPage = new SelectPage("", sharedData);
            NavigationService?.Navigate(selectPage);
        }
    }
}
