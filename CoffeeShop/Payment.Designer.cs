namespace CoffeeShop
{
    partial class Payment
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
            this.lblAmtDue = new System.Windows.Forms.Label();
            this.tbAmtDue = new System.Windows.Forms.TextBox();
            this.tbAmtReceived = new System.Windows.Forms.TextBox();
            this.lblAmtReceived = new System.Windows.Forms.Label();
            this.btnTender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAmtDue
            // 
            this.lblAmtDue.AutoSize = true;
            this.lblAmtDue.Location = new System.Drawing.Point(62, 32);
            this.lblAmtDue.Name = "lblAmtDue";
            this.lblAmtDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmtDue.TabIndex = 0;
            this.lblAmtDue.Text = "Amount Due";
            // 
            // tbAmtDue
            // 
            this.tbAmtDue.Location = new System.Drawing.Point(192, 27);
            this.tbAmtDue.Name = "tbAmtDue";
            this.tbAmtDue.ReadOnly = true;
            this.tbAmtDue.Size = new System.Drawing.Size(423, 20);
            this.tbAmtDue.TabIndex = 1;
            // 
            // tbAmtReceived
            // 
            this.tbAmtReceived.Location = new System.Drawing.Point(192, 113);
            this.tbAmtReceived.Name = "tbAmtReceived";
            this.tbAmtReceived.Size = new System.Drawing.Size(423, 20);
            this.tbAmtReceived.TabIndex = 3;
            // 
            // lblAmtReceived
            // 
            this.lblAmtReceived.AutoSize = true;
            this.lblAmtReceived.Location = new System.Drawing.Point(62, 118);
            this.lblAmtReceived.Name = "lblAmtReceived";
            this.lblAmtReceived.Size = new System.Drawing.Size(92, 13);
            this.lblAmtReceived.TabIndex = 2;
            this.lblAmtReceived.Text = "Amount Received";
            // 
            // btnTender
            // 
            this.btnTender.Location = new System.Drawing.Point(226, 206);
            this.btnTender.Name = "btnTender";
            this.btnTender.Size = new System.Drawing.Size(233, 174);
            this.btnTender.TabIndex = 4;
            this.btnTender.Text = "Tender";
            this.btnTender.UseVisualStyleBackColor = true;
            this.btnTender.Click += new System.EventHandler(this.btnTender_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTender);
            this.Controls.Add(this.tbAmtReceived);
            this.Controls.Add(this.lblAmtReceived);
            this.Controls.Add(this.tbAmtDue);
            this.Controls.Add(this.lblAmtDue);
            this.Name = "Payment";
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmtDue;
        private System.Windows.Forms.TextBox tbAmtDue;
        private System.Windows.Forms.TextBox tbAmtReceived;
        private System.Windows.Forms.Label lblAmtReceived;
        private System.Windows.Forms.Button btnTender;
    }
}