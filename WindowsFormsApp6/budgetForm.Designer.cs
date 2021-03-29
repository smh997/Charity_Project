namespace WindowsFormsApp6
{
    partial class budgetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(budgetForm));
            this.editBudgetButton = new System.Windows.Forms.Button();
            this.setBudgetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editBudgetButton
            // 
            this.editBudgetButton.BackColor = System.Drawing.Color.Yellow;
            this.editBudgetButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.editBudgetButton.FlatAppearance.BorderSize = 2;
            this.editBudgetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBudgetButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editBudgetButton.Location = new System.Drawing.Point(176, 67);
            this.editBudgetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editBudgetButton.Name = "editBudgetButton";
            this.editBudgetButton.Size = new System.Drawing.Size(113, 91);
            this.editBudgetButton.TabIndex = 14;
            this.editBudgetButton.Text = "ویرایش بودجه";
            this.editBudgetButton.UseVisualStyleBackColor = false;
            this.editBudgetButton.Click += new System.EventHandler(this.editBudgetButton_Click);
            // 
            // setBudgetButton
            // 
            this.setBudgetButton.BackColor = System.Drawing.Color.Cyan;
            this.setBudgetButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.setBudgetButton.FlatAppearance.BorderSize = 2;
            this.setBudgetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setBudgetButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setBudgetButton.Location = new System.Drawing.Point(57, 67);
            this.setBudgetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setBudgetButton.Name = "setBudgetButton";
            this.setBudgetButton.Size = new System.Drawing.Size(113, 91);
            this.setBudgetButton.TabIndex = 13;
            this.setBudgetButton.Text = "تعیین بودجه";
            this.setBudgetButton.UseVisualStyleBackColor = false;
            this.setBudgetButton.Click += new System.EventHandler(this.setBudgetButton_Click);
            // 
            // budgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(347, 225);
            this.Controls.Add(this.editBudgetButton);
            this.Controls.Add(this.setBudgetButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "budgetForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بودجه";
            this.Activated += new System.EventHandler(this.budgetForm_Load);
            this.Load += new System.EventHandler(this.budgetForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editBudgetButton;
        private System.Windows.Forms.Button setBudgetButton;
    }
}