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
            this.StartButton = new System.Windows.Forms.Button();
            this.ChattingLog = new System.Windows.Forms.TextBox();
            this.MyChat = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.StartButton.Location = new System.Drawing.Point(17, 19);
            this.StartButton.Name = "Start";
            this.StartButton.Size = new System.Drawing.Size(112, 49);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChattingLog
            // 
            this.ChattingLog.Location = new System.Drawing.Point(17, 85);
            this.ChattingLog.Multiline = true;
            this.ChattingLog.Name = "ChattingList";
            this.ChattingLog.Size = new System.Drawing.Size(756, 242);
            this.ChattingLog.TabIndex = 1;
            this.ChattingLog.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MyChat
            // 
            this.MyChat.Location = new System.Drawing.Point(17, 355);
            this.MyChat.Multiline = true;
            this.MyChat.Name = "MyChat";
            this.MyChat.Size = new System.Drawing.Size(612, 83);
            this.MyChat.TabIndex = 2;
            this.MyChat.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Enter
            // 
            this.EnterButton.Location = new System.Drawing.Point(656, 355);
            this.EnterButton.Name = "Enter";
            this.EnterButton.Size = new System.Drawing.Size(117, 83);
            this.EnterButton.TabIndex = 3;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.MyChat);
            this.Controls.Add(this.ChattingLog);
            this.Controls.Add(this.StartButton);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox ChattingLog;
        private System.Windows.Forms.TextBox MyChat;
        private System.Windows.Forms.Button EnterButton;
    }
}

