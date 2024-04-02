
namespace FootballLeague.WindowFormViews
{
    partial class MyClubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyClubForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvFootballer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRequest = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFootballer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 56);
            this.panel2.TabIndex = 22;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.DarkGreen;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShow.Location = new System.Drawing.Point(680, 10);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(185, 34);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "SHOW APPLICATIONS";
            this.btnShow.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCreate.Location = new System.Drawing.Point(589, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 34);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "CREATE";
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.BorderRadius = 13;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconRight = ((System.Drawing.Image)(resources.GetObject("guna2TextBox1.IconRight")));
            this.guna2TextBox1.Location = new System.Drawing.Point(500, 84);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Type something";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(229, 29);
            this.guna2TextBox1.TabIndex = 21;
            // 
            // dgvFootballer
            // 
            this.dgvFootballer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFootballer.Location = new System.Drawing.Point(407, 122);
            this.dgvFootballer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFootballer.Name = "dgvFootballer";
            this.dgvFootballer.Size = new System.Drawing.Size(520, 430);
            this.dgvFootballer.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(392, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Club";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 76);
            this.panel1.TabIndex = 20;
            // 
            // dgvRequest
            // 
            this.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequest.Location = new System.Drawing.Point(0, 122);
            this.dgvRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRequest.Name = "dgvRequest";
            this.dgvRequest.Size = new System.Drawing.Size(410, 360);
            this.dgvRequest.TabIndex = 23;
            // 
            // MyClubForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(930, 616);
            this.Controls.Add(this.dgvRequest);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.dgvFootballer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyClubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyClubForm";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFootballer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCreate;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.DataGridView dgvFootballer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRequest;
    }
}