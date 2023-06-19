using System;
using System.Windows;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NengaMail
{

    public class SendMailHelper
    {
        public static void SendMail(string address, string cc, string bcc, string title, string comment, string imagePath)
        {
            try
            {
                // Outlook アプリケーションのインスタンスを作成
                Outlook.Application outlookApp = new Outlook.Application();

                // 新しいメールアイテムを作成
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                // 宛先、CC、BCC を設定
                mailItem.To = address;
                mailItem.CC = cc;
                mailItem.BCC = bcc;

                // メールタイトルを設定
                mailItem.Subject = title;

                // メール本文を設定（HTML 形式）
                string body = $"<html><body><p>{comment}</p><img src=\"{imagePath}\" /></body></html>";
                mailItem.HTMLBody = body;

                // メールを表示して送信
                mailItem.Display(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("メールの送信中にエラーが発生しました: " + ex.Message);
            }
        }
    }
}
