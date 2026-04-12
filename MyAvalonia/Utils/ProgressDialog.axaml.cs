using Avalonia.Controls;
using System;
using System.Threading.Tasks;

namespace MyAvalonia.Utils;

public partial class ProgressDialog : Window
{
    public ProgressDialog()
    {
        InitializeComponent();
    }

    public static ProgressDialog StartShowProgressDialog(Window owner, string title, string content)
    {
        var progressDialog = new ProgressDialog
        {
            CanResize = false,
            ShowInTaskbar = false
        };

        progressDialog.lblTitle.Content = title;
        progressDialog.txtContent.Text = content;

        progressDialog.Show(owner); // <-- NÃO bloqueia

        return progressDialog;
    }


    public static void CloseShowProgressDialog(ProgressDialog progressDialog)
    {
        progressDialog.Close();
    }

}