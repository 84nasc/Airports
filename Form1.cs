using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

//For this experiment please add airports.json to C:\TestFiles, e.g., C:\TestFiles\airports.json. The process takes about 30 seconds to one minute to fully parse the json into the table.

namespace Airports
{
    public partial class Form1 : Form
    {
        TableLayoutPanel table = new TableLayoutPanel();
        private void initializeTable() {
            table.AutoSize = true;
            table.ColumnCount = 4;
            table.RowCount = 0;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;            
            addColumns(180f);            
            addHeader();
            table.Location = new Point(30, 35);
            table.Hide();
        }
        private void addHeader() {
            addRow(30F, new string[] { "NAME", "MUNICIPALITY", "REGION", "IATA" });

            //this handler was created to change the background color of the cells in the table header programmatically. It is triggered by the rendering of the cells. A better solution for this might exist.
            table.CellPaint += new TableLayoutCellPaintEventHandler(setHeaderBgColor);
        }
        private void setHeaderBgColor(object sender, TableLayoutCellPaintEventArgs e) {
            if (e.Row == 0)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(new SolidBrush(Color.LightGray), r);
                table.GetControlFromPosition(0, 0).BackColor = Color.LightGray;
                table.GetControlFromPosition(1, 0).BackColor = Color.LightGray;
                table.GetControlFromPosition(2, 0).BackColor = Color.LightGray;
                table.GetControlFromPosition(3, 0).BackColor = Color.LightGray;
            }
        }
        private void addColumns(float width){
            for (int col = 0; col < table.ColumnCount; col++) {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
            }
        }
        private void addRow(float height, string[] labels)
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, height));

            for (int cell = 0; cell < labels.Length; cell++)
            {
                table.Controls.Add(new Label() { Text = labels[cell], Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, cell, table.RowCount - 1);
            }
        }
        private void populateTable(string path) {
            try
            {
                //creates the json file stream and deserializes the json data into the airportRecords object
                StreamReader stream = new StreamReader(path);
                string jsonFileData = stream.ReadToEnd();
                var airportRecords = JsonConvert.DeserializeObject<airports>(jsonFileData);

                //iterates through each airport in records, adding to a new row each
                foreach (var airport in airportRecords.records)
                {
                    //the Invoke call is needed here to access the table control in order to add rows while avoiding an exception. That is because the table control is part of a separate thread.
                    if (table.InvokeRequired)
                    {
                        table.Invoke(new MethodInvoker(delegate
                            {
                                addRow(30F, new string[] { airport.name, airport.municipality, airport.iso_region, airport.iata_code });
                            }
                        ));
                    }
                    else 
                    {
                        addRow(30F, new string[] { airport.name, airport.municipality, airport.iso_region, airport.iata_code });
                    }
                }                         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            //creates table control with initial properties and adds the header
            initializeTable();
            
            //new thread to handle heavy json parsing and populating the table with data
            Thread addingRows = new Thread(delegate () 
            {
                //method to populate the table using data from the json file
                populateTable(@"C:\TestFiles\airports.json");
                
                //the populated table, which is initially hidden, gets rendered to the form and the "please wait" message goes away
                Action showPopulatedTable = new Action(renderTable);
                this.BeginInvoke(showPopulatedTable);
            });      
            
            //initializes the thread
            addingRows.Start();

            //finally the table control is added to the form
            Controls.Add(table);
        }
        private void renderTable()
        {
            table.Show();
            waitMessage.Hide();
            waitTimeLabel.Hide();
            waitProgressBar.Hide();
        }
    }
    public class airports 
    { 
        public List<airport> records { get; set; }
    }
    public class airport 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string municipality { get; set; }
        public string iso_region { get; set; }
        public string iata_code { get; set; }
    }


}