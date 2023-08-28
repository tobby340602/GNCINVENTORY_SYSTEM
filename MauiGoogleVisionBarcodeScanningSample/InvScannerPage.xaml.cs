using BarcodeScanner.Mobile;
using MauiGoogleVisionBarcodeScanningSample.Models;
using Newtonsoft.Json;


namespace MauiGoogleVisionBarcodeScanningSample
{
    public partial class InvScannerPage : ContentPage
    {
        int scanType;
        public InvScannerPage(int id)
        {
            //BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);

            InitializeComponent();
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
            scanType = id;
        }

        public static string BaseAddress =
    DeviceInfo.Platform == DevicePlatform.Android ? "https://9jxch27b-7131.use.devtunnels.ms" : "https://9jxch27b-7131.use.devtunnels.ms";//"https://10.1.7.7"; 
        public static string InvUpdate = $"{BaseAddress}/api/InventoryUpdater/";

        [Obsolete]
        private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += obj[i].DisplayValue;
            }

            Dispatcher.Dispatch(async () =>
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient(handler);
                if(scanType == 0 || scanType == 2) 
                {
                    // 0 = Inventory Usage?
                    // 2 = Inventory Transfer

                    var response = await client.GetStringAsync("https://9jxch27b-7131.use.devtunnels.ms/api/InventoryUpdater/" + result);
                    var homeData = JsonConvert.DeserializeObject<List<InventoryItem>>(response);

                    var InvPrtNumber = homeData.Where(i => i.prtnum01.Trim() == result).Take(1).ToList();
                    if (InvPrtNumber.Count() > 0)
                    {
                        await DisplayAlert("Alert", InvPrtNumber[0].prtnum01 + " Location:" +
                                              InvPrtNumber[0].delstk01, "Ok");
                        if(scanType == 0)
                            await Navigation.PushAsync(new InvUpdatePage(homeData));
                        else
                            await Navigation.PushAsync(new TransferStk(homeData));
                        MessagingCenter.Unsubscribe<object, string>(this, "InvPrtNumber");// "InvUpdaterScanner");

                    }
                    else
                    {
                        await DisplayAlert("Alert", homeData[0].prtnum01 + " Location:" +
                                              homeData[0].delstk01, "Ok");
                        await DisplayAlert("Alert", "No order found", "Ok");
                    }

                }
                else
                {
                    //RECEIVE STOCK

                    string URLString = @"https://9jxch27b-7131.use.devtunnels.ms/api/InventoryUsage/3/" + result;

                    var response = await client.GetStringAsync("https://9jxch27b-7131.use.devtunnels.ms/api/InventoryUsage/3/" + result);

                    //var response = await client.GetStringAsync("https://9jxch27b-7131.use.devtunnels.ms/api/InventoryUsage/3/" + result);

                    var homeData = JsonConvert.DeserializeObject<List<POInfItem>>(response);
                    if (homeData.Count() > 0)
                    {
                        await DisplayAlert("Alert","Success", "Ok");
                        await Navigation.PushAsync(new MainPage(homeData));
                        //MessagingCenter.Unsubscribe<object, string>(this, "InvPrtNumber");// "InvUpdaterScanner");

                    }
                    else
                    {
                        await DisplayAlert("Alert", "No order found", "Ok");
                    }
                }

            });
        }
    }
}