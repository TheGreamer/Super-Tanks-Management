namespace Super_Tanks_Management
{
    partial class AllowedTanksForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxSuperTanks;
        private System.Windows.Forms.Button buttonToggleSelected;
        private System.Windows.Forms.Button buttonActivateAll;
        private System.Windows.Forms.Button buttonDeactivateAll;
        private System.Windows.Forms.Label labelStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxSuperTanks = new System.Windows.Forms.ListBox();
            this.buttonToggleSelected = new System.Windows.Forms.Button();
            this.buttonActivateAll = new System.Windows.Forms.Button();
            this.buttonDeactivateAll = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.generalSettingsButton = new System.Windows.Forms.Button();
            this.superTanksSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxSuperTanks
            // 
            this.listBoxSuperTanks.BackColor = System.Drawing.Color.PaleTurquoise;
            this.listBoxSuperTanks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxSuperTanks.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxSuperTanks.FormattingEnabled = true;
            this.listBoxSuperTanks.ItemHeight = 18;
            this.listBoxSuperTanks.Location = new System.Drawing.Point(30, 30);
            this.listBoxSuperTanks.Name = "listBoxSuperTanks";
            this.listBoxSuperTanks.Size = new System.Drawing.Size(275, 310);
            this.listBoxSuperTanks.TabIndex = 0;
            this.listBoxSuperTanks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxSuperTanks_DrawItem);
            // 
            // buttonToggleSelected
            // 
            this.buttonToggleSelected.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonToggleSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonToggleSelected.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonToggleSelected.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonToggleSelected.Location = new System.Drawing.Point(333, 30);
            this.buttonToggleSelected.Name = "buttonToggleSelected";
            this.buttonToggleSelected.Size = new System.Drawing.Size(244, 30);
            this.buttonToggleSelected.TabIndex = 1;
            this.buttonToggleSelected.Text = "Toggle Selected Tank";
            this.buttonToggleSelected.UseVisualStyleBackColor = false;
            this.buttonToggleSelected.Click += new System.EventHandler(this.ButtonToggleSelected_Click);
            // 
            // buttonActivateAll
            // 
            this.buttonActivateAll.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonActivateAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonActivateAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonActivateAll.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonActivateAll.Location = new System.Drawing.Point(333, 80);
            this.buttonActivateAll.Name = "buttonActivateAll";
            this.buttonActivateAll.Size = new System.Drawing.Size(244, 30);
            this.buttonActivateAll.TabIndex = 2;
            this.buttonActivateAll.Text = "Activate All Tanks";
            this.buttonActivateAll.UseVisualStyleBackColor = false;
            this.buttonActivateAll.Click += new System.EventHandler(this.ButtonActivateAll_Click);
            // 
            // buttonDeactivateAll
            // 
            this.buttonDeactivateAll.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonDeactivateAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeactivateAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDeactivateAll.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeactivateAll.Location = new System.Drawing.Point(333, 130);
            this.buttonDeactivateAll.Name = "buttonDeactivateAll";
            this.buttonDeactivateAll.Size = new System.Drawing.Size(244, 30);
            this.buttonDeactivateAll.TabIndex = 3;
            this.buttonDeactivateAll.Text = "Deactivate All Tanks";
            this.buttonDeactivateAll.UseVisualStyleBackColor = false;
            this.buttonDeactivateAll.Click += new System.EventHandler(this.ButtonDeactivateAll_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStatus.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelStatus.Location = new System.Drawing.Point(333, 180);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(244, 60);
            this.labelStatus.TabIndex = 4;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt";
            this.openFileDialog.Title = "Select (allowtanks.txt) file";
            // 
            // generalSettingsButton
            // 
            this.generalSettingsButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.generalSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generalSettingsButton.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.generalSettingsButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.generalSettingsButton.Location = new System.Drawing.Point(333, 260);
            this.generalSettingsButton.Name = "generalSettingsButton";
            this.generalSettingsButton.Size = new System.Drawing.Size(244, 30);
            this.generalSettingsButton.TabIndex = 5;
            this.generalSettingsButton.Text = "General Settings";
            this.generalSettingsButton.UseVisualStyleBackColor = false;
            this.generalSettingsButton.Click += new System.EventHandler(this.GeneralSettingsButton_Click);
            // 
            // superTanksSettingsButton
            // 
            this.superTanksSettingsButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.superTanksSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.superTanksSettingsButton.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.superTanksSettingsButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.superTanksSettingsButton.Location = new System.Drawing.Point(333, 310);
            this.superTanksSettingsButton.Name = "superTanksSettingsButton";
            this.superTanksSettingsButton.Size = new System.Drawing.Size(244, 30);
            this.superTanksSettingsButton.TabIndex = 6;
            this.superTanksSettingsButton.Text = "Super Tanks Settings";
            this.superTanksSettingsButton.UseVisualStyleBackColor = false;
            this.superTanksSettingsButton.Click += new System.EventHandler(this.SuperTanksSettingsButton_Click);
            // 
            // AllowedTanksForm
            // 
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(609, 366);
            this.Controls.Add(this.superTanksSettingsButton);
            this.Controls.Add(this.generalSettingsButton);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDeactivateAll);
            this.Controls.Add(this.buttonActivateAll);
            this.Controls.Add(this.buttonToggleSelected);
            this.Controls.Add(this.listBoxSuperTanks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AllowedTanksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Tanks Management";
            this.Load += new System.EventHandler(this.AllowedTanksForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button generalSettingsButton;
        private System.Windows.Forms.Button superTanksSettingsButton;
    }
}