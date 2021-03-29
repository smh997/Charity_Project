using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class observeForm : Form
    {
        public observeForm()
        {
            InitializeComponent();
        }

        private void memberButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMembersForm();
            newform.ShowDialog(this);
        }

        private void familiesButton_Click(object sender, EventArgs e)
        {
            var newform = new observeFamiliesForm();
            newform.ShowDialog(this);
        }

        private void enactmentButton_Click(object sender, EventArgs e)
        {
            var newform = new observeEnactmentsForm();
            newform.ShowDialog(this);
        }

        private void applicantButton_Click(object sender, EventArgs e)
        {
            var newform = new observeApplicantsForm();
            newform.ShowDialog(this);
        }

        private void bankAccountButton_Click(object sender, EventArgs e)
        {
            var newform = new observeBankAccountsForm();
            newform.ShowDialog(this);
        }

        private void budgetButton_Click(object sender, EventArgs e)
        {
            var newform = new observeBudgetsForm();
            newform.ShowDialog(this);
        }

        private void budgetsetButton_Click(object sender, EventArgs e)
        {
            var newform = new observeBudgetsetsForm();
            newform.ShowDialog(this);
        }

        private void amountButton_Click(object sender, EventArgs e)
        {
            var newform = new observeamountsForm();
            newform.ShowDialog(this);
        }

        private void helperButton_Click(object sender, EventArgs e)
        {
            var newform = new observehelpersForm();
            newform.ShowDialog(this);
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            var newform = new observebuyhelpsForm();
            newform.ShowDialog(this);
        }

        private void parameterButton_Click(object sender, EventArgs e)
        {
            var newform = new observeparametersForm();
            newform.ShowDialog(this);
        }

        private void recHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observerechelpsForm();
            newform.ShowDialog(this);
        }

        private void receivedLetterButton_Click(object sender, EventArgs e)
        {
            var newform = new observerecLetterForm();
            newform.ShowDialog(this);
        }

        private void sentLetterButton_Click(object sender, EventArgs e)
        {
            var newform = new observesentLetterForm();
            newform.ShowDialog(this);
        }

        private void moneyTransferButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMoneyTransferForm();
            newform.ShowDialog(this);
        }

        private void reqbutton1_Click(object sender, EventArgs e)
        {
            var newform = new observereqForm1();
            newform.ShowDialog(this);
        }

        private void reqButton2_Click(object sender, EventArgs e)
        {
            var newform = new observereqForm2();
            newform.ShowDialog(this);
        }

        private void reqButton3_Click(object sender, EventArgs e)
        {
            var newform = new observereqForm3();
            newform.ShowDialog(this);
        }

        private void otherApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherApplicantsForm();
            newform.ShowDialog(this);
        }

        private void globalHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeGlobalHelpsForm();
            newform.ShowDialog(this);
        }

        private void healReqsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeHealReqsForm();
            newform.ShowDialog(this);
        }

        private void healHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeHealHelpsForm();
            newform.ShowDialog(this);
        }

        private void marryReqsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMarryReqsForm();
            newform.ShowDialog(this);
        }

        private void marryHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMarryHelpsForm();
            newform.ShowDialog(this);
        }

        private void studyButton_Click(object sender, EventArgs e)
        {
            var newform = new observeStudyHelpsForm();
            newform.ShowDialog(this);
        }

        private void OtherIndivReqsButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherIndivReqsForm();
            newform.ShowDialog(this);
        }

        private void otherHelpsIndivButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherIndivHelpsForm();
            newform.ShowDialog(this);
        }

        private void otherGlobalHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherHelpsGlobalForm();
            newform.ShowDialog(this);
        }

        private void onindependencyButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOnindependencyForm();
            newform.ShowDialog(this);
        }

        private void independencyCheckedButton_Click(object sender, EventArgs e)
        {
            var newform = new observeindependencyCheckedForm();
            newform.ShowDialog(this);
        }

        private void outButton_Click(object sender, EventArgs e)
        {
            var newform = new observeabandonedsForm();
            newform.ShowDialog(this);
        }

        private void inButton_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void researchButton_Click(object sender, EventArgs e)
        {
            //todo
        }
    }
}
