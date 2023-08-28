using Newtonsoft.Json;

namespace MauiGoogleVisionBarcodeScanningSample;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }



    private void BtnInvScan_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InvScannerPage(0));

    }

    private void BtnRecvStk_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InvScannerPage(1));
    }

    private void BtnTransStk_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InvScannerPage(2));
    }

    private void BtnPDF_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PrintLabelScreen(""));

    }
}