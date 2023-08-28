using MauiGoogleVisionBarcodeScanningSample.Models;
using Newtonsoft.Json;
using System.Text;

namespace MauiGoogleVisionBarcodeScanningSample;

public partial class InvUpdatePage : ContentPage
{
	public InvUpdatePage()
	{
		InitializeComponent();
	}
 //   public List<InventoryItem> inventoryItems;
    public List<InventoryItem> inventoryItems { get; set; }

    public InvUpdatePage(List<InventoryItem> items)
    {
        InitializeComponent();
        inventoryItems = items;
        labelprtnum.Text = inventoryItems[0].prtnum01;
        labeldesc1.Text = inventoryItems[0].pmdes101;
        labeldesc2.Text = inventoryItems[0].pmdes201;
        labelqtyonh.Text = inventoryItems[0].onhand01.ToString();
    }

    private void onBtnUpdate_Clicked(object sender, EventArgs e)
    {
        string s1 = Editor1.Text;
        if (s1 == null)
        {
            DisplayAlert("Alert", "Input values!", "Ok");
            return;
        }

        if (inventoryItems == null || inventoryItems.Count < 0)
        {
            DisplayAlert("Alert", "No data!", "Ok");
            return;
        }


        Dispatcher.Dispatch(async () =>
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient(handler);
            usage_MAX_Transaction maxt = new usage_MAX_Transaction()
            {
                typE_39 = "F",
                subtypE_39 = "P",
                prtnuM_39 = inventoryItems[0].prtnum01,
                tnxqtY_39 = Convert.ToInt32(s1),
                issstK_39 = inventoryItems[0].delstk01,
                refdsC_39 = inventoryItems[0].pmdes101
            };
            InvUsage invUsage = new InvUsage()
            {
                uM_Transaction = maxt
            };
            
            String json = JsonConvert.SerializeObject(invUsage);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://10.1.7.7/api/MAX_InventoryUsage/", content);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alert", "Update success!", "Ok");
                }
                else
                    await DisplayAlert("Alert", "No response", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "couldn't connet to server!", "Ok");
            }
        });
    }
}