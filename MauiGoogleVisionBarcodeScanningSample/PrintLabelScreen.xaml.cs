//using Android.Graphics;
using Newtonsoft.Json;
//using PdfSharp.Xamarin.Forms;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Controls.Xaml;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telerik.Documents.Core.Fonts;
//using Telerik.Core.Fonts;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Data;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.Model.Editing.Flow;
using Telerik.Windows.Documents.Fixed.Model.Objects;
using Telerik.Windows.Documents.Fixed.Model.Text;
using Telerik.Windows.Documents.Model.Drawing.Shapes;
using HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment;
using FontFamily = Telerik.Documents.Core.Fonts.FontFamily;
using FontStyle = Telerik.Documents.Core.Fonts.FontStyle;
using FontWeights = Telerik.Documents.Core.Fonts.FontWeights;
using FontWeight = Telerik.Documents.Core.Fonts.FontWeight;
/*using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;*/
//using static Android.Icu.Text.CaseMap;

namespace MauiGoogleVisionBarcodeScanningSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrintLabelScreen : ContentPage
    {
        public Stream GetOriginalStream(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = fileName;
          
            return assembly.GetManifestResourceStream(resourceName);
        }
        string msg = "";
        public PrintLabelScreen(string paramaters)
        {
            InitializeComponent();
            msg = paramaters;
            //img1.Source= ImageSource.FromStream(() => GetOriginalStream("XamApi.Images.arrow.jpg"));
            //img2.Source = ImageSource.FromStream(() => GetOriginalStream("XamApi.Images.arrow.jpg"));
            //img3.Source = ImageSource.FromStream(() => GetOriginalStream("XamApi.Images.logo2.png"));

            img1.Source = "arrow.jpg";
            img2.Source = "arrow.jpg";
            img3.Source = "logo2.png";
        }
        DateTime dt = DateTime.Now;
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient(handler);


          ////  HttpClient client = new HttpClient();
          //  var response = await client.GetStringAsync("s://10.1.7.7/api/Shipping/" + msg);


            //HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://10.1.7.7:8123/api/Shipping/" + msg);
            //var response = await client.GetStringAsync("https://mnx4fr15-7131.use.devtunnels.ms/api/Shipping/" + msg);


            var homeData = JsonConvert.DeserializeObject<List<POInfItem>>(response);
            ////what is "Fragile Furniture in api...is it name?
            //lbl1.Text = homeData[0].name;
            //lbl2.Text = homeData[0].shippedToAddress1;
            //lbl3.Text = homeData[0].salesOrder;
            //lbl4.Text = homeData[0].custPO_27;
            //lbl5.Text = homeData[0].custPO_27;
            //lbl6.Text = homeData[0].cityStZip;
            //lbl7.Text = homeData[0].shipVia;

            //lbl8.Text = homeData[0].linNum;
            //lbl9.Text = homeData[0].qty.ToString();
            //lbl10.Text = homeData[0].slsUOM;
            //lbl11.Text = homeData[0].partNumber;

            //lbl12.Text = homeData[0].pmDes1+","+ homeData[0].pmDes2;
            //lbl13.Text = homeData[0].configInfo;


            lblCompanyName.Text = homeData[0].ordnum10;
            lblCompanyAddress.Text = homeData[0].delnum10;
            lblSalesOrder.Text = homeData[0].prtnum10;
            lblCustPO.Text = homeData[0].pmdes201;
            lblJobID.Text = homeData[0].pmdes101;
            lblCityStZip.Text = "a";
            lblShipVia.Text = "a";

            lblLinNum.Text = "a";
            lblQTY.Text = "a";
            lblSlsUOM.Text = "a";
            lblPartNumber.Text = "a";

            lblPrtDesc.Text = "a";
            lblConfigInfo.Text = "a";

        }
        private async void PrintClicked(object sender, EventArgs e)
        {
            //string json = "[{\"salesCat\":\"  \",\"salesOrder\":\"21008800\",\"lineNum\":\"12\",\"delNum\":\"01\",\"custId\":\"KLILUM\",\"name\":\"CREATIVE DESIGNS IN CABINETRY/DBA\",\"addr1\":\"KLINGBEIL LUMBER CO.\",\"addr2\":\"1175 W BROADWAY AVE\",\"citStZip\":\"MEDFORD WI, 54451\",\"custpo27\":\"P&S MEYER\",\"ordid27\":\"\",\"shipVia\":\"CUSTOMER PICK UP\",\"qty\":18,\"partNumber\":\"1592-0001-0116\",\"pmDes1\":\"CM,CROWN MOULDING\",\"pmDes2\":\"MPL\",\"shippedtoname\":\"\",\"shippedtoaddress1\":\"\",\"shippedtoaddress2\":\"\",\"shippedtostateZip\":\"  \",\"phoneNumber\":\"715-748-4344        \",\"orderNotes\":\"\",\"configInfo\":\"STAIN-ANTIQUE WHITE\",\"slsuom\":\"FT\"}]";
            //var homeData = JsonConvert.DeserializeObject<List<Models.SalesRoot>>(json);
            //HttpClient client = new HttpClient();
            //var response = await client.GetStringAsync("://10.1.7.7:8123/api/Shipping/" + msg);


            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender2, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient(handler);


            //  HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://10.1.7.7/api/Shipping/" + msg);


      //      var response = await client.GetStringAsync("https://mnx4fr15-7131.use.devtunnels.ms/api/Shipping/" + msg);


            var homeData = JsonConvert.DeserializeObject<List<POInfItem>>(response);
            //what is "Fragile Furniture in api...is it name?

            lblCompanyName.Text = homeData[0].ordnum10;
            lblCompanyAddress.Text = homeData[0].delnum10;
            lblSalesOrder.Text = homeData[0].prtnum10;
            lblCustPO.Text = homeData[0].pmdes201;
            lblJobID.Text = homeData[0].pmdes101;
            lblCityStZip.Text = "a";
            lblShipVia.Text = "a";

            lblLinNum.Text = "a";
            lblQTY.Text = "a";
            lblSlsUOM.Text = "a";
            lblPartNumber.Text = "a";

            lblPrtDesc.Text = "a";
            lblConfigInfo.Text = "a";


            //lbl1.Text = homeData[0].name;
            //lbl2.Text = homeData[0].shippedToAddress1;
            //lbl3.Text = homeData[0].salesOrder;
            //lbl4.Text = homeData[0].custPO_27;
            //lbl5.Text = homeData[0].custPO_27;
            //lbl6.Text = homeData[0].cityStZip==null?"": homeData[0].cityStZip;
            //lbl7.Text = homeData[0].shipVia;

            //lbl8.Text = homeData[0].linNum == null ? "" : homeData[0].linNum;
            //lbl9.Text = homeData[0].qty.ToString();
            //lbl10.Text = homeData[0].slsUOM;
            //lbl11.Text = homeData[0].partNumber;

            //lbl12.Text = homeData[0].pmDes1 + "," + homeData[0].pmDes2;
            //lbl13.Text = homeData[0].configInfo;

        }


        private async void Save_Clicked(object sender, EventArgs e)
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageRead>();
            }
            PermissionStatus status1 = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status1 != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageWrite>();
            }
            RadFixedDocument document = new RadFixedDocument();
            RadFixedPage page = document.Pages.AddPage();
            MatrixPosition matrixPositionLogo1 = new MatrixPosition();
            matrixPositionLogo1.Translate(300, 100);
            TextFragment fragmentLogo1 = new TextFragment() { Text = "FRAGILE", Position = matrixPositionLogo1, StrokeThickness = 50, FontSize = 36 };
            page.Content.Add(fragmentLogo1);
            MatrixPosition matrixPositionLogo2 = new MatrixPosition();
            matrixPositionLogo2.Translate(260, 150);
            TextFragment fragmentLogo2 = new TextFragment() { Text = "FURNITURE", Position = matrixPositionLogo2, StrokeThickness = 50, FontSize = 36 };
            page.Content.Add(fragmentLogo2);
            var editor = new FixedContentEditor(page)
