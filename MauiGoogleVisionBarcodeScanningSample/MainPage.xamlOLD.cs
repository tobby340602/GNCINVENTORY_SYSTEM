using BarcodeScanner.Mobile;
using MauiGoogleVisionBarcodeScanningSample.Models;
using Newtonsoft.Json;
using System.Text;

namespace MauiGoogleVisionBarcodeScanningSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);

            InitializeComponent();

            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        }

        List<POInfItem> poInfItems { get; set; }

        public MainPage(List<POInfItem> items)
        {
            InitializeComponent();
            poInfItems = items;
            PoListview.ItemsSource = poInfItems;
        }

        POInfItem orderLineItem;
        private async void onItemClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Question", "Close this line?", "Sure", "Cancel");
            if (answer)
            {
                ImageButton button = (ImageButton)sender;

                // Get the corresponding item from the list view
                orderLineItem = (POInfItem)button.BindingContext;
                var viewCell = (ViewCell)button.Parent.Parent.Parent;
                Editor editor = (Editor)viewCell.FindByName("MyEditor");

                string transferQtyValue = editor.Text; ;
                int value = Convert.ToInt32(transferQtyValue);

                pO_MAX_Transaction maxt = new pO_MAX_Transaction()
                {
                    typE_39 = "R",
                    subtypE_39 = "P",
                    ordnuM_39 = poInfItems[0].ordnum10,
                    linnuM_39 = poInfItems[0].linnum10,
                    delnuM_39 = poInfItems[0].delnum10,
                    tnxqtY_39 = value,
                    rcvstK_39 = "",
                    refdsC_39 = ""
                };
                ClosePo orderline = new ClosePo()
                {
                    poM_Transaction = maxt
                };
                postPOInf(orderline);

                // Do something with the item, such as removing it from the list

            }
        }


        private void onBtnClose_Clicked(object sender, EventArgs e)
        {

            if (poInfItems == null || poInfItems.Count < 0)
            {
                DisplayAlert("Alert", "No purchase order information!", "Ok");
                return;
            }
            List<ClosePo> listCPO = new List<ClosePo>();
            foreach (var poInfItem in poInfItems)
            {
                string value = "";
                var editor = PoListview.FindByName<Editor>("MyEditor");
                if (editor != null)
                {
                    value = editor.Text; // This will give you the text entered in the Editor
                                         // Do something with the value
                }
                else value = "0";
                int intvalue = Convert.ToInt32(value);
                pO_MAX_Transaction maxt = new pO_MAX_Transaction()
                {
                    typE_39 = "R",
                    subtypE_39 = "P",
                    ordnuM_39 = poInfItem.ordnum10,
                    linnuM_39 = poInfItem.linnum10,
                    delnuM_39 = poInfItem.delnum10,
                    tnxqtY_39 = intvalue,
                    rcvstK_39 = "",
                    refdsC_39 = ""
                };
                ClosePo orderline = new ClosePo()
                {
                    poM_Transaction = maxt
                };
                listCPO.Add(orderline);
            }

            postPOInf(listCPO);
            PoListview.ItemsSource = null;
            PoListview.ItemsSource = poInfItems;
        }

        private void postPOInf(object myData)
        {
            Dispatcher.Dispatch(async () =>
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient(handler);


                String json = JsonConvert.SerializeObject(myData);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PutAsync("https://10.1.7.7/api/MAX_POReceipt/", content);
                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Alert", "Success!", "Ok");
                        if (orderLineItem != null)
                        {
                            poInfItems.Remove(orderLineItem);
                            PoListview.ItemsSource = null;
                            PoListview.ItemsSource = poInfItems;
                        }
                    }
                    else
                        await DisplayAlert("Alert", "Failed", "Ok");
                }
                catch (Exception e)
                {
                    await DisplayAlert("Alert", "couldn't connet to server!", "Ok");
                }
            }
            );
        }


    }
}


