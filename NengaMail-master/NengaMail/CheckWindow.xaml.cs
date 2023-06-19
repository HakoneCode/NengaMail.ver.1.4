using System;
using System.Windows;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace NengaMail
{
    public partial class CheckWindow : Window
    {
        // 共有データをフィールドに持つ
        private MainWindow.SharedData sharedData;

        public CheckWindow(MainWindow.SharedData sharedData)
        {
            InitializeComponent();

            // 共有データをフィールドに設定
            this.sharedData = sharedData;

            // 共有データから情報を取得して各フィールドに設定
            AddressField.Text = sharedData.Address;
            CCField.Text = sharedData.CC;
            BCCField.Text = sharedData.BCC;
            TitleField.Text = sharedData.MailTitle;
            CommentField.Text = sharedData.Comment;

            // 共有データから選択された画像を表示
            if (sharedData.SelectedImagePath != null)
            {
                BitmapImage selectedBitmapImage = new BitmapImage(new Uri(sharedData.SelectedImagePath, UriKind.RelativeOrAbsolute));
                SelectedImage.Source = selectedBitmapImage;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // CheckWindow を閉じる
            this.Close();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // 送信確認のアラートを表示
            var result = MessageBox.Show("メールを送信しますか？", "送信確認", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // 送信処理を実行
                SendMail();
            }
        }

        private void SendMail()
        {
            // メール送信の処理を記述
            // 共有データから情報を取得
            string address = sharedData.Address;
            string cc = sharedData.CC;
            string bcc = sharedData.BCC;
            string title = sharedData.MailTitle;
            string comment = sharedData.Comment;
            string imagePath = sharedData.SelectedImagePath; // 共有データから画像のパスを取得

            SendMailHelper.SendMail(address, cc, bcc, title, comment, imagePath);
        }
    }
}
