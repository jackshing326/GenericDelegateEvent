namespace GenericDelegateEvent
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Run = new System.Windows.Forms.Button();
            this.tb_Context = new System.Windows.Forms.TextBox();
            this.cb_Select = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(198, 27);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.Text = "執行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // tb_Context
            // 
            this.tb_Context.Location = new System.Drawing.Point(13, 56);
            this.tb_Context.Multiline = true;
            this.tb_Context.Name = "tb_Context";
            this.tb_Context.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Context.Size = new System.Drawing.Size(259, 193);
            this.tb_Context.TabIndex = 1;
            // 
            // cb_Select
            // 
            this.cb_Select.FormattingEnabled = true;
            this.cb_Select.Items.AddRange(new object[] {
            "Generic",
            "Delegate",
            "DelegateEvent",
            "Thread",
            "ThreadPool",
            "Task"});
            this.cb_Select.Location = new System.Drawing.Point(13, 27);
            this.cb_Select.Name = "cb_Select";
            this.cb_Select.Size = new System.Drawing.Size(121, 20);
            this.cb_Select.TabIndex = 2;
            this.cb_Select.SelectedIndexChanged += new System.EventHandler(this.cb_Select_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cb_Select);
            this.Controls.Add(this.tb_Context);
            this.Controls.Add(this.btn_Run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.TextBox tb_Context;
        private System.Windows.Forms.ComboBox cb_Select;
    }
}