;
            editor.Position.Translate(200, 180);
            editor.DrawImage((GetOriginalStream("XamApi.Images.logo2.jpg")), 400, 150);
            MatrixPosition matrixPositionLogo3 = new MatrixPosition();
            matrixPositionLogo3.Translate(130, 370);
            TextFragment fragmentLogo3 = new TextFragment() { Text = "749 KENNEDY STREET RIB LAKE WI 54470 715.427.5255"
                , Position = matrixPositionLogo3, StrokeThickness = 20, FontSize = 22 };
            page.Content.Add(fragmentLogo3);


            MatrixPosition matrixPosition4 = new MatrixPosition();
            matrixPosition4.Translate(50, 410);
            TextFragment fragmentShipTo = new TextFragment() { Text = "SHIP TO", Position = matrixPosition4, StrokeThickness = 20, FontSize = 14 };
            page.Content.Add(fragmentShipTo);

            MatrixPosition matrixPosition = new MatrixPosition();
            matrixPosition.Translate(50, 450);
            TextFragment fragment1 = new TextFragment() { Text = lblCompanyName.Text, Position = matrixPosition, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment1);
            MatrixPosition matrixPosition2 = new MatrixPosition();
            matrixPosition2.Translate(50, 485);
            TextFragment fragment2 = new TextFragment() { Text = lblCompanyAddress.Text, Position = matrixPosition2, StrokeThickness = 40, FontSize = 16 };
            page.Content.Add(fragment2);

            MatrixPosition matrixPos8 = new MatrixPosition();
            matrixPos8.Translate(50, 550);
            TextFragment fragment8 = new TextFragment() { Text = lblCityStZip.Text, Position = matrixPos8, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment8);

            MatrixPosition matrixPosition3 = new MatrixPosition();
            matrixPosition3.Translate(440, 450);
            TextFragment fragment3 = new TextFragment() { Text = "Sales Order:" + lblSalesOrder.Text, Position = matrixPosition3, StrokeThickness = 40, FontSize = 34 };
            page.Content.Add(fragment3);
            MatrixPosition matrixPos4 = new MatrixPosition();
            matrixPos4.Translate(430, 490);
            TextFragment fragment4 = new TextFragment() { Text = "Cust Order#" + lblCustPO.Text, Position = matrixPos4, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment4);
            MatrixPosition matrixPos5 = new MatrixPosition();
            matrixPos5.Translate(440, 530);
            TextFragment fragment5 = new TextFragment() { Text = "Job Id:" + lblJobID.Text, Position = matrixPos5, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment5);


            var memoryStream = new MemoryStream();
            using (var source = System.IO.File.OpenRead(DependencyService.Get<IBarcodeService>().GetBarCodeStream(lblSalesOrder.Text+ lblLinNum.Text)))
            {
                source.CopyTo(memoryStream);
                var editorb = new FixedContentEditor(page)
;
             //   editorb.Position.Translate(300, 560);
                editorb.Position.Translate(400, 560); //horizontal, vertical
                editorb.DrawImage(memoryStream, 300, 100);
            }





            MatrixPosition matrixPos7 = new MatrixPosition();
            matrixPos7.Translate(400, 700);
            TextFragment fragment7 = new TextFragment() { Text = "Ship Via:" + lblShipVia.Text, Position = matrixPos7, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment7);

            var editor2 = new FixedContentEditor(page);

            //Drawing Box

            int left = 50;
            int right = 780;
            int top = 710;
            int bottom = 950;
            editor2.DrawLine(new Telerik.Documents.Primitives.Point(left, top), new Telerik.Documents.Primitives.Point(right, top));
            editor2.DrawLine(new Telerik.Documents.Primitives.Point(left, bottom), new Telerik.Documents.Primitives.Point(right, bottom));
            editor2.DrawLine(new Telerik.Documents.Primitives.Point(left, top), new Telerik.Documents.Primitives.Point(left, bottom));
            editor2.DrawLine(new Telerik.Documents.Primitives.Point(right, top), new Telerik.Documents.Primitives.Point(right, bottom));

            MatrixPosition matrixPos88 = new MatrixPosition();
            matrixPos88.Translate(60, 740);
            TextFragment fragment88 = new TextFragment() { Text = lblLinNum.Text, Position = matrixPos88, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment88);
            MatrixPosition matrixPos9 = new MatrixPosition();
            matrixPos9.Translate(150, 740);
            TextFragment fragment9 = new TextFragment() { Text = lblQTY.Text, Position = matrixPos9, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment9);
            MatrixPosition matrixPos10 = new MatrixPosition();
            matrixPos10.Translate(190, 740);
            TextFragment fragment10 = new TextFragment() { Text = lblSlsUOM.Text, Position = matrixPos10, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment10);
            MatrixPosition matrixPos11 = new MatrixPosition();
            matrixPos11.Translate(530, 740);
            TextFragment fragment11 = new TextFragment() { Text = lblPartNumber.Text, Position = matrixPos11, StrokeThickness = 40, FontSize = 17 };
            page.Content.Add(fragment11);

            //MatrixPosition matrixPos12 = new MatrixPosition();
            //matrixPos12.Translate(230, 820);
            //TextFragment fragment12 = new TextFragment() { Text = lblPrtDesc.Text, Position = matrixPos12, StrokeThickness = 40, FontSize = 20 };
            //page.Content.Add(fragment12);
            //MatrixPosition matrixPos13 = new MatrixPosition();
            //matrixPos13.Translate(75, 870);
            //TextFragment fragment13 = new TextFragment() { Text = lblConfigInfo.Text, Position = matrixPos13, StrokeThickness = 40, FontSize = 20 };
            //page.Content.Add(fragment13);


            // Preparing the block that needs to be inserted
            // If you want to separate the text on different lines you will need to call InsertLineBreak()
            // ...otherwise both strings will appear as one continuous line of text
            Block partInfoBlock = new Block();
            partInfoBlock.HorizontalAlignment = HorizontalAlignment.Center;
            FontFamily myFontFamily = new FontFamily("Arial");
            FontStyle myFontStyle = FontStyles.Normal;
            FontWeight myFontWeight = FontWeights.Bold;

            double myFontSize = 25;
            partInfoBlock.TextProperties.TrySetFont(myFontFamily, myFontStyle, myFontWeight);
            partInfoBlock.TextProperties.FontSize = myFontSize;

            partInfoBlock.InsertText(myFontFamily, myFontStyle, myFontWeight, lblPrtDesc.Text);
            partInfoBlock.InsertLineBreak();
            partInfoBlock.InsertText(myFontFamily, myFontStyle, myFontWeight, lblConfigInfo.Text);

            // Calculate the coordinates of the middle point of the drawing box
            double middleDrawingBoxX = (left + right) / 2.0;
            double middleDrawingBoxY = (top + bottom) / 2.0;

            // Measure the block containing the new text
            Telerik.Documents.Primitives.Size blockSize = partInfoBlock.Measure();

            // Calculate the middle point of the block containing the new text
            double middleBlockX = blockSize.Width / 2.0;
            double middleBlockY = blockSize.Height / 2.0;

            // Calculate the coordinates of the block
            double horizontalBlockPosition = middleDrawingBoxX - middleBlockX;
            double verticalBlockPosition = middleDrawingBoxY - middleBlockY;

            editor2.Position.Translate(horizontalBlockPosition, verticalBlockPosition);
            editor2.DrawBlock(partInfoBlock);

            //Block partInfoBlock = new Block();
            //partInfoBlock.InsertText(lblPrtDesc.Text);
            //partInfoBlock.InsertText(lblConfigInfo.Text);
            //editor.Position.
            //editor.DrawBlock(partInfoBlock);


            //MatrixPosition matrixPos12 = new MatrixPosition();
            //matrixPos12.Translate(230, 820);
            //TextFragment fragment12 = new TextFragment() { Text = lblPrtDesc.Text, Position = matrixPos12, StrokeThickness = 40, FontSize = 20 };
            //page.Content.Add(fragment12);
            //MatrixPosition matrixPos13 = new MatrixPosition();
            //matrixPos13.Translate(50, 870);
            //TextFragment fragment13 = new TextFragment() { Text = lblConfigInfo.Text, Position = matrixPos13, StrokeThickness = 40, FontSize = 20 };
            //page.Content.Add(fragment13);

            //Writing to the PAGE?

            var editora1 = new FixedContentEditor(page)
