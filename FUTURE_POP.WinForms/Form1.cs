using DocumentFormat.OpenXml.Bibliography;
using FUTURE_POP.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FUTURE_POP.WinForms
{
    public partial class FuturePop : Form
    {
        //Global Variables 
        private List <Governorate> Governorates = new List <Governorate> ();
        bool IsLoaded = false;
        Governorate Selected ;
        bool IsLoaded1 = false;
        Governorate Gov1 ;
        bool IsLoaded2 = false;
        Governorate Gov2 ;
        //Preparing data methods
        public void FormattedData()
        {
            if (Selected == null) return;
            LblPresent.Text = $@"Name: {Selected.Name}
Capital: {Selected.Capital}
Type: {Selected.Type}
Population Count in 2018: {Selected.popCount[0]}
Population Count in 2020: {Selected.popCount[1]}
Population Count in 2022: {Selected.popCount[2]}
Population Count in 2024: {Selected.popCount[3]}
Population Count in 2026: {Selected.popCount[4]}
Area: {Selected.Area}";
            LblCalculated.Text = $@"Population Density: {Selected.PopDensity}
Average Growth Rate: {Selected.AvgGrowthRate}
Expected Schools Count: {Selected.SchoolNumber}
Expected Hospitals Count: {Selected.HospitalNumber}
Expected Police Stations Count: {Selected.PoliceNumber}";
            LblPrediction.Text = $@"The predicted Population Count in 2028: {Selected.PredPopCount[0]}
With the Growth Rate of {Selected.PredGrowthRate[0]}

The Predicted Population Count in 2030: {Selected.PredPopCount[1]}
With the Growth Rate of {Selected.PredGrowthRate[1]}";
        }
        public void Compare()
        {
            LblGov1.Text = $@"Name: {Gov1.Name}
Capital: {Gov1.Capital}
Type: {Gov1.Type}
Area: {Gov1.Area}
Population Count in 2018: {Gov1.popCount[0]}
Population Count in 2020: {Gov1.popCount[1]}
Population Count in 2022: {Gov1.popCount[2]}
Population Count in 2024: {Gov1.popCount[3]}
Population Count in 2026: {Gov1.popCount[4]}
Average Growth Rate: {Gov1.AvgGrowthRate}
Population Density: {Gov1.PopDensity}
Required Number of Schools: {Gov1.SchoolNumber}
Required Number of Hospitals: {Gov1.HospitalNumber}
Required Number of Police Stations: {Gov1.PoliceNumber}";
            LblGov2.Text = $@"Name: {Gov2.Name}
Capital: {Gov2.Capital}
Type: {Gov2.Type}
Area: {Gov2.Area}
Population Count in 2018: {Gov2.popCount[0]}
Population Count in 2020: {Gov2.popCount[1]}
Population Count in 2022: {Gov2.popCount[2]}
Population Count in 2024: {Gov2.popCount[3]}
Population Count in 2026: {Gov2.popCount[4]}
Average Growth Rate: {Gov2.AvgGrowthRate}
Population Density: {Gov2.PopDensity}
Required Number of Schools: {Gov2.SchoolNumber}
Required Number of Hospitals: {Gov2.HospitalNumber}
Required Number of Police Stations: {Gov2.PoliceNumber}";
        }
        public FuturePop(List<Governorate> govs)
        {
            InitializeComponent();
            Governorates = govs;
            CBGovernorate.SelectedIndexChanged -= CBGovernorate_SelectedIndexChanged_1;
            CBGovernorate.DataSource = Governorates;
            CBGovernorate.DisplayMember = "Name";
            CBGovernorate.SelectedIndexChanged += CBGovernorate_SelectedIndexChanged_1;
            IsLoaded = true;
            // Compare
            // Gov1
            CBGov1.SelectedIndexChanged -= CBGov1_SelectedIndexChanged;
            CBGov1.DataSource = Governorates.ToList();
            CBGov1.DisplayMember = "Name";
            CBGov1.SelectedIndexChanged += CBGov1_SelectedIndexChanged;
            IsLoaded1 = true;
            // Gov2
            CBGov2.SelectedIndexChanged -= CBGov2_SelectedIndexChanged;
            CBGov2.DataSource = Governorates.ToList();
            CBGov2.DisplayMember = "Name";
            CBGov2.SelectedIndexChanged += CBGov2_SelectedIndexChanged;
            IsLoaded2 = true;
        }
        private void FuturePop_Load(object sender, EventArgs e)
        {
            PnlStart.Visible = true;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        //Panel 1.1
        private void BtnBegin_Analysis_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = true;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        private void BtnBegin_Compare_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = true;
            PnlComparison.Visible = false;
        }
        // Panel 1.2
        private void CBGovernorate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            if (CBGovernorate.SelectedItem == null) return;
            Selected = (Governorate)CBGovernorate.SelectedItem;
            FormattedData();
        }
        private void BtnShowData_Click_1(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = true;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        private void BtnBack2_Click_1(object sender, EventArgs e)
        {
            PnlStart.Visible = true;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        //Panel 1.3
        private void BtnPrediction_Click_1(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = true;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        private void BtnBack3_Click_1(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = true;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        //Panel 1.4
        private void BtnBack4_2_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = true;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        private void BtnBack4_3_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = true;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        // Panel 2.1
        private void BtnCompare_Click(object sender, EventArgs e)
        {
            if (Gov1.Name == Gov2.Name || (Gov1 == null && Gov2 == null))
            {
                MessageBox.Show("Invalid Selection: Please choose two different governorates.");
                CBGov2.SelectedItem = null;
                return;
            }
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = true;
        }
        private void BtnBack4_1_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = true;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false; 
        }
        private void CBGov1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoaded1) return;
            if (CBGov1.SelectedItem == null) return;
            Gov1 = (Governorate)CBGov1.SelectedItem;
            if (Gov1 != null && Gov2 != null)
                Compare();
        }
        private void CBGov2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoaded2) return;
            if (CBGov2.SelectedItem == null) return;
            Gov2 = (Governorate)CBGov2.SelectedItem;
            if (Gov1 != null && Gov2 != null)
                Compare();
        }
        // Panel 2.2
        private void Btm3BackTo1_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = true;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = false;
            PnlComparison.Visible = false;
        }
        private void Btn4BackTo2_Click(object sender, EventArgs e)
        {
            PnlStart.Visible = false;
            PnlGovernorate.Visible = false;
            PnlAnalysis.Visible = false;
            PnlPrediction.Visible = false;
            PnlChooseGov.Visible = true;
            PnlComparison.Visible = false;
        }
    }
}
