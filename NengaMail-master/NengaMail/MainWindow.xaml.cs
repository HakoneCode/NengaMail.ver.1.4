using System.Windows;
using System.Windows.Controls;

namespace NengaMail
{
    public partial class MainWindow : Window
    {
        // 共有データをフィールドに持つ
        private SharedData sharedData;

        public MainWindow()
        {
            InitializeComponent();
            // 共有データのインスタンスを生成
            sharedData = new SharedData();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // ここにロード時の処理を書く
        }

        private void ContentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // ナビゲーションが完了したときに実行するコードをここに書く
            // （必要に応じて）
        }

        private void NavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTag = (string)((ListBoxItem)NavigationListBox.SelectedItem).Tag;

            // TODO: 追加したアイテムの画像フォルダパスを設定してください
            string folderPath = "";
            switch (selectedTag)
            {
                case "usagi":
                    folderPath = @"C:\Users\abrav\source\repos\NengaMail\NengaMail\bin\Debug\net6.0-windows\Images\usagi";
                    break;
                case "nezumi":
                    folderPath = @"C:\Images\nezumi";
                    break;
                case "tora":
                    folderPath = @"C:\Images\tora";
                    break;
                case "ushi":
                    // folderPath = "パスを設定";
                    break;
                case "tatsu":
                    // folderPath = "パスを設定";
                    break;
                case "hebi":
                    // folderPath = "パスを設定";
                    break;
                case "uma":
                    // folderPath = "パスを設定";
                    break;
                case "hitsuji":
                    // folderPath = "パスを設定";
                    break;
                case "saru":
                    // folderPath = "パスを設定";
                    break;
                case "tori":
                    // folderPath = "パスを設定";
                    break;
                case "inu":
                    // folderPath = "パスを設定";
                    break;
                case "inoshishi":
                    // folderPath = "パスを設定";
                    break;
                case "shochuumimai":
                    // folderPath = "パスを設定";
                    break;
                default:
                    break;
            }

            // 選択された動物に対応する SelectPage を表示するための画面遷移を行う
            // 共有データを引数に追加
            SelectPage selectPage = new SelectPage(folderPath, sharedData);
            ContentFrame.Content = selectPage;
        }

        public class SharedData
        {
            public string SelectedImagePath { get; set; }
            public string Address { get; set; }
            public string CC { get; set; }
            public string BCC { get; set; }
            public string MailTitle { get; set; }
            public string Comment { get; set; }
        }
    }
}
