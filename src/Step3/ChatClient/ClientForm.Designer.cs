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
            this.btConnectToServer = new System.Windows.Forms.Button();
            this.tbRecvChatMsg = new System.Windows.Forms.TextBox();
            this.tbSendChatMsg = new System.Windows.Forms.TextBox();
            this.btEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbChatName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btConnectToServer
            // 
            this.btConnectToServer.Location = new System.Drawing.Point(653, 12);
            this.btConnectToServer.Name = "btConnectToServer";
            this.btConnectToServer.Size = new System.Drawing.Size(120, 60);
            this.btConnectToServer.TabIndex = 0;
            this.btConnectToServer.Text = "connect to server";
            this.btConnectToServer.UseVisualStyleBackColor = true;
            this.btConnectToServer.Click += new System.EventHandler(this.button1_Click);
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
            // btEnter
            // 
            this.btEnter.Location = new System.Drawing.Point(635, 369);
            this.btEnter.Name = "btEnter";
            this.btEnter.Size = new System.Drawing.Size(138, 54);
            this.btEnter.TabIndex = 3;
            this.btEnter.Text = "send message";
            this.btEnter.UseVisualStyleBackColor = true;
            this.btEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type your chat name:";
            // 
            // tbChatName
            // 
            this.tbChatName.Location = new System.Drawing.Point(203, 25);
            this.tbChatName.Name = "tbChatName";
            this.tbChatName.Size = new System.Drawing.Size(166, 21);
            this.tbChatName.TabIndex = 5;
            this.tbChatName.Text = "yoojin";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbChatName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btEnter);
            this.Controls.Add(this.tbSendChatMsg);
            this.Controls.Add(this.tbRecvChatMsg);
            this.Controls.Add(this.btConnectToServer);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnectToServer;
        private System.Windows.Forms.TextBox tbRecvChatMsg;
        private System.Windows.Forms.TextBox tbSendChatMsg;
        private System.Windows.Forms.Button btEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbChatName;
    }
}

