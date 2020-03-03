namespace SocketSiguri
{
	partial class Form1
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
			this.txtMyPort = new System.Windows.Forms.TextBox();
			this.txtMyIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.lsAllText = new System.Windows.Forms.ListBox();
			this.txtMyMessage = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnConnectedClients = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMyPort
			// 
			this.txtMyPort.Location = new System.Drawing.Point(367, 34);
			this.txtMyPort.Multiline = true;
			this.txtMyPort.Name = "txtMyPort";
			this.txtMyPort.Size = new System.Drawing.Size(138, 33);
			this.txtMyPort.TabIndex = 5;
			// 
			// txtMyIP
			// 
			this.txtMyIP.Location = new System.Drawing.Point(106, 34);
			this.txtMyIP.Multiline = true;
			this.txtMyIP.Name = "txtMyIP";
			this.txtMyIP.Size = new System.Drawing.Size(138, 33);
			this.txtMyIP.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(293, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Port :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(34, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "IP :";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(541, 32);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(109, 38);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Start server";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// lsAllText
			// 
			this.lsAllText.FormattingEnabled = true;
			this.lsAllText.Location = new System.Drawing.Point(24, 104);
			this.lsAllText.Name = "lsAllText";
			this.lsAllText.Size = new System.Drawing.Size(626, 264);
			this.lsAllText.TabIndex = 3;
			// 
			// txtMyMessage
			// 
			this.txtMyMessage.Location = new System.Drawing.Point(24, 423);
			this.txtMyMessage.Multiline = true;
			this.txtMyMessage.Name = "txtMyMessage";
			this.txtMyMessage.Size = new System.Drawing.Size(523, 27);
			this.txtMyMessage.TabIndex = 4;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(553, 423);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(97, 27);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnConnectedClients
			// 
			this.btnConnectedClients.Location = new System.Drawing.Point(38, 483);
			this.btnConnectedClients.Name = "btnConnectedClients";
			this.btnConnectedClients.Size = new System.Drawing.Size(112, 49);
			this.btnConnectedClients.TabIndex = 6;
			this.btnConnectedClients.Text = "Show All Connected Clients";
			this.btnConnectedClients.UseVisualStyleBackColor = true;
			this.btnConnectedClients.Click += new System.EventHandler(this.btnConnectedClients_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 555);
			this.Controls.Add(this.btnConnectedClients);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMyPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtMyIP);
			this.Controls.Add(this.txtMyMessage);
			this.Controls.Add(this.lsAllText);
			this.Controls.Add(this.btnStart);
			this.Name = "Form1";
			this.Text = " ";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtMyPort;
		private System.Windows.Forms.TextBox txtMyIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ListBox lsAllText;
		private System.Windows.Forms.TextBox txtMyMessage;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnConnectedClients;
	}
}

