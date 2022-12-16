namespace Prueba_hotel
{
    partial class Usuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mostrarUser = new System.Windows.Forms.DataGridView();
            this.btnBorrarUser = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarUser)).BeginInit();
            this.SuspendLayout();
            // 
            // mostrarUser
            // 
            this.mostrarUser.AllowUserToAddRows = false;
            this.mostrarUser.AllowUserToDeleteRows = false;
            this.mostrarUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mostrarUser.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mostrarUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mostrarUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mostrarUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.mostrarUser.Location = new System.Drawing.Point(57, 51);
            this.mostrarUser.Name = "mostrarUser";
            this.mostrarUser.ReadOnly = true;
            this.mostrarUser.RowTemplate.Height = 25;
            this.mostrarUser.Size = new System.Drawing.Size(667, 356);
            this.mostrarUser.TabIndex = 0;
            this.mostrarUser.DoubleClick += new System.EventHandler(this.mostrarUser_DoubleClick);
            // 
            // btnBorrarUser
            // 
            this.btnBorrarUser.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBorrarUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarUser.FlatAppearance.BorderSize = 0;
            this.btnBorrarUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.btnBorrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBorrarUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrarUser.Location = new System.Drawing.Point(57, 12);
            this.btnBorrarUser.Name = "btnBorrarUser";
            this.btnBorrarUser.Size = new System.Drawing.Size(220, 35);
            this.btnBorrarUser.TabIndex = 8;
            this.btnBorrarUser.Text = "Borrar";
            this.btnBorrarUser.UseVisualStyleBackColor = false;
            this.btnBorrarUser.Click += new System.EventHandler(this.btnBorrarUser_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtID.Location = new System.Drawing.Point(301, 14);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(35, 33);
            this.txtID.TabIndex = 9;
            this.txtID.Text = "ID";
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnBorrarUser);
            this.Controls.Add(this.mostrarUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView mostrarUser;
        private Button btnBorrarUser;
        private TextBox txtID;
    }
}