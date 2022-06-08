namespace ChatClient
{
    partial class ClientForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.tbRecvChatMsg = new System.Windows.Forms.TextBox();
            this.tbSendChatMsg = new System.Windows.Forms.TextBox();
            this.btSender = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btDisConnect = new System.Windows.Forms.Button();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(467, 16);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(92, 54);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect to server";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // tbRecvChatMsg
            // 
            this.tbRecvChatMsg.Location = new System.Drawing.Point(17, 85);
            this.tbRecvChatMsg.Multiline = true;
            this.tbRecvChatMsg.Name = "tbRecvChatMsg";
            this.tbRecvChatMsg.Size = new System.Drawing.Size(756, 242);
            this.tbRecvChatMsg.TabIndex = 1;
            // 
            // tbSendChatMsg
            // 
            this.tbSendChatMsg.Location = new System.Drawing.Point(17, 355);
            this.tbSendChatMsg.Multiline = true;
            this.tbSendChatMsg.Name = "tbSendChatMsg";
            this.tbSendChatMsg.Size = new System.Drawing.Size(612, 83);
            this.tbSendChatMsg.TabIndex = 2;
            // 
            // btSender
            // 
            this.btSender.Location = new System.Drawing.Point(653, 355);
            this.btSender.Name = "btSender";
            this.btSender.Size = new System.Drawing.Size(120, 83);
            this.btSender.TabIndex = 3;
            this.btSender.Text = "Send";
            this.btSender.UseVisualStyleBackColor = true;
            this.btSender.Click += new System.EventHandler(this.btSender_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type your name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(124, 12);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(166, 21);
            this.tbUserName.TabIndex = 5;
            // 
            // btDisConnect
            // 
            this.btDisConnect.Location = new System.Drawing.Point(574, 16);
            this.btDisConnect.Name = "btDisConnect";
            this.btDisConnect.Size = new System.Drawing.Size(92, 54);
            this.btDisConnect.TabIndex = 6;
            this.btDisConnect.Text = "Disconnect to server";
            this.btDisConnect.UseVisualStyleBackColor = true;
            this.btDisConnect.Click += new System.EventHandler(this.btDisConnect_Click);
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(124, 49);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(166, 21);
            this.tbServerIp.TabIndex = 7;
            this.tbServerIp.Text = "127.0.0.1";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(681, 16);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(92, 54);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Type Server IP:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 454);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbServerIp);
            this.Controls.Add(this.btDisConnect);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSender);
            this.Controls.Add(this.tbSendChatMsg);
            this.Controls.Add(this.tbRecvChatMsg);
            this.Controls.Add(this.btConnect);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox tbRecvChatMsg;
        private System.Windows.Forms.TextBox tbSendChatMsg;
        private System.Windows.Forms.Button btSender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btDisConnect;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label2;
    }
}

