﻿namespace ChatServer
{
    partial class ServerForm
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
            this.ChattingList = new System.Windows.Forms.TextBox();
            this.UserList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChattingList
            // 
            this.ChattingList.Location = new System.Drawing.Point(12, 12);
            this.ChattingList.Multiline = true;
            this.ChattingList.Name = "ChattingList";
            this.ChattingList.Size = new System.Drawing.Size(640, 426);
            this.ChattingList.TabIndex = 0;
            this.ChattingList.TextChanged += new System.EventHandler(this.ChattingList_TextChanged);
            // 
            // UserList
            // 
            this.UserList.Location = new System.Drawing.Point(670, 12);
            this.UserList.Multiline = true;
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(118, 426);
            this.UserList.TabIndex = 1;
            this.UserList.TextChanged += new System.EventHandler(this.UserList_TextChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.ChattingList);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChattingList;
        private System.Windows.Forms.TextBox UserList;
    }
}

