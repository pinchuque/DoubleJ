namespace DoubleJ.Oms.Web.Reports.Template
{
    partial class ProductionManifest
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.unitsSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.poundsSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.idDataTextBox = new Telerik.Reporting.TextBox();
            this.nameDataTextBox = new Telerik.Reporting.TextBox();
            this.unitsDataTextBox = new Telerik.Reporting.TextBox();
            this.poundsDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.unitsSumFunctionTextBox,
            this.poundsSumFunctionTextBox,
            this.textBox5,
            this.textBox8});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // unitsSumFunctionTextBox
            // 
            this.unitsSumFunctionTextBox.CanGrow = true;
            this.unitsSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3674216270446777D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.unitsSumFunctionTextBox.Name = "unitsSumFunctionTextBox";
            this.unitsSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0299999713897705D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.unitsSumFunctionTextBox.Style.Font.Bold = true;
            this.unitsSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.unitsSumFunctionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitsSumFunctionTextBox.StyleName = "Data";
            this.unitsSumFunctionTextBox.Value = "=Sum(Fields.WeightKg)";
            // 
            // poundsSumFunctionTextBox
            // 
            this.poundsSumFunctionTextBox.CanGrow = true;
            this.poundsSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.poundsSumFunctionTextBox.Name = "poundsSumFunctionTextBox";
            this.poundsSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0399999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.poundsSumFunctionTextBox.Style.Font.Bold = true;
            this.poundsSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.poundsSumFunctionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.poundsSumFunctionTextBox.StyleName = "Data";
            this.poundsSumFunctionTextBox.Value = "=Sum(Fields.WeightLbs)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1673425436019898D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "Data";
            this.textBox5.Value = "Totals:";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3499999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "=Sum(Fields.Units)";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3674216270446777D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0700786113739014D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.pageInfoTextBox.Style.Font.Bold = true;
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.pictureBox1,
            this.textBox9});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(3.9471520722145215E-05D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.2999606728553772D));
            this.titleTextBox.Style.Font.Bold = true;
            this.titleTextBox.Style.Font.Name = "Arial";
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Double J Meat Packing";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.3000788688659668D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.29988199472427368D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Arial";
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Title";
            this.textBox1.Value = "Production Manifest";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.600039541721344D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8999998569488525D), Telerik.Reporting.Drawing.Unit.Inch(0.29980349540710449D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "Arial";
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.StyleName = "Title";
            this.textBox2.Value = "= Parameters.Date.Value + \" kill\"";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.89992183446884155D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.29999992251396179D));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Arial";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.StyleName = "Title";
            this.textBox3.Value = "= \"Order Number \" + Parameters.OrderNumber.Value";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(1.200000524520874D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0.19992133975028992D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "Arial";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(13D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.StyleName = "Title";
            this.textBox4.Value = "= Parameters.SubCaption.Value";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(3.9471520722145215E-05D));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9791666269302368D), Telerik.Reporting.Drawing.Unit.Inch(1.6997647285461426D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = "= Parameters.Logo.Value";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(1.4000006914138794D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.3000004291534424D), Telerik.Reporting.Drawing.Unit.Inch(0.29980349540710449D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Arial";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox9.StyleName = "Title";
            this.textBox9.Value = "= \"Customer PO \" + Parameters.CustomerPO.Value";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000007152557373D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.idDataTextBox,
            this.nameDataTextBox,
            this.unitsDataTextBox,
            this.poundsDataTextBox,
            this.textBox7});
            this.detail.Name = "detail";
            // 
            // idDataTextBox
            // 
            this.idDataTextBox.CanGrow = true;
            this.idDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.idDataTextBox.Name = "idDataTextBox";
            this.idDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2699999809265137D), Telerik.Reporting.Drawing.Unit.Inch(0.27916672825813293D));
            this.idDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.idDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.idDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.idDataTextBox.StyleName = "Data";
            this.idDataTextBox.Value = "=Fields.Id";
            // 
            // nameDataTextBox
            // 
            this.nameDataTextBox.CanGrow = true;
            this.nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.nameDataTextBox.Name = "nameDataTextBox";
            this.nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0499999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.27916672825813293D));
            this.nameDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.nameDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.nameDataTextBox.StyleName = "Data";
            this.nameDataTextBox.Value = "=Fields.Name";
            // 
            // unitsDataTextBox
            // 
            this.unitsDataTextBox.CanGrow = true;
            this.unitsDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3717966079711914D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.unitsDataTextBox.Name = "unitsDataTextBox";
            this.unitsDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0281248092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.27916672825813293D));
            this.unitsDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.unitsDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.unitsDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitsDataTextBox.StyleName = "Data";
            this.unitsDataTextBox.Value = "= Fields.WeightKg";
            // 
            // poundsDataTextBox
            // 
            this.poundsDataTextBox.CanGrow = true;
            this.poundsDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.poundsDataTextBox.Name = "poundsDataTextBox";
            this.poundsDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0374997854232788D), Telerik.Reporting.Drawing.Unit.Inch(0.27916672825813293D));
            this.poundsDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.poundsDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.poundsDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.poundsDataTextBox.StyleName = "Data";
            this.poundsDataTextBox.Value = "= Fields.WeightLbs";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3499999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "=Fields.Units";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = "DoubleJ.Oms.Web.Reports.Model.ProductItem, DoubleJ.Oms.Web, Version=1.0.0.0, Cult" +
    "ure=neutral, PublicKeyToken=null";
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // ProductionManifest
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportFooter,
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "ProductionManifest";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            reportParameter1.Name = "Date";
            reportParameter2.Name = "OrderNumber";
            reportParameter3.Name = "SubCaption";
            reportParameter4.Name = "Logo";
            reportParameter5.Name = "CustomerPO";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox unitsSumFunctionTextBox;
        private Telerik.Reporting.TextBox poundsSumFunctionTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox idDataTextBox;
        private Telerik.Reporting.TextBox nameDataTextBox;
        private Telerik.Reporting.TextBox unitsDataTextBox;
        private Telerik.Reporting.TextBox poundsDataTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;

    }
}