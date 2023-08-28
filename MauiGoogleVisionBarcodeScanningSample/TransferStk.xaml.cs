using Newtonsoft.Json;
using System.Text;

namespace MauiGoogleVisionBarcodeScanningSample;

public partial class TransferStk : ContentPage
{
	public TransferStk()
	{
		InitializeComponent();
	}

    public List<InventoryItem> inventoryItems { get; set; }

    public TransferStk(List<InventoryItem> items)
    {
        InitializeComponent();
        inventoryItems = items;
        labelprtnum.Text = inventoryItems[0].prtnum01;
        labeldesc1.Text = inventoryItems[0].pmdes101;
        labeldesc2.Text = inventoryItems[0].pmdes201;
        labelqtyonh.Text = inventoryItems[0].onhand01.ToString();
    }


    private void onBtnPost_Clicked(object sender, EventArgs e)
    {
        int s1 = Convert.ToInt32(Editor1.Text);
        string s2 = Editor2.Text;
        string s3 = Editor3.Text;
        if (s1 == 0 || s2 == null || s3 == null)
        {
            DisplayAlert("Alert", "Input values!", "Ok");
            return;
        }

        if (inventoryItems == null || inventoryItems.Count < 0)
        {
            DisplayAlert("Alert", "No part information!", "Ok");
            return;
        }

        Dispatcher.Dispatch(async () =>
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient(handler);
            tnX_MAX_Transaction maxt = new tnX_MAX_Transaction()
            {
                typE_39 = "F",
                subtypE_39 = "P",
                prtnuM_39 = inventoryItems[0].prtnum01,
                issstK_39 = s3,
                rcvstK_39 = s2,
                tnxqtY_39 = s1,
                refdsC_39 = inventoryItems[0].pmdes101
            };
            TransR transRec = new TransR()
            {
                tM_Transaction = maxt
            };
          
            String json = JsonConvert.SerializeObject(transRec);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://9jxch27b-7131.use.devtunnels.ms/api/MAX_TransferStock/", content);
                if (response.IsSuccessStatusCode)
                    await DisplayAlert("Alert", "success!", "Ok");
                else
                    await DisplayAlert("Alert", "failed", "Ok");
            }
            catch (Exception e)
            {
                await DisplayAlert("Alert", "couldn't connet to server!", "Ok");
            }
        });
    }
}