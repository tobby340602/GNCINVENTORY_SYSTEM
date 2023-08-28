using BarcodeScanner.Mobile;
using Microsoft.Maui.Controls.Internals;
using Newtonsoft.Json;
using System.Text;

namespace MauiGoogleVisionBarcodeScanningSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        }

        List<POInfItem> poInfItems { get; set; }

        public MainPage(List<POInfItem> items)
        {
            InitializeComponent();
            poInfItems = items;
            PoListview.ItemsSource = poInfItems;
            Label_Vendor.Text = "Vendor : " + poInfItems[0].venidName;
            Label_order.Text = "Order number : " + poInfItems[0].ordnum10;
        }

        //   POInfItem orderLineItem;

        private async void onItemClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Question", "Close this line?", "Sure", "Cancel");
            if (answer)
            {
                ImageButton button = (ImageButton)sender;
                //  orderLineItem = (POInfItem)button.BindingContext;
                var viewCell = (ViewCell)button.Parent.Parent.Parent;
                POInfItem poInfItem = viewCell.BindingContext as POInfItem;
                Editor editor = (Editor)viewCell.FindByName("MyEditor");

                string transferQtyValue = editor.Text == null ? poInfItem.dueqty10.ToString() : editor.Text;
                int value = Convert.ToInt32(transferQtyValue);
                prePost(value, poInfItem);
            }
        }

        private void prePost(int value, POInfItem podata)
        {
            if (podata.type10.Equals("NI"))
            {
                string url = "https://9jxch27b-7131.use.devtunnels.ms/api/MAX_NIReceipt/";
                nI_MAX_Tran maxt = new nI_MAX_Tran()
                {
                    typE_39 = "R",
                    subtypE_39 = "N",
                    ordnuM_39 = podata.ordnum10,
                    linnuM_39 = podata.linnum10,
                    delnuM_39 = podata.delnum10,
                    tnxqtY_39 = value,
                    glreF_39 = "",
                    refdsC_39 = ""
                };
                NI_Max orderline = new NI_Max()
                {
                    nI_MAX_Transaction = maxt
                };
                postPOInf(orderline, url, podata);
            }
            else
            {
                string url = "https://9jxch27b-7131.use.devtunnels.ms/api/MAX_POReceipt/";
                pO_MAX_Tran maxt = new pO_MAX_Tran()
                {
                    typE_39 = "R",
                    subtypE_39 = "N",
                    ordnuM_39 = podata.ordnum10,
                    linnuM_39 = podata.linnum10,
                    delnuM_39 = podata.delnum10,
                    tnxqtY_39 = value,
                    rcvstK_39 = "",
                    refdsC_39 = ""
                };
                PO_Max orderline = new PO_Max()
                {
                    pO_MAX_Transaction = maxt
                };
                postPOInf(orderline, url, podata);
            }
        }

        private void onBtnClose_Clicked(object sender, EventArgs e)
        {
            foreach (var poInfItem in poInfItems)
            {
                var editor = ((ViewCell)PoListview.TemplatedItems[poInfItems.IndexOf(poInfItem)]).FindByName<Editor>("MyEditor");
                string transferQtyValue = editor.Text == null ? poInfItem.dueqty10.ToString() : editor.Text;
                int value = Convert.ToInt32(transferQtyValue);
                prePost(value, poInfItem);
            }
        }

        private void postPOInf(object myData, string url, POInfItem lineItem)
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
                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        if (lineItem != null)
                        {
                            poInfItems.Remove(lineItem);
                            PoListview.ItemsSource = null;
                            PoListview.ItemsSource = poInfItems;
                        }
                    }
                }
                catch (Exception e)
                {
                    await DisplayAlert("Alert", "couldn't connet to server! ", "Ok");
                }
            });
        }
    }
}