;
            editora1.Position.Translate(0, 20);
            editora1.DrawImage((GetOriginalStream("XamApi.Images.arrow.jpg")), 200, 310);
            var editora2 = new FixedContentEditor(page)
;
            editora2.Position.Translate(600, 20);
            editora2.DrawImage((GetOriginalStream("XamApi.Images.arrow.jpg")), 200, 310);

            MatrixPosition matrixPos14 = new MatrixPosition();
            matrixPos14.Translate(260, 1000);
            TextFragment fragment14 = new TextFragment() { Text = "HANDLE WITH CARE", Position = matrixPos14, StrokeThickness = 80, FontSize = 40 };
            page.Content.Add(fragment14);
            string path = DependencyService.Get<IPdfSave>().GetPath(DateTime.Now.Ticks.ToString() + "_cabinet.pdf");
            PdfFormatProvider pdfProvider = new PdfFormatProvider();

            using (Stream output = File.Create(path))
            {
                pdfProvider.Export(document, output);
            }
            await DisplayAlert(
               "Success",
               $"Your PDF generated at {path}",
               "OK");
            using (FileStream str = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    //can we run the app
                    str.CopyTo(ms);
                    DependencyService.Get<IPrintService>().PrintPdfFile(ms);
                }

            }

        }

        private async void Home_Clicked(object sender, EventArgs e)
        {
            //App.BarcodeCount = 0;
            // await Navigation.PushAsync(new NavigationPage(new MainPage()));
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}